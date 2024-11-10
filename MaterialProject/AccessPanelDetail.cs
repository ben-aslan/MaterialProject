using MaterialProject.MyDBDataSetTableAdapters;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MaterialProject
{
    public partial class AccessPanelDetail : Form
    {
        string _accessPanelId;
        public AccessPanelDetail(string accessPanelId)
        {
            InitializeComponent();
            _accessPanelId = accessPanelId;
        }

        private void AccessPanelDetail_Load(object sender, EventArgs e)
        {
            using (var accessPanels = new Access_PanelTableAdapter())
            {
                var accessPanel = accessPanels.GetData().First(x => x.ID == Convert.ToInt32(_accessPanelId));
                idtxt.Text = accessPanel.ID.ToString();
                accessNoTxt.Text = accessPanel.AccessNo;
                table1IdTxt.Text = accessPanel.Table1ID.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var accessPanels = new Access_PanelTableAdapter())
            {
                accessPanels.UpdateWithId(accessNoTxt.Text, Convert.ToInt32(table1IdTxt.Text), Convert.ToInt32(idtxt.Text));
                MessageBox.Show("AccessNo updated successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var accessPanels = new Access_PanelTableAdapter())
            {
                accessPanels.Delete(Convert.ToInt32(idtxt.Text), accessNoTxt.Text, Convert.ToInt32(table1IdTxt.Text));
                MessageBox.Show("AccessNo deleted successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
