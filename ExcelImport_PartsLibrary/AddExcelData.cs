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
            InitializePaths();
            InitializeSheetList();
            InitializeExcelDataGridViewHeaders();
            InitializePartLibraryDataGridViewHeaders();
            FSNApp = ASNApp;
        }

        private void InitializeExcelDataGridViewHeaders()
        {
            dgvExcelData.AutoGenerateColumns = false;

            var column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "L.p.";
            column1.Name = "Id";
            column1.DataPropertyName = "Id";

            var column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Nazwa części";
            column2.Name = "Name";
            column2.DataPropertyName = "Name";

            var column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Ilość";
            column3.Name = "Quantity";
            column3.DataPropertyName = "Quantity";

            dgvExcelData.Columns.Add(column1);
            dgvExcelData.Columns.Add(column2);
            dgvExcelData.Columns.Add(column3);

            dgvExcelData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExcelData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void InitializePartLibraryDataGridViewHeaders()
        {
            dgvPartsLibraryData.AutoGenerateColumns = false;

            var column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "L.p.";
            column1.Name = "Id";
            column1.DataPropertyName = "Id";

            var column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Nazwa części";
            column2.Name = "Name";
            column2.DataPropertyName = "Name";

            var column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Lokalizacja";
            column3.Name = "Path";
            column3.DataPropertyName = "Path";

            dgvPartsLibraryData.Columns.Add(column1);
            dgvPartsLibraryData.Columns.Add(column2);
            dgvPartsLibraryData.Columns.Add(column3);

            dgvPartsLibraryData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private string _excelFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ExcelPath.txt");
        private string _libraryFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PartsLibraryPath.txt");
        private void InitializePaths()
        {
            if (!File.Exists(_excelFilePath))
            {
                File.Create(_excelFilePath);
            }

            if (!File.Exists(_libraryFilePath))
            {
                File.Create(_libraryFilePath);
            }
            using (StreamReader readerExcel = new StreamReader(_excelFilePath))
            using (StreamReader readerLibrary = new StreamReader(_libraryFilePath))
            {
                tbSelectedExcelPath.Text = readerExcel.ReadToEnd().Trim();
                tbSelectedPartsLibraryPath.Text = readerLibrary.ReadToEnd();
                readerExcel.Close();
                readerLibrary.Close();
            }
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

            using (StreamWriter writerExcel = new StreamWriter(_excelFilePath))
            {
                writerExcel.Write(tbSelectedExcelPath.Text);
                writerExcel.Close();
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
                tbSelectedPartsLibraryPath.Text = folder.SelectedPath;
                //tbSelectedPartsLibraryPath.Text = @"C:\Users\Public\Documents\SNDATA\PARTS";
            }

            
            using (StreamWriter writerLibrary = File.CreateText(_libraryFilePath))
            {
                writerLibrary.Write(tbSelectedPartsLibraryPath.Text);
                writerLibrary.Close();
            }
        }

        private void ResizeColumnsRows()
        {
            dgvPartsLibraryData.AutoResizeColumnHeadersHeight();
            dgvPartsLibraryData.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            dgvPartsLibraryData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPartsLibraryData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPartsLibraryData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPartsLibraryData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void bLoadParts_Click(object sender, EventArgs e)
        {
            dgvPartsLibraryData.DataSource = CreatePartsLibraryList();
            ResizeColumnsRows();
        }

        public static List<string> GetAllFiles(string directory)
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
                int lastSlashIndex = libraryPartPath.LastIndexOf(@"\");
                indexer++;
                var part = new PartLibrary()
                {
                    Id = indexer,
                    Name = libraryPartPath.Substring(lastSlashIndex + 1, libraryPartPath.Length - lastSlashIndex - 5),
                    Path = libraryPartPath,
                };
                partList.Add(part);
            }
            return partList;
        }

        private void InitializeSheetList()
        {
            if (!string.IsNullOrEmpty(tbSelectedExcelPath.Text))
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(tbSelectedExcelPath.Text.Trim());

                FillSheetsList(excelWorkbook);

                excelWorkbook.Close();
                excelApp.Quit();
            }
        }
        private void bCompareParts_Click(object sender, EventArgs e)
        {
            //Excel.Application excelApp = new Excel.Application();
            //Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(tbSelectedExcelPath.Text);
            //Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[SelectedSheetListIndex() + 1];

            List<PartExcel> newExcelList = new List<PartExcel>();

            foreach (DataGridViewRow row in dgvExcelData.Rows)
            {
                PartExcel obj = new PartExcel()
                {
                    Id = int.Parse(row.Cells[0].Value.ToString()),
                    Name = row.Cells[1].Value.ToString(),
                    Quantity = int.Parse(row.Cells[2].Value.ToString()),
                };

                newExcelList.Add(obj);
            }


            PartsComparison partsComparison = new PartsComparison(newExcelList, CreatePartsLibraryList(), FSNApp);
            //PartsComparison partsComparison = new PartsComparison(CreateExcelPartList(excelWorksheet), CreatePartsLibraryList(), FSNApp);
            partsComparison.ShowDialog();

            //excelWorkbook.Close();
            //excelApp.Quit();
        }
    }
}
