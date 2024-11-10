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
    public partial class ToolsAndTesterDetail : Form
    {
        string _toolsAndTesterId;
        public ToolsAndTesterDetail(string toolsAndTester)
        {
            InitializeComponent();
            _toolsAndTesterId = toolsAndTester;
        }

        private void ToolsAndTestersDetail_Load(object sender, EventArgs e)
        {
            using (var toolsAndTesters = new Tools_And_TestersTableAdapter())
            {
                var toolsAndTester = toolsAndTesters.GetData().First(x => x.ID == Convert.ToInt32(_toolsAndTesterId));
                idtxt.Text = toolsAndTester.ID.ToString();
                table1IdTxt.Text = toolsAndTester.Table1ID.ToString();
                tatPartNoTxt.Text = toolsAndTester.PartNo;
                tatDescriptionTxt.Text = toolsAndTester.Description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var toolsAndTesters = new Tools_And_TestersTableAdapter())
            {
                toolsAndTesters.UpdateWithId(tatPartNoTxt.Text, tatDescriptionTxt.Text, Convert.ToInt32(table1IdTxt.Text), Convert.ToInt32(idtxt.Text));
                MessageBox.Show("Tool And Tester updated successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var toolsAndTesters = new Tools_And_TestersTableAdapter())
            {
                toolsAndTesters.Delete(Convert.ToInt32(idtxt.Text), tatPartNoTxt.Text, tatDescriptionTxt.Text, Convert.ToInt32(table1IdTxt.Text));
                MessageBox.Show("Tool And Tester deleted successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
