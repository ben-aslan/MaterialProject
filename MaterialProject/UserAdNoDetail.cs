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

namespace MaterialProject
{
    public partial class UserAdNoDetail : Form
    {
        string _taskNo;
        List<int> _cars;

        public UserAdNoDetail(string taskNo, List<int> cars)
        {
            InitializeComponent();
            _taskNo = taskNo;
            _cars = cars;
        }

        private void UserAdNoDetail_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet.NDTs' table. You can move, or remove it, as needed.
            this.nDTsTableAdapter.Fill(this.myDBDataSet.NDTs);
            // TODO: This line of code loads data into the 'myDBDataSet.Part_Requirement' table. You can move, or remove it, as needed.
            this.part_RequirementTableAdapter.Fill(this.myDBDataSet.Part_Requirement);
            // TODO: This line of code loads data into the 'myDBDataSet.Tools_And_Testers' table. You can move, or remove it, as needed.
            this.tools_And_TestersTableAdapter.Fill(this.myDBDataSet.Tools_And_Testers);
            // TODO: This line of code loads data into the 'myDBDataSet.CunsumableMaterials' table. You can move, or remove it, as needed.
            this.cunsumableMaterialsTableAdapter.Fill(this.myDBDataSet.CunsumableMaterials);
            // TODO: This line of code loads data into the 'myDBDataSet.Access_Panel' table. You can move, or remove it, as needed.
            this.access_PanelTableAdapter.Fill(this.myDBDataSet.Access_Panel);
            RefreshData();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        async void RefreshData()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            using (var carTaskAdapter = new TaskCarsTableAdapter())
            {
                var tasks = carTaskAdapter.GetData().Where(x => _cars.Contains(x.CarID)).Select(x => x.TaskID).ToList();
                var task = new TaskTableAdapter().GetData().First(x => x.ADNo == _taskNo && tasks.Contains(x.ID));
                idtxt.Text = task.ID.ToString();
                //taskNotxt.Text = task.TaskNo;
                adNotxt.Text = task.ADNo;
                richTextBox1.Text = task.Remarks;
                richTextBox2.Text = task.NDTRemark;

                int id = task.ID;

                using (var accessPanel = new Access_PanelTableAdapter())
                    accessPanelGridView.DataSource = accessPanel.GetData().Where(x => x.Table1ID == id).ToList();
                using (var consumableMaterials = new CunsumableMaterialsTableAdapter())
                    consumableMaterialsGridView.DataSource = consumableMaterials.GetData().Where(x => x.Table1ID == id).ToList();
                using (var toolsAndTester = new Tools_And_TestersTableAdapter())
                    toolsAndTesterGridView.DataSource = toolsAndTester.GetData().Where(x => x.Table1ID == id).ToList();
                using (var partRequirement = new Part_RequirementTableAdapter())
                    partRequirementGridView.DataSource = partRequirement.GetData().Where(x => x.Table1ID == id).ToList();

                ndtGridView.DataSource = new SortableBindingList<MyDBDataSet.NDTsRow>(taskNDTsTableAdapter1.GetData().Where(x => x.TaskID == id).Select(x => nDTsTableAdapter.GetData().Where(ndt => ndt.ID == x.NDTID).Select(ndt => { ndt.ID = x.ID; return ndt; }).First()).ToList());
            }
        }

        public void Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
