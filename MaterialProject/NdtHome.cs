using MaterialProject.Models;
using MaterialProject.MyDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaterialProject
{
    public partial class NdtHome : Form
    {
        public NdtHome()
        {
            InitializeComponent();
        }

        private void NdtHome_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.NDTs' table. You can move, or remove it, as needed.
            this.nDTsTableAdapter.Fill(this.myDBDataSet.NDTs);

        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        async void RefreshData()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            using (var ndtsAdapter = new NDTsTableAdapter())
            {
                ndtsGridView.DataSource = new SortableBindingList<MyDBDataSet.NDTsRow>(ndtsAdapter.GetData().ToList());
            }
        }

        private void addAccessPanelBtn_Click(object sender, EventArgs e)
        {
            nDTsTableAdapter.Insert(typeTxt.Text.Trim());
            RefreshData();
        }

        private void ndtsGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //new AccessPanelDetail(ndtsGridView.Rows[ndtsGridView.SelectedCells[0].RowIndex].Cells[0].Value.ToString()).Show();
        }

        private void ndtsGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                nDTsTableAdapter.DeleteByID(Convert.ToInt32(ndtsGridView.Rows[ndtsGridView.SelectedCells[0].RowIndex].Cells[0].Value));
            RefreshData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var taskndtadapter = new TaskNDTsTableAdapter())
            {
                nDTsTableAdapter.DeleteByID(Convert.ToInt32(ndtsGridView.Rows[ndtsGridView.SelectedCells[0].RowIndex].Cells[0].Value));
                try
                {
                    taskndtadapter.GetData().Where(x => x.NDTID == Convert.ToInt32(ndtsGridView.Rows[ndtsGridView.SelectedCells[0].RowIndex].Cells[0].Value)).ToList().ForEach(x => { taskndtadapter.DeleteByID(x.ID); });

                }
                catch (Exception)
                {

                    //throw;
                }
                RefreshData();
            }
        }
    }
}
