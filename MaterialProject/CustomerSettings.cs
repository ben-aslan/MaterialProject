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
    public partial class CustomerSettings : Form
    {
        public CustomerSettings()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var userTable = new UserTableAdapter())
            {
                var users = userTable.GetData().ToList();
                if (!users.Any(x => x.UserName.ToLower() == "admin" && x.UserPass == adminOldPassTxt.Text))
                {
                    MessageBox.Show("Password is incorrect!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (adminNewPassTxt.Text != adminConfirmTxt.Text)
                {
                    MessageBox.Show("Confirm password doesn't match!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var admin = users.First(x => x.UserName.ToLower() == "admin" && x.UserPass == adminOldPassTxt.Text);
                userTable.UpdateWithId(admin.UserName, adminNewPassTxt.Text, admin.Role, admin.ID);
                MessageBox.Show("Admin password updated successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var userTable = new UserTableAdapter())
            {
                var users = userTable.GetData().ToList();
                if (!users.Any(x => x.UserName.ToLower() == "user" && x.UserPass == userOldPassTxt.Text))
                {
                    MessageBox.Show("Password is incorrect!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (userNewPassTxt.Text != userConfirmPassTxt.Text)
                {
                    MessageBox.Show("Confirm password doesn't match!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var user = users.First(x => x.UserName.ToLower() == "user" && x.UserPass == userOldPassTxt.Text);
                userTable.UpdateWithId(user.UserName, userNewPassTxt.Text, user.Role, user.ID);
                MessageBox.Show("User password updated successfully!".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
