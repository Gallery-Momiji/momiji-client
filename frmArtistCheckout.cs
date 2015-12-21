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
    public partial class frmArtistCheckout : Form
    {
        public SQL SQLConnection;
        public SQLResult User;
        public string ID;

        public frmArtistCheckout(string ID, SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            this.ID = ID;
            InitializeComponent();
        }

        private void frmArtistCheckout_Load(object sender, EventArgs e)
        {
            MySqlCommand query = new MySqlCommand("SELECT ArtistID, ArtistName,ArtistCheckedOut FROM `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", this.ID);

            SQLResult results = this.SQLConnection.Query(query);
            if (results.successful())
            {
                if (results.getCellInt("ArtistCheckedOut", 0) == 1)
                {
                    button2.Enabled = false;
                    MessageBox.Show("Artist already marked as Checked Out", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                lblArtistID.Text = results.getCell("ArtistID", 0);
                lblArtistName.Text = results.getCell("ArtistName", 0);
            }
            else
            {
                MessageBox.Show("An error occured finding this Artists' details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
         //   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will now redirect you to a browser window.");
            System.Diagnostics.Process.Start("http://" + SQLConnection.getHost() + "/momiji/checkout.php?id=" + ID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chkStep1.Checked && chkStep2.Checked && chkStep3.Checked)
            {

                MySqlCommand checkinQuery = new MySqlCommand("UPDATE `artists` SET `ArtistCheckedOut`=1 WHERE  `ArtistID`=@ID;", SQLConnection.GetConnection());
                checkinQuery.Prepare();
                checkinQuery.Parameters.AddWithValue("@ID", this.ID);
                SQLResult checkinQueryResults = this.SQLConnection.Query(checkinQuery);


                if (checkinQueryResults.successful())
                {
                    MessageBox.Show("Artist marked as Checked Out!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error Checking Out artist...");
                }
            }
            else
            {
                MessageBox.Show("Please make sure you followed all steps (In the specified order) in the list above. If not, I cannot allow you to Check Out an Artist", "You missed something", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}