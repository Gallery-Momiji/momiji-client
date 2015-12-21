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
    public partial class frmArtistCheckinGallery : Form
    {

        public SQL SQLConnection;
        public SQLResult User;
        public string ID;

        public frmArtistCheckinGallery(string ID, SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            this.ID = ID;
            InitializeComponent();
        }

        private void frmArtistCheckinGallery_Load(object sender, EventArgs e)
        {
            if (User.getCellInt("class", 0) >= 7)
            {
                btnEdit.Enabled = true;
            }

            SQLConnection.LogAction("Loaded GS merch for artist #" + ID, this.User);
            MySqlCommand query = new MySqlCommand("SELECT ArtistName, ArtistGSCheckedIn FROM `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", ID);

            SQLResult results = this.SQLConnection.Query(query);

            lblArtistID.Text = ID;
            lblArtistName.Text = results.getCell("ArtistName", 0);

            if (results.getCellInt("ArtistGSCheckedIn", 0) == 1)
            {
                MessageBox.Show("This artist already checked in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                chkBinder.Visible = false;
                chkGSCS.Visible = false;
                chkMatch.Visible = false;
                btnCheckIn.Visible = false;
                btnEdit.Visible = false;
                btnRefresh.Visible = false;
                picStop.Visible = true;
                lblStop.Visible = true;
            }


            // Now that the artist info is out of the way, let's grab his/her merch!
            lstMerch.Items.Clear();

            MySqlCommand merchData = new MySqlCommand("SELECT * FROM `gsmerchandise` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            merchData.Prepare();
            merchData.Parameters.AddWithValue("@ID", ID);

            SQLResult merchResults = this.SQLConnection.Query(merchData);
            if (merchResults.GetNumberOfRows() > 0)
            {
                int i;
                for (i = 0; i < merchResults.GetNumberOfRows(); i++)
                {

                    ListViewItem newItem = new ListViewItem(merchResults.getCell("PieceID", i));
                    newItem.SubItems.Add(merchResults.getCell("PieceTitle", i));
                    newItem.SubItems.Add(merchResults.getCell("PieceInitialStock", i));
                    newItem.SubItems.Add(merchResults.getCell("PieceStock", i));
                    newItem.SubItems.Add(merchResults.getCell("PiecePrice", i));
                    newItem.SubItems.Add((merchResults.getCell("PieceSDC", i) == "False" ? "NO" : "YES"));
                    lstMerch.Items.Add(newItem);
                }

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmArtistCheckinGallery_Load(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblArtistName_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmGSManager manager = new frmGSManager(ID, SQLConnection, User);
            manager.Show();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (chkBinder.Checked && chkGSCS.Checked && chkMatch.Checked)
            {
                MySqlCommand checkinQuery = new MySqlCommand("UPDATE `artists` SET `ArtistGSCheckedIn`=1 WHERE  `ArtistID`=@ID;", SQLConnection.GetConnection());
                checkinQuery.Prepare();
                checkinQuery.Parameters.AddWithValue("@ID", this.ID);
                SQLResult checkinQueryResults = this.SQLConnection.Query(checkinQuery);


                if (checkinQueryResults.successful())
                {
                    MessageBox.Show("Artist marked as checked in for Gallery Store!");
                }
                else
                {
                    MessageBox.Show("Error checking in artist...");
                }
            }
            else
            {

                MessageBox.Show("Please make sure you followed all steps (In the specified order) in the list above. If not, I cannot allow you to Check In an Artist", "You missed something", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}