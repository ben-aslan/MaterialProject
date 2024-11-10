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
using static MaterialProject.MyDBDataSet;

namespace MaterialProject
{
    public partial class TaskDetails : Form
    {
        string _taskId;
        public TaskDetails(string taskId)
        {
            InitializeComponent();
            _taskId = taskId;
        }

        private void TaskDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet2.NDTs' table. You can move, or remove it, as needed.
            //this.nDTsTableAdapter.Fill(this.myDBDataSet2.NDTs);
            // TODO: This line of code loads data into the 'myDBDataSet2.Part_Requirement' table. You can move, or remove it, as needed.
            this.part_RequirementTableAdapter.Fill(this.myDBDataSet2.Part_Requirement);
            // TODO: This line of code loads data into the 'myDBDataSet2.Tools_And_Testers' table. You can move, or remove it, as needed.
            this.tools_And_TestersTableAdapter.Fill(this.myDBDataSet2.Tools_And_Testers);
            // TODO: This line of code loads data into the 'myDBDataSet2.CunsumableMaterials' table. You can move, or remove it, as needed.
            this.cunsumableMaterialsTableAdapter.Fill(this.myDBDataSet2.CunsumableMaterials);
            // TODO: This line of code loads data into the 'myDBDataSet2.Access_Panel' table. You can move, or remove it, as needed.
            this.access_PanelTableAdapter.Fill(this.myDBDataSet2.Access_Panel);
            // TODO: This line of code loads data into the 'myDBDataSet1.Part_Requirement' table. You can move, or remove it, as needed.
            this.part_RequirementTableAdapter.Fill(this.myDBDataSet1.Part_Requirement);
            // TODO: This line of code loads data into the 'myDBDataSet1.Tools_And_Testers' table. You can move, or remove it, as needed.
            this.tools_And_TestersTableAdapter.Fill(this.myDBDataSet1.Tools_And_Testers);
            // TODO: This line of code loads data into the 'myDBDataSet1.CunsumableMaterials' table. You can move, or remove it, as needed.
            this.cunsumableMaterialsTableAdapter.Fill(this.myDBDataSet1.CunsumableMaterials);
            // TODO: This line of code loads data into the 'myDBDataSet.Access_Panel' table. You can move, or remove it, as needed.
            this.access_PanelTableAdapter.Fill(this.myDBDataSet.Access_Panel);
            using (var tasks = new TaskTableAdapter())
            {
                var task = tasks.GetData().First(x => x.ID == Convert.ToInt32(_taskId));
                idtxt.Text = task.ID.ToString();
                taskNotxt.Text = task.TaskNo;
                richTextBox1.Text = task.Remarks;
                richTextBox2.Text = task.NDTRemark;
                //adNotxt.Text = task.ADNo;
            }
            using (var accessPanel = new Access_PanelTableAdapter())
                accessPanelGridView.DataSource = new SortableBindingList<MyDBDataSet.Access_PanelRow>(accessPanel.GetData().Where(x => x.Table1ID == Convert.ToInt32(_taskId)).ToList());
            using (var consumableMaterials = new CunsumableMaterialsTableAdapter())
                consumableMaterialsGridView.DataSource = new SortableBindingList<MyDBDataSet.CunsumableMaterialsRow>(consumableMaterials.GetData().Where(x => x.Table1ID == Convert.ToInt32(_taskId)).ToList());
            using (var toolsAndTester = new Tools_And_TestersTableAdapter())
                toolsAndTesterGridView.DataSource = new SortableBindingList<MyDBDataSet.Tools_And_TestersRow>(toolsAndTester.GetData().Where(x => x.Table1ID == Convert.ToInt32(_taskId)).ToList());
            using (var partRequirement = new Part_RequirementTableAdapter())
                partRequirementGridView.DataSource = new SortableBindingList<MyDBDataSet.Part_RequirementRow>(partRequirement.GetData().Where(x => x.Table1ID == Convert.ToInt32(_taskId)).ToList());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var tasks = new TaskTableAdapter())
            {
                tasks.UpdateWithId(taskNotxt.Text, "", richTextBox1.Text, richTextBox2.Text, Convert.ToInt32(idtxt.Text));
                MessageBox.Show("Task updated successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var tasks = new TaskTableAdapter())
            {
                tasks.Delete(Convert.ToInt32(idtxt.Text), taskNotxt.Text, "");
                MessageBox.Show("Task deleted successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void addAccessPanelBtn_Click(object sender, EventArgs e)
        {
            using (var accessPanel = new Access_PanelTableAdapter())
            {
                accessPanel.Insert(accessNoTxt.Text, Convert.ToInt32(idtxt.Text));
                RefreshData();
            }
        }

        private void addConsumableMaterial_Click(object sender, EventArgs e)
        {
            using (var consumableMaterial = new CunsumableMaterialsTableAdapter())
            {
                consumableMaterial.Insert(partNoTxt.Text, qTYTxt.Text, descriptionTxt.Text, "", Convert.ToInt32(idtxt.Text));
                RefreshData();
            }
        }

        private void toolsandtestersAddBtn_Click(object sender, EventArgs e)
        {
            using (var toolsAndTester = new Tools_And_TestersTableAdapter())
            {
                toolsAndTester.Insert(tatPartNoTxt.Text, tatDescriptionTxt.Text, Convert.ToInt32(idtxt.Text));
                RefreshData();
            }
        }

        private void partRequirementAddBtn_Click(object sender, EventArgs e)
        {
            using (var partRequirement = new Part_RequirementTableAdapter())
            {
                partRequirement.Insert(prPartNoTxt.Text, prQTYTxt.Text, prDescription.Text, Convert.ToInt32(idtxt.Text));
                RefreshData();
            }
        }

        private void accessPanelGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new AccessPanelDetail(accessPanelGridView.Rows[accessPanelGridView.SelectedCells[0].RowIndex].Cells[0].Value.ToString()).Show();
        }

        private void consumableMaterialsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new ConsumableMaterialsDetail(consumableMaterialsGridView.Rows[consumableMaterialsGridView.SelectedCells[0].RowIndex].Cells[0].Value.ToString()).Show();
        }

        private void toolsAndTesterGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new ToolsAndTesterDetail(toolsAndTesterGridView.Rows[toolsAndTesterGridView.SelectedCells[0].RowIndex].Cells[0].Value.ToString()).Show();
        }

        private void partRequirementGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new PartRequirementDetail(partRequirementGridView.Rows[partRequirementGridView.SelectedCells[0].RowIndex].Cells[0].Value.ToString()).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void TaskDetails_Activated(object sender, EventArgs e)
        {
            RefreshData();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        async void RefreshData()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            accessPanelGridView.DataSource = new SortableBindingList<MyDBDataSet.Access_PanelRow>(access_PanelTableAdapter.GetData().Where(x => x.Table1ID == Convert.ToInt32(_taskId)).ToList());
            using (var consumableMaterials = new CunsumableMaterialsTableAdapter())
                consumableMaterialsGridView.DataSource = new SortableBindingList<MyDBDataSet.CunsumableMaterialsRow>(consumableMaterials.GetData().Where(x => x.Table1ID == Convert.ToInt32(_taskId)).ToList());
            toolsAndTesterGridView.DataSource = new SortableBindingList<MyDBDataSet.Tools_And_TestersRow>(tools_And_TestersTableAdapter.GetData().Where(x => x.Table1ID == Convert.ToInt32(_taskId)).ToList());
            partRequirementGridView.DataSource = new SortableBindingList<MyDBDataSet.Part_RequirementRow>(part_RequirementTableAdapter.GetData().Where(x => x.Table1ID == Convert.ToInt32(_taskId)).ToList());
            //ndtGridView.DataSource = new SortableBindingList<MyDBDataSet.NDTsRow>(taskNDTsTableAdapter1.GetData().Where(x => x.TaskID.ToString() == _taskId).Select(x => { var data = nDTsTableAdapter.GetData().Where(ndt => ndt.ID == x.NDTID).ToList(); int counter = 10000000; data.ForEach(dt => { dt.ID = counter; counter++; }); var finaldata = data.First(); finaldata.ID = x.ID; return finaldata; }).ToList());
            ndtGridView.DataSource = new SortableBindingList<MyDBDataSet.NDTsRow>(taskNDTsTableAdapter1.GetData().Where(x => x.TaskID.ToString() == _taskId).Select(x => nDTsTableAdapter.GetData().Where(ndt => ndt.ID == x.NDTID).Select(ndt => { ndt.ID = x.ID; return ndt; }).First()).ToList());
            typeComboBox.Items.Clear();
            typeComboBox.Items.AddRange(nDTsTableAdapter.GetData().Select(x => new ComboSelect { Name = x.Type, Value = x.ID }).ToArray());
            typeComboBox.DisplayMember = "Name";
            typeComboBox.ValueMember = "Value";
        }

        private void accessPanelGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                access_PanelTableAdapter.DeleteByID(Convert.ToInt32(accessPanelGridView.Rows[accessPanelGridView.SelectedCells[0].RowIndex].Cells[0].Value));
            RefreshData();
        }

