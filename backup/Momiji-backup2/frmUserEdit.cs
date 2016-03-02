using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Momiji
{
    public partial class frmUserEdit : Form
    {
        public SQL SQLConnection;
        public SQLResult User;
        public frmLogin LoginForm;
        SQLResult oldinfo;

        public frmUserEdit(SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void frmUserEdit_Load(object sender, EventArgs e)
        {
            lstUsers.Items.Clear();
            SQLConnection.LogAction("Is attempting to edit user information", this.User);
            MySqlCommand query = new MySqlCommand("SELECT `name` FROM `users`;", this.SQLConnection.GetConnection());
            query.Prepare();
            SQLConnection.LogAction("Queried DB for users", this.User);
            SQLResult results = this.SQLConnection.Query(query);
            if (results.GetNumberOfRows() == 0)
            {
                MessageBox.Show("This is weird... couldn't find any users? Call Tiago now!", "Huh?...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int i;
                for (i = 0; i < results.GetNumberOfRows(); i++)
                {
                    lstUsers.Items.Add(results.getCell("name", i));

                }

            }
            lstUsers.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oldinfo = null;
            string user = lstUsers.Items[lstUsers.SelectedIndex].ToString();
            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `name` = @NAME;", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@NAME", user);
            SQLConnection.LogAction("Queried DB for users", this.User);
            SQLResult results = this.SQLConnection.Query(query);
            if (results.successful())
            {
                SQLConnection.LogAction("Loaded info from user " + user, this.User);
                txtName.Text = results.getCell("name", 0);
                txtUsername.Text = results.getCell("username", 0);
                drpRank.SelectedIndex = results.getCellInt("class", 0) - 1;
                txtBanner.Text = results.getCell("banner", 0);
                oldinfo = results;
                txtPass1.Text = "";
                txtPass2.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newPassword = "";
            if (txtPass1.Text.Length != 0 || txtPass2.Text.Length != 0)
            {
                if (txtPass1.Text == txtPass2.Text)
                {
                    MD5 password = new MD5(txtPass1.Text);
                    newPassword = password.getShortHash();
                }
                else
                {
                    MessageBox.Show("Passwords don't match, try again", "Mismatch!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                newPassword = oldinfo.getCell("password", 0);

            }
            //UPDATE `gallery`.`users` SET `username`='newuser', `password`='newpass', `class`=456, `name`='newname', `banner`='newbanner' WHERE  `id`=34;
            MySqlCommand query = new MySqlCommand("UPDATE `users` SET `username`=@USER, `password`=@PASS, `class`=@RANK, `name`=@NAME, `banner`=@BANNER WHERE  `id`=@ID;", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@USER", txtUsername.Text);
            query.Parameters.AddWithValue("@PASS", newPassword);
            query.Parameters.AddWithValue("@RANK", drpRank.Items[drpRank.SelectedIndex]);
            query.Parameters.AddWithValue("@NAME", txtName.Text);
            query.Parameters.AddWithValue("@BANNER", txtBanner.Text);
            query.Parameters.AddWithValue("@ID", oldinfo.getCell("id",0));
            SQLConnection.LogAction("Updated info on user " + oldinfo.getCell("name",0), this.User);
            SQLResult results = this.SQLConnection.Query(query);
            if (results.successful())
            {
                MessageBox.Show("User updated successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUserEdit_Load(sender, e);
                button1_Click(sender, e);
            }
            else
            {
                MessageBox.Show("An error occured while updating the info on this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}