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
    public partial class frmAuctionCheckin : Form
    {
        public frmAuctionCheckin()
        {
            InitializeComponent();
        }

        public SQL SQLConnection;
        public SQLResult User;
        public string ID;

        public frmAuctionCheckin(string ID, SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            this.ID = ID;
            InitializeComponent();
        }



        private void frmAuctionCheckin_Load(object sender, EventArgs e)
        {
            if (User.getCellInt("class", 0) >= 7)
            {
                btnEdit.Enabled = true;
          
            }

            SQLConnection.LogAction("Loaded merch for artist #" + this.ID, this.User);
            MySqlCommand query = new MySqlCommand("SELECT ArtistID, ArtistName,ArtistAuctionCheckedIn FROM `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", this.ID);

            SQLResult results = this.SQLConnection.Query(query);

            lblArtistID.Text = results.getCell("ArtistID", 0);
            lblArtistName.Text = results.getCell("ArtistName", 0);


            if (results.getCellInt("ArtistAuctionCheckedIn", 0) == 1)
            {
                MessageBox.Show("This artist already checked in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCheckIn.Visible = false;
                chkArtSetup.Visible = false;
                chkBothSigned.Visible = false;
                chkListCorrect.Visible = false;
                btnEdit.Visible = false;
                btnRefresh.Visible = false;
                lblArtistID.Visible = false;
                lblArtistName.Visible = false;
                lblInstruction1.Visible = false;
                lblInstruction2.Visible = false;
                lblInstruction3.Visible = false;
                lblANNo.Visible = false;
                label1.Visible = false;
                picStop.Visible = true;
                lblStop.Visible = true;
                

            }
            else
            {
                btnCheckIn.Enabled = true;
            }


            // Now that the artist info is out of the way, let's grab his/her merch!
            lstMerch.Items.Clear();

            MySqlCommand merchData = new MySqlCommand("SELECT * FROM `merchandise` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            merchData.Prepare();
            merchData.Parameters.AddWithValue("@ID", this.ID);

            SQLResult merchResults = this.SQLConnection.Query(merchData);
            if (merchResults.GetNumberOfRows() > 0)
            {
                int i;
                for (i = 0; i < merchResults.GetNumberOfRows(); i++)
                {
                    ListViewItem newItem = new ListViewItem(merchResults.getCell("MerchID", i));
                    newItem.SubItems.Add(merchResults.getCell("MerchTitle", i));
                    newItem.SubItems.Add(merchResults.getCell("MerchMinBid", i));

                    if (merchResults.getCell("MerchAAMB", i) == "0")
                    {
                        newItem.SubItems.Add("No");
                    }
                    else
                    {
                        newItem.SubItems.Add("Yes");

                    }

                    if (merchResults.getCell("MerchQuickSale", i) == "0")
                    {
                        newItem.SubItems.Add("N/A");
                    }
                    else
                    {
                        newItem.SubItems.Add(merchResults.getCell("MerchQuickSale", i));
                    }

                    newItem.SubItems.Add(merchResults.getCell("MerchMedium", i));

                    lstMerch.Items.Add(newItem);
                }

            }





        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (!(chkArtSetup.Checked && chkBothSigned.Checked && chkListCorrect.Checked))
            {
                MessageBox.Show("Please make sure you followed all steps (In the specified order) in the list above. If not, I cannot allow you to Check In an Artist", "You missed something", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            MySqlCommand checkinQuery = new MySqlCommand("UPDATE `artists` SET `ArtistAuctionCheckedIn`=1 WHERE  `ArtistID`=@ID;", SQLConnection.GetConnection());
            checkinQuery.Prepare();
            checkinQuery.Parameters.AddWithValue("@ID", this.ID);
            SQLResult checkinQueryResults = this.SQLConnection.Query(checkinQuery);


            if (checkinQueryResults.successful())
            {
                MessageBox.Show("Artist marked as checked in for Auction!");
            }
            else
            {
                MessageBox.Show("Error checking in artist...");
            }

            //UPDATE `gallery`.`artists` SET `ArtistAuctionCheckedIn`=1 WHERE  `ArtistID`=0;
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmMerchEditor src2 = new frmMerchEditor(this.SQLConnection, this.User, int.Parse(this.ID));
            src2.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmAuctionCheckin_Load(sender, e);
        }

    }
}