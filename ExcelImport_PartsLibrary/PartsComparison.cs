using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SigmaNEST;

namespace SNPlugin
{
    public partial class PartsComparison : Form
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public string Path { get; set; }
        public int Quantity { get; set; }

        List<PartLibrary> newPartLibraryList = new List<PartLibrary>();
        List<PartsComparison> partsComparedList = new List<PartsComparison>();

        ISNApp FSNApp;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmExecute"/> class.
        /// </summary>
        /// <param name="ASNApp">The SN application.</param>

        public PartsComparison(ISNApp ASNApp)
        {
            InitializeComponent();
            FSNApp = ASNApp;
        }
        public PartsComparison(ISNApp ASNApp, List<PartExcel> partsExcelList = default, List<PartLibrary> partsLibraryList = default)
        {
            InitializeComponent();
            InitializeDataGridView(partsLibraryList, partsExcelList);
            CommaExist();
            FSNApp = ASNApp;
        }

        private void InitializeDataGridView(List<PartLibrary> partsLibraryList, List<PartExcel> partsExcelList)
        {

            dgvPartsComparison.AutoGenerateColumns = false;

            var column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "L.p.";
            column1.Name = "Id";
            column1.DataPropertyName = "Id";

            var column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Nazwa części";
            column2.Name = "PartName";
            column2.DataPropertyName = "PartName";

            var column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Lokalizacja";
            column3.Name = "Path";
            column3.DataPropertyName = "Path";

            var column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Ilość";
            column4.Name = "Quantity";
            column4.DataPropertyName = "Quantity";

            dgvPartsComparison.Columns.Add(column1);
            dgvPartsComparison.Columns.Add(column2);
            dgvPartsComparison.Columns.Add(column3);
            dgvPartsComparison.Columns.Add(column4);

            dgvPartsComparison.DataSource = CreateComparedPartsList(partsLibraryList, partsExcelList);

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgvPartsComparison.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dgvPartsComparison.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set the column and row resizing and alignment
            dgvPartsComparison.AutoResizeColumnHeadersHeight();
            dgvPartsComparison.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            dgvPartsComparison.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPartsComparison.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPartsComparison.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private List<PartsComparison> CreateComparedPartsList(List<PartLibrary> partsLibraryList, List<PartExcel> partsExcelList)
        {
            int indexer = 1;
            newPartLibraryList = partsLibraryList.Where(x => partsExcelList.Any(y => y.Name == x.Name)).OrderBy(x => x.Name).ToList();
            partsComparedList = newPartLibraryList.Join(partsExcelList, pL => pL.Name, pE => pE.Name, (pL, pE) => new { pL.Id, pL.Name, pL.Path, pE.Quantity }).Select(x => new PartsComparison(FSNApp) { Id = indexer++, PartName = x.Name, Path = x.Path.Trim(), Quantity = x.Quantity })
                .ToList();

            return partsComparedList;
        }

        private void bLoadPartsToSN_Click(object sender, EventArgs e)
        {
            FSNApp.ExecuteBatchCommand("SET, SILENTMODE, ON");
            FSNApp.ExecuteBatchCommand("CLEARWS");

            string partname, quantity, filepath;

            progressBar1.Maximum = dgvPartsComparison.RowCount;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            for (int rowIndex = 0; rowIndex < dgvPartsComparison.RowCount; rowIndex++)
            {
                // Load leadins from leadin table
                FSNApp.ExecuteBatchCommand("SET,LOOKUP,MAT");

                partname = dgvPartsComparison.Rows[rowIndex].Cells[1].Value.ToString();
                filepath = dgvPartsComparison.Rows[rowIndex].Cells[2].Value.ToString();
                quantity = dgvPartsComparison.Rows[rowIndex].Cells[3].Value.ToString();

                string wol = ($@"LOAD,PART,{filepath},{quantity}").Trim();
                
                FSNApp.ExecuteBatchCommand(wol);

                File.AppendAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WOL.txt"), wol);

                    if (FSNApp.PartsList.Count == 0)
                    {
                        dgvPartsComparison.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }

                for (int i = 0; i < FSNApp.PartsList.Count; i++)
                {
                    if (partname.ToUpper() == FSNApp.PartsList.Items(i).Name.ToUpper())
                    {
                        dgvPartsComparison.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                    }
                    else
                    {
                        dgvPartsComparison.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                }

                progressBar1.Value++;
            }

            FSNApp.ExecuteBatchCommand("PARTTILE");
            FSNApp.ExecuteBatchCommand("AUTOSCALE");
            FSNApp.ExecuteBatchCommand("RESETBATCHVAR");

            MessageBox.Show("Na podstawie " + (dgvPartsComparison.RowCount).ToString() + " wierszy z utworzonego widoku aplikacji zaimportowano " + FSNApp.PartsList.Count.ToString() + " części w SigmaNEST.", "Podsumowanie", MessageBoxButtons.OK);
        }

        private void dgvPartsComparison_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPartsComparison.Rows)
            {
                string valueToCompare = row.Cells[1].Value.ToString();
                bool foundDuplicate = false;

                foreach (DataGridViewRow nextRow in dgvPartsComparison.Rows)
                {
                    if (row.Index != nextRow.Index && nextRow.Cells[1].Value.ToString() == valueToCompare)
                    {
                        foundDuplicate = true;
                        break;
                    }
                }
                if (foundDuplicate)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void CommaExist()
        {
            List<string> incorrectInputList= new List<string>();

            foreach (DataGridViewRow row in dgvPartsComparison.Rows)
            {
                bool incorrectPartName = row.Cells[1].Value.ToString().Contains(',');
                bool incorrectPath = row.Cells[2].Value.ToString().Contains(',');

                if (incorrectPartName || incorrectPath)
                {
                    incorrectInputList.Add("Część " + row.Cells[1].Value.ToString() + " nie zostanie zaimportowana z powodu przecinka znajdującego się w jej " + (incorrectPartName ? "nazwie." : "ścieżce zapisu."));
                }
            }

            var message = string.Join(Environment.NewLine, incorrectInputList);

            if (incorrectInputList.Count > 0)
            {
                MessageBox.Show(message, "Niewłaściwa nazwa/ścieżka zapisu części", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            List<PartsComparison> comparisonPartsListDel= new List<PartsComparison>();

            if (dgvPartsComparison.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznacz część do usunięcia");
                return;
            }

            var selectedPart = dgvPartsComparison.SelectedRows[0];

            foreach (DataGridViewRow row in dgvPartsComparison.Rows)
            {
                PartsComparison obj = new PartsComparison(FSNApp)
                {
                    Id = int.Parse(row.Cells[0].Value.ToString()),
                    PartName = row.Cells[1].Value.ToString(),
                    Path= row.Cells[2].Value.ToString(),
                    Quantity = int.Parse(row.Cells[3].Value.ToString()),
                };

                comparisonPartsListDel.Add(obj);
            }

            dgvPartsComparison.DataSource = comparisonPartsListDel.RemoveAll(x => x.Id == Convert.ToInt32(selectedPart.Cells[0].Value));
        }
    }
}