        private void consumableMaterialsGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cunsumableMaterialsTableAdapter.DeleteByID(Convert.ToInt32(consumableMaterialsGridView.Rows[consumableMaterialsGridView.SelectedCells[0].RowIndex].Cells[0].Value));
            RefreshData();
        }

        private void toolsAndTesterGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                tools_And_TestersTableAdapter.DeleteByID(Convert.ToInt32(toolsAndTesterGridView.Rows[toolsAndTesterGridView.SelectedCells[0].RowIndex].Cells[0].Value));
            RefreshData();
        }

        private void partRequirementGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                part_RequirementTableAdapter.DeleteByID(Convert.ToInt32(partRequirementGridView.Rows[partRequirementGridView.SelectedCells[0].RowIndex].Cells[0].Value));
            RefreshData();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                taskNDTsTableAdapter1.Insert(Convert.ToInt32(_taskId), ((ComboSelect)typeComboBox.SelectedItem).Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Please select type!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                RefreshData();
            }
        }

        private void ndtGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                taskNDTsTableAdapter1.DeleteByID(Convert.ToInt32(ndtGridView.Rows[ndtGridView.SelectedCells[0].RowIndex].Cells[0].Value));
            RefreshData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                richTextBox1.Text += (string)Clipboard.GetData("Text");
                e.Handled = true;
            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                richTextBox2.Text += (string)Clipboard.GetData("Text");
                e.Handled = true;
            }
        }
    }
}
