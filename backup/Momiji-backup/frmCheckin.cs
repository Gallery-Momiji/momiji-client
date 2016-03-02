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
    public partial class frmCheckin : Form
    {

        public SQL SQLConnection;
        public SQLResult User;
        public string ArtistID;
        public SQLResult ArtistInfo;

        public frmCheckin(string ArtistID, SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            this.ArtistID = ArtistID;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmCheckin_Load(object sender, EventArgs e)
        {
            lstMerch.Items.Clear();
            lstGSMerch.Items.Clear();



            MySqlCommand update = new MySqlCommand("SELECT `ArtistCheckIn` FROM `artists` WHERE `ArtistID`=@ID", SQLConnection.GetConnection());
            update.Prepare();
            update.Parameters.AddWithValue("@ID", ArtistID);

            SQLResult result = this.SQLConnection.Query(update);
            
            if (result.getCell("ArtistCheckIn", 0) == "True")
            {
                MessageBox.Show("This artist already checked in!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCheckIn.Enabled = false;

            }





            MySqlCommand merchData = new MySqlCommand("SELECT * FROM `merchandise` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            merchData.Prepare();
            merchData.Parameters.AddWithValue("@ID", ArtistID);

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


            MySqlCommand GSmerchData = new MySqlCommand("SELECT * FROM `GSmerchandise` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            GSmerchData.Prepare();
            GSmerchData.Parameters.AddWithValue("@ID", ArtistID.ToString());

            SQLResult GSmerchResults = this.SQLConnection.Query(GSmerchData);
            if (GSmerchResults.GetNumberOfRows() > 0)
            {
                int i;
                for (i = 0; i < GSmerchResults.GetNumberOfRows(); i++)
                {
                    ListViewItem newItem = new ListViewItem(GSmerchResults.getCell("PieceID", i));
                    newItem.SubItems.Add(GSmerchResults.getCell("PieceTitle", i));
                    newItem.SubItems.Add(GSmerchResults.getCell("PieceInitialStock", i));
                    newItem.SubItems.Add(GSmerchResults.getCell("PieceStock", i));
                    newItem.SubItems.Add(GSmerchResults.getCell("PiecePrice", i));

                    lstGSMerch.Items.Add(newItem);
                }


            }


        }

        private void btnEditArtist_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                frmMerchEditor edit = new frmMerchEditor(this.SQLConnection, this.User, Int32.Parse(this.ArtistID));
                edit.Show();

            }
            else
            {
                frmGSManager edit = new frmGSManager(this.ArtistID, SQLConnection, User);
                edit.Show();


            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            frmCheckin_Load(sender, e);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            //ArtistCheckIn
            //;
            MySqlCommand update = new MySqlCommand("UPDATE `artists` SET `ArtistCheckIn`=1 WHERE  `ArtistID`=@ID", SQLConnection.GetConnection());
            update.Prepare();
            update.Parameters.AddWithValue("@ID", ArtistID);

            SQLResult result = this.SQLConnection.Query(update);
            if (result.successful())
            {
                MessageBox.Show("Artist checked in!", "WOOHOO!");
            }
            else
            {
                MessageBox.Show("Error processing Artist Check In!", "O NOES");
            }

            this.Dispose();
        }



   
    }
}