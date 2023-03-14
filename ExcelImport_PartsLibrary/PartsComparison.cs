using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public PartsComparison()
        {
            InitializeComponent();
        }
        public PartsComparison(List<PartExcel> partsExcelList, List<PartLibrary> partsLibraryList)
        {
            InitializeComponent();
            InitializeDataGridView(partsLibraryList, partsExcelList);
        }

        private void InitializeDataGridView(List<PartLibrary> partsLibraryList, List<PartExcel> partsExcelList)
        {
            dgvPartsComparison.DataSource = CreateComparedPartsList(partsLibraryList, partsExcelList);

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgvPartsComparison.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dgvPartsComparison.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //// Set the column header names.
            //dgvPartsComparison.Columns[0].Name = "L.p.";
            //dgvPartsComparison.Columns[1].Name = "Nazwa części";
            //dgvPartsComparison.Columns[2].Name = "Lokalizacja";
            //dgvPartsComparison.Columns[3].Name = "Ilość";

            //this.dgvPartsComparison.AutoGenerateColumns = false;
            //this.dgvPartsComparison.Columns.Add("Id", "L.p.");
            //this.dgvPartsComparison.Columns.Add("Name", "Nazwa części");
            //this.dgvPartsComparison.Columns.Add("Path", "Lokalizacja");
            //this.dgvPartsComparison.Columns.Add("Quantity", "Ilość");

            dgvPartsComparison.AutoResizeColumnHeadersHeight();
            dgvPartsComparison.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            dgvPartsComparison.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPartsComparison.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPartsComparison.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private List<PartsComparison> CreateComparedPartsList(List<PartLibrary> partsLibraryList, List<PartExcel> partsExcelList)
        {
            int indexer = 1;
            newPartLibraryList = partsLibraryList.Where(x => partsExcelList.Any(y => y.Name == x.Name)).OrderBy(x => x.Name).Cast<PartLibrary>().ToList();
            partsComparedList = newPartLibraryList.Join(partsExcelList, pL => pL.Name, pE => pE.Name, (pL, pE) => new { pL.Id, pL.Name, pL.Path, pE.Quantity }).Select(x => new PartsComparison { Id = indexer++, PartName = x.Name, Path = x.Path, Quantity = x.Quantity })
                .ToList();

            return partsComparedList;
        }

        private void bDeletePart_Click(object sender, EventArgs e)
        {

        }

        private void bRefreshPartsList_Click(object sender, EventArgs e)
        {

        }

        private void bLoadPartsToSN_Click(object sender, EventArgs e)
        {

        }

        private void dgvPartsComparison_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 4; i < dgvPartsComparison.Columns.Count; i++)
            {
                this.dgvPartsComparison.Columns[i].Visible = false;
            }

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
    }
}
