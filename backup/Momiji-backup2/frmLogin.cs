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
        string db_pass, db_user, db_name, db_host, db_port;
     
        public void frmLogin_Load(object sender, EventArgs e)
        {
            
            try
            {
                IniParser config = new IniParser(@"config.ini");
                string[] databases = new string[20];
                databases = config.GetSetting("ROOT", "databases").Split(',');

               
                if (cbDatabases.Items.Count != 0)
                {
                    string new_db = cbDatabases.Items[cbDatabases.SelectedIndex].ToString();
                    db_pass = config.GetSetting(new_db, "db_pass");
                    db_user = config.GetSetting(new_db, "db_user");
                    db_name = config.GetSetting(new_db, "db_name");
                    db_host = config.GetSetting(new_db, "db_host");
                    db_port = config.GetSetting(new_db, "db_port");

                }
                else
                {
                    foreach (string element in databases)
                    {

                        cbDatabases.Items.Add(element);
                        cbDatabases.SelectedIndex = 0;
                        if (config.GetSetting(element, "default") == "1")
                        {
                            db_pass = config.GetSetting(element, "db_pass");
                            db_user = config.GetSetting(element, "db_user");
                            db_name = config.GetSetting(element, "db_name");
                            db_host = config.GetSetting(element, "db_host");
                            db_port = config.GetSetting(element, "db_port");

                        }


                    }

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", exiting..." );
                Application.Exit();

            }
            this.Text = "Gallery Momiji P.O.S. V" + Application.ProductVersion.ToString() + " (D.A.V.E.)";
            lblConnStatus.Text = "Connecting...";

            SQLConnection = new SQL(db_user, db_pass, db_host, db_name, db_port);

            if (SQLConnection.GetState() != 1)
            {
                lblConnStatus.ForeColor = Color.Red;
                lblDatabaseConnected.Text = "None [ERROR]";
                lblConnStatus.Text = SQLConnection.GetErrorMessage().Substring(0, 60);  // more characters and nothing shows up...
                
            }
            else
            {
                lblConnStatus.ForeColor = Color.Green;
                lblDatabaseConnected.Text = db_name;
                lblConnStatus.Text = "OK";
            }

            

            this.ActiveControl = txtUsername;
            SQLConnection.Close();
          
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string pass = txtPassword.Text;
            string user = txtUsername.Text;

            if (user.Length == 0)
            {
                MessageBox.Show("Please specify a username.", "Missing Username", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (pass.Length == 0)
            {
                MessageBox.Show("Please specify a password.", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            MD5 passhash = new MD5(pass);

            pass = passhash.getShortHash();

            //Use a fresh connection for login

            SQLConnection = new SQL(db_user, db_pass, db_host, db_name, db_port);
            lblConnStatus.Text = SQLConnection.GetErrorMessage();

            if (SQLConnection.GetState() != 1)
            {//if a new connection fails
                lblConnStatus.ForeColor = Color.Red;
                btnLogin.Enabled = false;
                btnRetry.Enabled = true;
                return;
            }

            MySqlCommand query = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @username AND `password` = @password;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@username", user);
            query.Parameters.AddWithValue("@password", pass);

            SQLResult results = this.SQLConnection.Query(query);
            if (results.GetNumberOfRows() == 1)
            {
                //Clear the form
                txtPassword.Text = "";
                txtUsername.Text = "";
                this.ActiveControl = txtUsername;
                //Log in user
                SQLConnection.LogAction("Logged In!", results);
                frmMenu menuInstance = new frmMenu(SQLConnection, results, this);
                this.Hide();
                menuInstance.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect password or username. Please try again.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            cbDatabases.Items.Clear();
            frmLogin_Load(sender, e);
        }

        private void lblConnStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SQLConnection.GetErrorMessage());
        }


    }
}
