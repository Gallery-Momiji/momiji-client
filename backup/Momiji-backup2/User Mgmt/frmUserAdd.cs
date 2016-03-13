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
            // Same old stuff, carry the SQL Connection from the parent form, put it here for easy reference.
            this.SQLConnection = Link;

            // And a user Identifier (Basically, user info returned from the DB)
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string userName, password1, password2 , userFnameLname;
            userName = txtUsername.Text;
            password1 = txtPassword.Text;
            password2 = txtPasswordRetype.Text;
            userFnameLname = txtFirstAndLast.Text;
            string userClass = drpRank.Text;

            if (userName.Length == 0 || password1.Length == 0 ||
                 password2.Length == 0 || userFnameLname.Length == 0)
            {
                MessageBox.Show("One or more fields are empty.. Please make sure to fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (password1 != password2)
            {
                MessageBox.Show("Please make sure both the password and its retype match! I want to make sure you use the right password and that there is no typo!", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            // OK everything seems fine, now we check the database for this username! 

            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @username;", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@username", userName);

            SQLResult results = this.SQLConnection.Query(query);
            if (results.GetNumberOfRows() == 1)
            {
                MessageBox.Show("This username already exists!", "Found this username in Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Username duplication checked, passwords checked, name checked. time to put all of this stuff onto the DB!
            // First, MD5 the password:

            MD5 passHash = new MD5(password1);

            query = new MySqlCommand("INSERT INTO `users` (`username`, `password`, `class`, `name`) VALUES (@username, @password, @class, @name);", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@username", userName);
            query.Parameters.AddWithValue("@password", passHash.getShortHash());
            query.Parameters.AddWithValue("@class", userClass);
            query.Parameters.AddWithValue("@name", userFnameLname);
            results = this.SQLConnection.Query(query);

            if (results.successful())
            {
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFirstAndLast.Text = "";
                txtPassword.Text = "";
                txtPasswordRetype.Text = "";
                txtUsername.Text = "";

                drpRank.SelectedIndex = 0;


            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserAdd_Load(object sender, EventArgs e)
        {

        }

        
    }
}
