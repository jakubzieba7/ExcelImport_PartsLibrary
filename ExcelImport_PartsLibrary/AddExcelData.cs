using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using SigmaNEST;
using DataTable = System.Data.DataTable;

namespace SNPlugin
{
    public partial class AddExcelData : Form
    {
        ISNApp FSNApp;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmExecute"/> class.
        /// </summary>
        /// <param name="ASNApp">The SN application.</param>
        public AddExcelData(ISNApp ASNApp)
        {
            InitializeComponent();
            FSNApp = ASNApp;
        }

        /// <summary>
        /// /Reads an excel file and converts it into dataset with each sheet as each table of the dataset
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="headers">If set to true the first row will be considered as headers</param>
        /// <returns></returns>
        //public DataSet Import(string filename, bool headers = true)
        //{
        //    var _xl = new Excel.Application();
        //    var wb = _xl.Workbooks.Open(filename);
        //    var sheets = wb.Sheets;
        //    DataSet dataSet = null;
        //    if (sheets != null && sheets.Count != 0)
        //    {
        //        dataSet = new DataSet();
        //        foreach (var item in sheets)
        //        {
        //            var sheet = (Excel.Worksheet)item;
        //            DataTable dt = null;
        //            if (sheet != null)
        //            {
        //                dt = new DataTable();
        //                var ColumnCount = ((Excel.Range)sheet.UsedRange.Rows[1, Type.Missing]).Columns.Count;
        //                var rowCount = ((Excel.Range)sheet.UsedRange.Columns[1, Type.Missing]).Rows.Count;

        //                for (int j = 0; j < ColumnCount; j++)
        //                {
        //                    var cell = (Excel.Range)sheet.Cells[1, j + 1];
        //                    var column = new DataColumn(headers ? cell.Value : string.Empty);
        //                    dt.Columns.Add(column);
        //                }

        //                for (int i = 0; i < rowCount; i++)
        //                {
        //                    var r = dt.NewRow();
        //                    for (int j = 0; j < ColumnCount; j++)
        //                    {
        //                        var cell = (Excel.Range)sheet.Cells[i + 1 + (headers ? 1 : 0), j + 1];
        //                        r[j] = cell.Value;
        //                    }
        //                    dt.Rows.Add(r);
        //                }

        //            }
        //            dataSet.Tables.Add(dt);
        //        }
        //    }
        //    _xl.Quit();
        //    return dataSet;
        //}


        public void ExcelDataLoad(string excelFilePath)
        {
            Excel.Application excelApp = new Excel.Application();

            //Type excelType = Type.GetTypeFromProgID("Excel.Application");
            //dynamic excelApp = Activator.CreateInstance(excelType);

            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(excelFilePath);
            Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[SelectedSheetListIndex() + 1];

            List<PartExcel> partList = new List<PartExcel>();

            DataTable dt = new DataTable();
            Excel.Range firstFilledCell = null;

            for (int i = 1; i <= excelWorksheet.UsedRange.Rows.Count; i++)
            {
                for (int j = 1; j <= excelWorksheet.UsedRange.Columns.Count; j++)
                {
                    Excel.Range cell = excelWorksheet.Cells[i, j];
                    if (cell.Value != null && cell.Value.ToString() != "")
                    {
                        firstFilledCell = cell;
                        break;
                    }
                }
                if (firstFilledCell != null)
                {
                    break;
                }
            }

            if (firstFilledCell != null)
            {
                // Get the row and column indexes of the first filled cell
                int firstFilledRow = firstFilledCell.Row;
                int firstFilledColumn = firstFilledCell.Column;
                int rowIndexer = 0;

                for (int i = firstFilledRow; i <= firstFilledRow + excelWorksheet.UsedRange.Rows.Count - 1; i++)
                {
                    rowIndexer++;
                    DataRow row = dt.NewRow();

                    for (int j = firstFilledColumn; j <= firstFilledColumn + excelWorksheet.UsedRange.Columns.Count - 1; j++)
                    {
                        if (rowIndexer == 1)
                        {
                            dt.Columns.Add(excelWorksheet.Cells[i, j].Value.ToString());
                        }
                        else
                        {
                            row[j - firstFilledColumn] = excelWorksheet.Cells[i, j].Value;
                        }
                    }

                    if (rowIndexer != 1)
                    {
                        dt.Rows.Add(row);

                        var part = new PartExcel();
                        part.Id = rowIndexer - 1;
                        part.Name = excelWorksheet.Cells[i, firstFilledColumn].Value;
                        //part.Quantity = int.TryParse(excelWorksheet.Cells[i, firstFilledColumn + 1].Value, out int quantity) == true ? Convert.ToInt32(excelWorksheet.Cells[i, firstFilledColumn + 1].Value) : quantity;
                        part.Quantity = Convert.ToInt32(excelWorksheet.Cells[i, firstFilledColumn + 1].Value);
                        partList.Add(part);
                    }
                }
            }
            dgvExcelData.DataSource = dt;

            excelWorkbook.Close();
            excelApp.Quit();

        }

        
        private void btnLoadExcelFile_Click(object sender, EventArgs e)
        {
            ExcelDataLoad(tbSelectedExcelPath.Text);
        }

        private void cbEcelListSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSheetListIndex();
        }

        private void bBrowseExcelFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)),
                Title = "Wyszukaj plik Excel",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "Skoroszyt programu Excel (*.xlsx)|*.xlsx|Skoroszyt programu Excel 97-2003 (*.xls)|*.xls|Skoroszyt programu Excel z obsługą makr (*.xlsm)|*.xlsm",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = false,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSelectedExcelPath.Text = openFileDialog1.FileName;
            }

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(tbSelectedExcelPath.Text);

            FillSheetsList(excelWorkbook);

            excelWorkbook.Close();
            excelApp.Quit();
        }

        private void FillSheetsList(Excel.Workbook workbook)
        {
            cbEcelListSheets.DataSource = workbook.Worksheets.OfType<Excel.Worksheet>().Select(x=>x.Name).ToList();
        }

        private int _selectedSheetListIndex;
        private int SelectedSheetListIndex()
        {
            return _selectedSheetListIndex = cbEcelListSheets.SelectedIndex;
        }

        private void bBrowsePartsLibrary_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                //tbSelectedPartsLibraryPath.Text = folder.SelectedPath;
                tbSelectedPartsLibraryPath.Text = @"C:\Users\Public\Documents\SNDATA\PARTS";
            }
        }

        private void bLoadParts_Click(object sender, EventArgs e)
        {
            List<string> partsNames = GetAllFiles(tbSelectedPartsLibraryPath.Text).ToList();
            int indexer = 0;
            List<PartLibrary> partList = new List<PartLibrary>();

            foreach (string partname in partsNames)
            {
                indexer++;
                var part = new PartLibrary();
                part.Id = indexer;
                part.Name = partname;
                part.Path = partname;
                partList.Add(part);
            }

            dgvExcelData.DataSource = partList;
        }

        public static List<String> GetAllFiles(String directory)
        {
            return Directory.EnumerateFiles(directory, "*.prs", SearchOption.AllDirectories).ToList();
            //return Directory.EnumerateDirectories(directory, "*", SearchOption.AllDirectories).ToList();
        }
    }
}
