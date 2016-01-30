using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Momiji
{
    
    public partial class frmLogin : Form
    {


        SQL SQLConnection;
       
        public void frmLogin_Load(object sender, EventArgs e)
        {
            lblSqlStatus.Text = "Connecting...";
            
            SQLConnection = new SQL("gallery", "animenorthdanitiago", "192.168.1.3", "gallery", 3306);
            if (SQLConnection.GetState() != 1)
            {
                lblSqlStatus.ForeColor = Color.Red;
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
                btnRetry.Enabled = false;
                lblSqlStatus.ForeColor = Color.Green;
              
            }
            
            lblSqlStatus.Text = SQLConnection.GetErrorMessage();

            txtUsername.Focus();

        }


        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string pass = txtPassword.Text;
            string user = txtUsername.Text;

            if (pass.Length == 0 || user.Length == 0)
            {
                MessageBox.Show("Please make sure to use an Username AND password! Can't have strangers connecting to our server, now can we?", "Uh oh..", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            MD5 passhash = new MD5(pass);

            pass = passhash.hash.Substring(0, 8).ToLower();

            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @username AND `password` = @password;", SQLConnection.GetConnection());
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



        public bool IsHex(string data)
        {
            return Regex.IsMatch(data, "^([A-Fa-f0-9]+)$");

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (btnLogin.Enabled) {
                    this.btnLogin_Click(sender, e);

                }

            }
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            frmLogin_Load(sender, e);
        }



  

 


      
    }
}
