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
    public partial class ConsumableMaterialsDetail : Form
    {
        string _consumableMaterialsId;
        public ConsumableMaterialsDetail(string consumableMaterialsId)
        {
            InitializeComponent();
            _consumableMaterialsId = consumableMaterialsId;
        }

        private void ConsumableMaterialsDetail_Load(object sender, EventArgs e)
        {
            using (var consumableMaterials = new CunsumableMaterialsTableAdapter())
            {
                var consumableMaterial = consumableMaterials.GetData().First(x => x.ID == Convert.ToInt32(_consumableMaterialsId));
                idtxt.Text = consumableMaterial.ID.ToString();
                table1IdTxt.Text = consumableMaterial.Table1ID.ToString();
                partNoTxt.Text = consumableMaterial.PartNo;
                qTYTxt.Text = consumableMaterial.QTY;
                descriptionTxt.Text = consumableMaterial.Description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var consumableMaterials = new CunsumableMaterialsTableAdapter())
            {
                consumableMaterials.UpdateWithId(partNoTxt.Text, qTYTxt.Text, descriptionTxt.Text, "", Convert.ToInt32(table1IdTxt.Text), Convert.ToInt32(idtxt.Text));
                MessageBox.Show("Consumable Material updated successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var consumableMaterials = new CunsumableMaterialsTableAdapter())
            {
                consumableMaterials.Delete(Convert.ToInt32(idtxt.Text), partNoTxt.Text, qTYTxt.Text, descriptionTxt.Text, "", Convert.ToInt32(table1IdTxt.Text));
                MessageBox.Show("Consumable Material deleted successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
