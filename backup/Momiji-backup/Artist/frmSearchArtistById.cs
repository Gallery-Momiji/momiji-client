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
    public partial class frmSearchArtistById : Form
    {

        // 0 - Edit Artist
        // 1 - Delete Artist
        // 2 - Edit Artist's Merchandise
        // 3 - Mass-Gen Bidding Sheets
        // 4 - Manage Artist's payment / space allocation
        // 5 - checkin
        // 6 - Manage Gallery store stock

        public int operation = 0;
        public SQL SQLConnection;
        public SQLResult User;


        public frmSearchArtistById(int operation, SQL Link, SQLResult UserIdentifier)
        {
            this.operation = operation;
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private bool isNumeric(string num)
        {
            string numString = num;
            long number1 = 0;
            float num2 = 0;
            bool canConvert = long.TryParse(numString, out number1);
            bool convert2 = float.TryParse(numString, out num2);
            return canConvert || convert2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!isNumeric(txtName.Text) || txtName.Text.Length == 0 )
            {
                MessageBox.Show("Please make sure a number is entered at the input field!", "Invalid input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            lstArtists.Items.Clear();

            string action = "Searched for artist " + txtName.Text + " With the intent of ";
            switch (this.operation)
            {
                case 1:
                    action = action + "deleting the artist!";
                    break;
                case 0:
                    action = action + "editing the artist!";
                    break;
                case 2:
                    action = action + "editing what the artist is selling";
                    break;
                case 3:
                    action = action + "mass generating the bidding sheets of an Artist";
                    break;
                case 4:
                    action = action + "managing the payment and/or space allocation of an Artist";
                    break;
                case 5:
                    action = action + "checking in";
                    break;
            }

            SQLConnection.LogAction(action, this.User);
            MySqlCommand query = new MySqlCommand("SELECT ArtistID, ArtistName FROM `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", txtName.Text);

            SQLResult results = this.SQLConnection.Query(query);

            if (results.GetNumberOfRows() >= 1)
            {
                int i;
                for (i = 0; i < results.GetNumberOfRows(); i++)
                {

                    ListViewItem newItem = new ListViewItem(results.getCell("ArtistID", i));
                    newItem.SubItems.Add(results.getCell("ArtistName", i));


                    lstArtists.Items.Add(newItem);
                }

            }
            else
            {
                MessageBox.Show("Couldn't find anyone with this ID. Kinda lonely, huh?", "[tumbleweed rolling intensifies]", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void lstArtists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            int id = Int32.Parse(lstArtists.SelectedItems[0].Text);

            switch (this.operation)
            {
                case 0:
                    frmArtistAdd src = new frmArtistAdd(this.SQLConnection, this.User, this.operation, id);
                    src.Show();
                    break;
                case 1:
                    DialogResult del1 = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE ARTIST AN#" + lstArtists.SelectedItems[0].Text + "?", "WARNING!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (del1 == DialogResult.Yes)
                    {
                        DialogResult del2 = MessageBox.Show("LAST WARNING! NO TURNING BACK! ONCE THIS ARTIST IS GONE THERE IS NO RESTORING!", "LAST WARNING!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (del2 == DialogResult.Yes)
                        {
                            MessageBox.Show("Deleting the artist! Don't say I didn't make sure!");

                            MySqlCommand query = new MySqlCommand("DELETE FROM `artists` WHERE  `ArtistID`= @ID;", SQLConnection.GetConnection());
                            query.Prepare();
                            query.Parameters.AddWithValue("@ID", id);

                            SQLResult results = this.SQLConnection.Query(query);
                            SQLConnection.LogAction("Deleted artist #" + id.ToString(), this.User);
                            this.button1_Click(sender, e);
                        }
                    }
                    break;
                case 2:
                    frmMerchEditor src2 = new frmMerchEditor(this.SQLConnection, this.User, id);
                    src2.Show();
                    break;
                case 3:
                    biddingsheet bid = new biddingsheet(id.ToString(), this.SQLConnection, this.User);
                    bid.process();
                    break;

                case 4:

                    frmArtistBallance ballance = new frmArtistBallance(id.ToString(), this.SQLConnection, this.User);
                    ballance.Show();
                    break;

                case 5:

                    frmCheckin checkin = new frmCheckin(id.ToString(), this.SQLConnection, this.User);
                    checkin.Show();
                    break;
                case 6:
                    frmGSManager GSM = new frmGSManager(id.ToString(), this.SQLConnection, this.User);
                    GSM.Show();
                    break;

            }


            // 0 - Edit Artist
            // 1 - Delete Artist
            // 2 - Edit Artist's Merchandise
            // 3 - Mass-Gen Bidding Sheets
            // 4 - Manage Artist's payment / space allocation
            // 5 - Checkin
            // 6 - Manage Gallery store stock
        }



        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Return)
            {
                button1_Click(sender, null);
            }
        }

    }
}