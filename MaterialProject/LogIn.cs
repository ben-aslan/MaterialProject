using MaterialProject.MyDBDataSetTableAdapters;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MaterialProject
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var user = new UserTableAdapter())
            {
                var data = user.GetData();
                if (data.Any(x => x.UserName == textBox1.Text && x.UserPass == textBox2.Text) == false)
                {
                    MessageBox.Show("UserName or Password is incorrect!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (data.First(x => x.UserName == textBox1.Text && x.UserPass == textBox2.Text).Role == "1")
                {
                    this.Hide();
                    new Cars().Show();
                }
                else if (data.First(x => x.UserName == textBox1.Text && x.UserPass == textBox2.Text).Role == "2")
                {
                    this.Hide();
                    new UserCars().Show();
                }
                else
                {
                    MessageBox.Show("Error while getting datas!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
