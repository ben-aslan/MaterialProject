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
    public partial class PartRequirementDetail : Form
    {
        string _partRequirementId;
        public PartRequirementDetail(string partRequirementId)
        {
            InitializeComponent();
            _partRequirementId = partRequirementId;
        }

        private void PartRequirementDetail_Load(object sender, EventArgs e)
        {
            using (var partRequirements = new Part_RequirementTableAdapter())
            {
                var partRequirement = partRequirements.GetData().First(x => x.ID == Convert.ToInt32(_partRequirementId));
                idtxt.Text = partRequirement.ID.ToString();
                table1IdTxt.Text = partRequirement.Table1ID.ToString();
                prPartNoTxt.Text = partRequirement.PartNo;
                prQTYTxt.Text = partRequirement.QTY;
                prDescription.Text = partRequirement.Description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var partRequirements = new Part_RequirementTableAdapter())
            {
                partRequirements.UpdateWithId(prPartNoTxt.Text, prQTYTxt.Text, prDescription.Text, Convert.ToInt32(table1IdTxt.Text), Convert.ToInt32(idtxt.Text));
                MessageBox.Show("Part Requirement updated successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var partRequirements = new Part_RequirementTableAdapter())
            {
                partRequirements.Delete(Convert.ToInt32(idtxt.Text), prPartNoTxt.Text, prQTYTxt.Text, prDescription.Text, Convert.ToInt32(table1IdTxt.Text));
                MessageBox.Show("Part Requirement deleted successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
