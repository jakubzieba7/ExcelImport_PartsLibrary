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

        public void ExcelDataLoad(string excelFilePath)
        {
            Excel.Application excelApp = new Excel.Application();

            //Type excelType = Type.GetTypeFromProgID("Excel.Application");
            //dynamic excelApp = Activator.CreateInstance(excelType);

            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(excelFilePath);
            Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[SelectedSheetListIndex() + 1];

            
            dgvExcelData.DataSource = CreateExcelPartList(excelWorksheet);

            excelWorkbook.Close();
            excelApp.Quit();

        }

        private List<PartExcel> CreateExcelPartList(Excel.Worksheet excelWorksheet)
        {
            List<PartExcel> partExcelList = new List<PartExcel>();

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
                        partExcelList.Add(part);
                    }
                }
            }
            //dgvExcelData.DataSource = dt;
            return partExcelList;
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
            dgvPartsLibraryData.DataSource = CreatePartsLibraryList();
        }

        public static List<String> GetAllFiles(String directory)
        {
            return Directory.EnumerateFiles(directory, "*.prs", SearchOption.AllDirectories).ToList();
            //return Directory.EnumerateDirectories(directory, "*", SearchOption.AllDirectories).ToList();
        }

        private List<PartLibrary> CreatePartsLibraryList()
        {
            List<string> partsLibraryPathList = GetAllFiles(tbSelectedPartsLibraryPath.Text).ToList();
            int indexer = 0;
            List<PartLibrary> partList = new List<PartLibrary>();

            foreach (string libraryPartPath in partsLibraryPathList)
            {
                int lastSlashIndex = libraryPartPath.LastIndexOf('\\');
                indexer++;
                var part = new PartLibrary();
                part.Id = indexer;
                part.Name = libraryPartPath.Substring(lastSlashIndex + 1, libraryPartPath.Length - lastSlashIndex - 5);
                part.Path = libraryPartPath;

                partList.Add(part);
            }
            return partList;
        }

        private void bCompareParts_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(tbSelectedExcelPath.Text);
            Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[SelectedSheetListIndex() + 1];

            PartsComparison partsComparison = new PartsComparison(CreateExcelPartList(excelWorksheet), CreatePartsLibraryList());
            partsComparison.ShowDialog();

            excelWorkbook.Close();
            excelApp.Quit();
        }
    }
}
