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
    public partial class UserCars : Form
    {
        public UserCars()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Cast<TreeNode>().Any(x => x.Checked))
            {
                new UserHome(treeView1.Nodes.Cast<TreeNode>().Where(x => x.Checked).Select(x => Convert.ToInt32(x.ImageKey)).ToList()).Show();
                this.Close();
            }
            else
                MessageBox.Show("PLEASE SELECT BEFORE GETTING DETAILS", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshCars();
        }

        private void UserCars_Load(object sender, EventArgs e)
        {
            RefreshCars();
        }

        private void UserCars_Activated(object sender, EventArgs e)
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
    }
}
