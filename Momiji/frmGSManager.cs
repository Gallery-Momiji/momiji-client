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
    public partial class frmGSManager : Form
    {
        public SQL SQLConnection;
        public SQLResult User;
        public string ArtistID;


        public frmGSManager(string ArtistID, SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            this.ArtistID = ArtistID;
            InitializeComponent();
        }

        private void frmGSManager_Load(object sender, EventArgs e)
        {
            // First grab general info on artist
            SQLConnection.LogAction("Loaded GS merch for artist #" + ArtistID.ToString(), this.User);
            MySqlCommand query = new MySqlCommand("SELECT ArtistAPP, ArtistName FROM `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", ArtistID.ToString());

            SQLResult results = this.SQLConnection.Query(query);

            lblArtistID.Text = ArtistID.ToString();
            lblArtistName.Text =  results.getCell("ArtistName", 0);
            chkAPP.Checked = results.getCell("ArtistAPP", 0) == "True";
            // Now that the artist info is out of the way, let's grab his/her merch!
            lstMerch.Items.Clear();

            MySqlCommand merchData = new MySqlCommand("SELECT * FROM `GSmerchandise` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            merchData.Prepare();
            merchData.Parameters.AddWithValue("@ID", ArtistID.ToString());

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
                    newItem.SubItems.Add(   (merchResults.getCell("PieceSDC", i) == "False" ? "NO" : "YES"));
                    lstMerch.Items.Add(newItem);
                }


            }
        }

        private void lstMerch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                txtGivenStock.Text = lstMerch.SelectedItems[0].SubItems[2].Text;
                txtPieceID.Text = lstMerch.SelectedItems[0].SubItems[0].Text;
                txtPieceID.Enabled = false;
                txtPieceTitle.Text = lstMerch.SelectedItems[0].SubItems[1].Text;
                txtPricePerUnit.Text = lstMerch.SelectedItems[0].SubItems[4].Text;
                chkSDC.Checked = lstMerch.SelectedItems[0].SubItems[5].Text == "YES";
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnGenBarcode.Enabled = true;
                btnGenID.Enabled = false;
                btnUpdate.Enabled = true;
            }
            catch (Exception d)
            {

                Console.Write(d.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            txtPricePerUnit.Text = "";
            txtPieceTitle.Text = "";
            txtPieceID.Text = "";
            txtPieceID.Enabled = true;
            txtGivenStock.Text = "";
            chkSDC.Checked = false;

            btnGenBarcode.Enabled = false;
            btnGenID.Enabled = true;

        }

        private void btnGenID_Click(object sender, EventArgs e)
        {
            DialogResult dlgGenerate = MessageBox.Show("Should I generate an ID for this item automatically?", "ID GENERATOR!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgGenerate == DialogResult.Yes)
            {
                MySqlCommand idData = new MySqlCommand("SELECT `PieceID`+1 as `PieceID` FROM `GSmerchandise` WHERE `ArtistID` = @ID ORDER BY `PieceID` DESC Limit 0,1;", SQLConnection.GetConnection());
                idData.Prepare();
                idData.Parameters.AddWithValue("@ID", ArtistID.ToString());

                SQLResult idResults = this.SQLConnection.Query(idData);

                if (idResults.GetNumberOfRows() != 0)
                {
                    txtPieceID.Text = idResults.getCell("PieceID", 0);
                }
                else
                {
                    txtPieceID.Text = "1";
                }
            }
        }

        private void txtCurrentStock_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("You're not supposed to edit this. This field is locked!");
        }

        private bool isNumeric(string num)
        {
            string numString = num; //"1287543.0" will return false for a long 
            long number1 = 0;
            float num2 = 0;
            bool canConvert = long.TryParse(numString, out number1);
            bool convert2 = float.TryParse(numString, out num2);
            return canConvert || convert2;
        }


        private void txtCurrentStock_MouseClick(object sender, MouseEventArgs e)
        {
            txtCurrentStock_MouseDoubleClick(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult delConfirm = MessageBox.Show("Are you sure you wish to delete this entry?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delConfirm == DialogResult.Yes)
            {
                //
                SQLConnection.LogAction("Removed GSMerch for artist #" + ArtistID.ToString(), this.User);
                MySqlCommand merchDel = new MySqlCommand("DELETE FROM `GSmerchandise` WHERE  `ArtistID`=@ARTISTID AND `PieceID`=@PIECEID LIMIT 1;", SQLConnection.GetConnection());
                merchDel.Prepare();
                merchDel.Parameters.AddWithValue("@ARTISTID", ArtistID.ToString());
                merchDel.Parameters.AddWithValue("@PIECEID", txtPieceID.Text);
                SQLResult merchResult = this.SQLConnection.Query(merchDel);
                if (merchResult.successful())
                {
                    MessageBox.Show("Item deleted Successfully!", "WOOHOO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnClear_Click(sender, e);
                    frmGSManager_Load(sender, e);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isNumeric(txtPricePerUnit.Text))
            {
                MessageBox.Show("Please put in a number for Price-per-unit!", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SQLConnection.LogAction("Changed GSmerch for artist #" + ArtistID.ToString(), this.User);
            MySqlCommand merchAdd = new MySqlCommand("UPDATE `GSmerchandise` SET `PieceTitle`=@PIECETITLE, `PiecePrice`=@PIECEPRICE, `PieceInitialStock`=@PIECEINITIALSTOCK, `PieceSDC` = @SDC WHERE  `ArtistID`=@AID AND `PieceID`=@PID LIMIT 1;", SQLConnection.GetConnection());
            merchAdd.Prepare();
            merchAdd.Parameters.AddWithValue("@AID", ArtistID.ToString());
            merchAdd.Parameters.AddWithValue("@PID", txtPieceID.Text);
            merchAdd.Parameters.AddWithValue("@PIECETITLE", txtPieceTitle.Text);
            merchAdd.Parameters.AddWithValue("@PIECEPRICE", txtPricePerUnit.Text);
            merchAdd.Parameters.AddWithValue("@PIECEINITIALSTOCK", txtGivenStock.Text);
            merchAdd.Parameters.AddWithValue("@SDC", (chkSDC.Checked ? 1 : 0));
            SQLResult merchResult = this.SQLConnection.Query(merchAdd);
            if (merchResult.successful())
            {
                MessageBox.Show("Item updated Successfully!", "WOOHOO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(sender, e);
                frmGSManager_Load(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool result = (txtGivenStock.Text.Length == 0) || (txtPieceID.Text.Length == 0) || (txtPieceTitle.Text.Length == 0) || (txtPricePerUnit.Text.Length == 0);
            if (!result)
            {
                //
                SQLConnection.LogAction("Added GSmerch for artist #" + ArtistID.ToString(), this.User);
                MySqlCommand merchAdd = new MySqlCommand("INSERT INTO `GSmerchandise` (`ArtistID`, `PieceID`, `PieceTitle`, `PiecePrice`, `PieceInitialStock`, `PieceStock`, `PieceSDC`) VALUES (@AID, @PID, @TITLE, @PPU, @STOCK, @STOCK, @SDC);", SQLConnection.GetConnection());
                merchAdd.Prepare();
                //@AID, @PID, @TITLE, @PPU, @STOCK, @STOCK
                merchAdd.Parameters.AddWithValue("@AID", ArtistID.ToString());
                merchAdd.Parameters.AddWithValue("@PID", txtPieceID.Text);
                merchAdd.Parameters.AddWithValue("@TITLE", txtPieceTitle.Text);
                merchAdd.Parameters.AddWithValue("@PPU", txtPricePerUnit.Text);
                merchAdd.Parameters.AddWithValue("@STOCK", txtGivenStock.Text);
                merchAdd.Parameters.AddWithValue("@SDC", (chkSDC.Checked ? 1 : 0));
                SQLResult merchResult = this.SQLConnection.Query(merchAdd);
                if (merchResult.successful())
                {
                    MessageBox.Show("Item added Successfully!", "WOOHOO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnClear_Click(sender, e);
                    frmGSManager_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("One or more fields missing! Make sure to fill in everything!", "RUH ROH!");
            }
        }
        private string forceLength(string src, int length, char fillerChar)
        {

            if (src.Length < length)
            {
                return src.PadLeft(length, fillerChar);
            }
            else
            {
                return src;
            }


        }


        private void btnGenBarcode_Click(object sender, EventArgs e)
        {
            barcode code = new barcode("PN" + forceLength(ArtistID,3,'0') + "-" + forceLength(txtPieceID.Text,3,'0'));
            code.generate();
        }

        private void btnGenCS_Click(object sender, EventArgs e)
        {
            GScontrolsheet art = new GScontrolsheet(ArtistID, SQLConnection, User);
            art.generate();
        }

        private void chkAPP_CheckedChanged(object sender, EventArgs e)
        {
            MySqlCommand merchAdd = new MySqlCommand("UPDATE `artists` SET `ArtistAPP`=@VAL WHERE  `ArtistID`=@AID;", SQLConnection.GetConnection());
            merchAdd.Prepare();
            //@AID, @PID, @TITLE, @PPU, @STOCK, @STOCK
            merchAdd.Parameters.AddWithValue("@AID", ArtistID.ToString());
            merchAdd.Parameters.AddWithValue("@VAL", (chkAPP.Checked ? 1 : 0));
            SQLResult merchResult = this.SQLConnection.Query(merchAdd);
        }



     


    }
}