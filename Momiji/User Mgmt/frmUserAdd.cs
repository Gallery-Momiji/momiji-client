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
    public partial class frmUserAdd : Form
    {


        public SQL SQLConnection;
        public SQLResult User;

        public frmUserAdd(SQL Link, SQLResult UserIdentifier)
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string usr, pass, pass2, name;
            usr = txtUsername.Text;
            pass = txtPassword.Text;
            pass2 = txtPasswordRetype.Text;
            name = txtFirstAndLast.Text;

            if (usr.Length == 0 || pass.Length == 0 ||
                 pass2.Length == 0 || name.Length == 0)
            {
                MessageBox.Show("One or more fields are empty.. Please make sure to fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (pass != pass2)
            {
                MessageBox.Show("Please make sure both the password and its retype match! I want to make sure you use the right password and that there is no typo!", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }


            // OK everything seems fine, now we check the database for this username! 

             MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @username;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@username", user);
            query.Parameters.AddWithValue("@password", pass);


            SQLResult results = this.SQLConnection.Query(query);
            if (results.GetNumberOfRows() == 1)
            {
                SQLConnection.LogAction("Logged In!", results);
                frmMenu menuInstance = new frmMenu(SQLConnection, results, this);
                this.Hide();
                menuInstance.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Sorry, but according to our records, these credentials are wrong, please double check them!", "Oh noes!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

            
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}