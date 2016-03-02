using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Momiji.User_Mgmt
{
    public partial class frmUserRemove : Form
    {

        public SQL SQLConnection;
        public SQLResult User;




        public frmUserRemove(SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void frmUserRemove_Load(object sender, EventArgs e)
        {
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
                for( i=0; i< results.GetNumberOfRows(); i++){
                    lstUsers.Items.Add(results.getCell("name", i));

                }

            }
            lstUsers.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("This is irreversible, ARE YOU SURE YOU WANT TO DO THIS?", "DANGER ZONE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                string user = lstUsers.Items[lstUsers.SelectedIndex].ToString();
                MySqlCommand query = new MySqlCommand("DELETE FROM `users` WHERE  `name`=@NAME;", this.SQLConnection.GetConnection());
                query.Prepare();
                query.Parameters.AddWithValue("@NAME", user);
                SQLResult results = this.SQLConnection.Query(query);
                if (results.successful())
                {
                    SQLConnection.LogAction("Deleted user " + user, this.User);
                    MessageBox.Show("User Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstUsers.Items.Clear();
                    this.frmUserRemove_Load(sender, e);
                }
            }
        }
    }
}