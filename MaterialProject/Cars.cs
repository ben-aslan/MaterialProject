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
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
        }

        private void Cars_Load(object sender, EventArgs e)
        {
            RefreshCars();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        async void RefreshCars()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            using (var carAdapter = new CarsTableAdapter())
            {
                treeView1.BeginUpdate();
                treeView1.Nodes.Cast<TreeNode>().ToList().ForEach(x => x.Remove());
                foreach (var car in carAdapter.GetData())
                {
                    treeView1.Nodes.Add(car.ID.ToString(), car.NAME, car.ID.ToString());
                }
                treeView1.EndUpdate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var carAdapter = new CarsTableAdapter())
            {
                carAdapter.Insert(nameTxt.Text);
                RefreshCars();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Cast<TreeNode>().Any(x => x.Checked))
            {
                new Home(treeView1.Nodes.Cast<TreeNode>().Where(x => x.Checked).Select(x => Convert.ToInt32(x.ImageKey)).ToList()).Show();
                this.Close();
            }
            else
                MessageBox.Show("PLEASE SELECT BEFORE GETTING DETAILS", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var carAdapter = new CarsTableAdapter())
                treeView1.Nodes.Cast<TreeNode>().Where(x => x.Checked).ToList().ForEach((x) => { carAdapter.Delete(Convert.ToInt32(x.ImageKey), x.Text); });
            RefreshCars();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshCars();
        }

        private void Cars_Activated(object sender, EventArgs e)
        {
            RefreshCars();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Cast<TreeNode>().ToList().ForEach(x => x.Checked = true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Cast<TreeNode>().ToList().ForEach(x => x.Checked = false);
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                using (var carAdapter = new CarsTableAdapter())
                    treeView1.Nodes.Cast<TreeNode>().Where(x => x.Checked).ToList().ForEach((x) => { carAdapter.Delete(Convert.ToInt32(x.ImageKey), x.Text); });
            RefreshCars();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new NdtHome().Show();
        }
    }
}
