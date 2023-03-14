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
            dgvPartsComparison.DataSource = CreateComparedPartsList(partsLibraryList, partsExcelList);
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
