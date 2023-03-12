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

        List<PartExcel> newPartExcelList = new List<PartExcel> { };
        List<PartLibrary> newPartLibraryList = new List<PartLibrary>();
        List<PartsComparison> partsComparedList = new List<PartsComparison>();

        public PartsComparison()
        {

        }
        public PartsComparison(List<PartExcel> partsExcelList, List<PartLibrary> partsLibraryList)
        {

            InitializeComponent();
            newPartLibraryList = partsLibraryList.Where(x => partsExcelList.Any(y => y.Name == x.Name)).OrderBy(x => x.Name).Cast<PartLibrary>().ToList();
            dgvPartsComparison.DataSource = partsLibraryList.Where(x => partsExcelList.Any(y => y.Name == x.Name)).OrderBy(x => x.Name).Cast<PartLibrary>().ToList();

            int indexer = 0;
           
            newPartExcelList = partsExcelList;
            for (int i = 0; i < newPartLibraryList.Count; i++)
            {
                for (int j = 0; j < newPartExcelList.Count; j++)
                {
                    indexer++;
                    if (newPartLibraryList[i].Name == newPartExcelList[j].Name)
                    {
                        partsComparedList.Add(new PartsComparison()
                        {
                            Id = indexer,
                            PartName = newPartLibraryList[i].Name,
                            Path = newPartLibraryList[i].Path,
                            Quantity = newPartExcelList[j].Quantity,
                        });
                        MessageBox.Show(newPartLibraryList[i].Name.ToString() + newPartExcelList[j].Quantity.ToString());
                        MessageBox.Show(partsComparedList[j].Id + " " + partsComparedList[j].PartName + " " + partsComparedList[j].Quantity + " " + partsComparedList[j].Path);
                    }

                }
            }
            //dgvPartsComparison.DataSource = partsComparedList;
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
    }
}
