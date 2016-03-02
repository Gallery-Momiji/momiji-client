using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;


namespace Momiji
{
    public partial class frmMerchEditor : Form
    {

        public int artistID = 0;
        public SQL SQLConnection;
        public SQLResult User;

        public frmMerchEditor(SQL Link, SQLResult UserIdentifier, int artistID)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            this.artistID = artistID;
            InitializeComponent();
        }

        private void frmMerchEditor_Load(object sender, EventArgs e)
        {
            // First grab general info on artist
            SQLConnection.LogAction("Loaded merch for artist #" + this.artistID.ToString(), this.User);
            MySqlCommand query = new MySqlCommand("SELECT ArtistID, ArtistName FROM `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", this.artistID.ToString());

            SQLResult results = this.SQLConnection.Query(query);

            lblArtistID.Text = results.getCell("ArtistID", 0);
            lblArtistName.Text = results.getCell("ArtistName", 0);

            // Now that the artist info is out of the way, let's grab his/her merch!
            lstMerch.Items.Clear();
  
            MySqlCommand merchData = new MySqlCommand("SELECT * FROM `merchandise` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            merchData.Prepare();
            merchData.Parameters.AddWithValue("@ID", this.artistID.ToString());

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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
            DialogResult dlgGenerate = MessageBox.Show("Should I generate an ID for this item automatically?", "ID GENERATOR!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgGenerate == DialogResult.Yes) {
                MySqlCommand idData = new MySqlCommand("SELECT `MerchID`+1 as `MerchID` FROM `merchandise` WHERE `ArtistID` = @ID ORDER BY `MerchID` DESC Limit 0,1;", SQLConnection.GetConnection());
                idData.Prepare();
                idData.Parameters.AddWithValue("@ID", this.artistID.ToString());

                SQLResult idResults = this.SQLConnection.Query(idData);

                if (idResults.GetNumberOfRows() != 0)
                {
                    txtPieceID.Text = idResults.getCell("MerchID", 0);
                }
                else
                {
                    txtPieceID.Text = "1";
                }
            }
        }


        private void lstMerch_MouseDoubleClick()
        {
            try
            {
                txtPieceID.Text = lstMerch.SelectedItems[0].SubItems[0].Text;
                txtPieceID.Enabled = false;
                btnGenerate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCreateSheet.Enabled = true;
                txtPieceTitle.Text = lstMerch.SelectedItems[0].SubItems[1].Text;



                txtPieceMinimumBid.Text = lstMerch.SelectedItems[0].SubItems[2].Text;

                if (lstMerch.SelectedItems[0].SubItems[4].Text == "N/A")
                {
                    textBox1.Text = "0";
                }
                else
                {
                    textBox1.Text = lstMerch.SelectedItems[0].SubItems[4].Text;
                }

                if (lstMerch.SelectedItems[0].SubItems[3].Text == "Yes")
                {

                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                txtMedium.Text = lstMerch.SelectedItems[0].SubItems[5].Text;
                btnAdd.Enabled = false;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);

            }
        }



        private bool areFieldsEmpty()
        {
            
            int total = (textBox1.Text.Length + txtMedium.Text.Length + txtPieceID.Text.Length + txtPieceMinimumBid.Text.Length + txtPieceTitle.Text.Length);
            if (checkBox1.Checked) { total++; }
            if (total == 0) { return true; } else { return false; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPieceTitle.Text = "";
            txtPieceMinimumBid.Text = "";
            txtPieceID.Text = "";
            txtPieceID.Enabled = true;
            txtMedium.Text = "";
            textBox1.Text = "";
            checkBox1.Checked = false;
            btnGenerate.Enabled = true;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnCreateSheet.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SQLConnection.LogAction("Added merch for artist #" + this.artistID.ToString(), this.User);
            MySqlCommand merchAdd = new MySqlCommand("INSERT INTO `merchandise` (`ArtistID`, `MerchID`, `MerchTitle`, `MerchMinBid`, `MerchAAMB`, `MerchQuickSale`, `MerchMedium`) VALUES (@ARTISTID, @PIECEID, @PIECETITLE, @PIECEMINBID, @PIECEAAMB, @PIECEQUICKSALE, @PIECEMEDIUM);", SQLConnection.GetConnection());
            merchAdd.Prepare();
            merchAdd.Parameters.AddWithValue("@ARTISTID", this.artistID.ToString());
            merchAdd.Parameters.AddWithValue("@PIECEID", txtPieceID.Text);
            merchAdd.Parameters.AddWithValue("@PIECETITLE", txtPieceTitle.Text);
            merchAdd.Parameters.AddWithValue("@PIECEMINBID", txtPieceMinimumBid.Text);
            merchAdd.Parameters.AddWithValue("@PIECEAAMB", Convert.ToInt16(checkBox1.Checked));
            merchAdd.Parameters.AddWithValue("@PIECEQUICKSALE", float.Parse(textBox1.Text) );
            merchAdd.Parameters.AddWithValue("@PIECEMEDIUM", txtMedium.Text);
            SQLResult merchResult = this.SQLConnection.Query(merchAdd);
            if (merchResult.successful())
            {
                MessageBox.Show("Item added Successfully!", "WOOHOO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(sender, e);
                frmMerchEditor_Load(sender, e);
            }
        }

        private bool isNumeric(string num)
        {
            string numString = num; //"1287543.0" will return false for a long 
            long number1 = 0;
            bool canConvert = long.TryParse(numString, out number1);
            return canConvert;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if( !isNumeric(textBox1.Text)){
                MessageBox.Show("Please put in a number for QuickSale (If the spreadsheet says 'N/A' Just put in '0'!", "OOPS", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            SQLConnection.LogAction("Changed merch for artist #" + this.artistID.ToString(), this.User);
            MySqlCommand merchAdd = new MySqlCommand("UPDATE `merchandise` SET `MerchTitle`=@PIECETITLE, `MerchMinBid`=@PIECEMINBID, `MerchAAMB`=@PIECEAAMB, `MerchQuickSale`=@PIECEQUICKSALE, `MerchMedium`=@PIECEMEDIUM WHERE  `ArtistID`=@ARTISTID AND `MerchID`=@PIECEID LIMIT 1;", SQLConnection.GetConnection());
            merchAdd.Prepare();
            merchAdd.Parameters.AddWithValue("@ARTISTID", this.artistID.ToString());
            merchAdd.Parameters.AddWithValue("@PIECEID", txtPieceID.Text);
            merchAdd.Parameters.AddWithValue("@PIECETITLE", txtPieceTitle.Text);
            merchAdd.Parameters.AddWithValue("@PIECEMINBID", txtPieceMinimumBid.Text);
            merchAdd.Parameters.AddWithValue("@PIECEAAMB", Convert.ToInt16(checkBox1.Checked));
            merchAdd.Parameters.AddWithValue("@PIECEQUICKSALE", float.Parse(textBox1.Text));
            merchAdd.Parameters.AddWithValue("@PIECEMEDIUM", txtMedium.Text);
            SQLResult merchResult = this.SQLConnection.Query(merchAdd);
            if (merchResult.successful())
            {
                MessageBox.Show("Item updated Successfully!", "WOOHOO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(sender, e);
                frmMerchEditor_Load(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult delConfirm = MessageBox.Show("Are you sure you wish to delete this entry?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (delConfirm == DialogResult.Yes)
            {
                //
                SQLConnection.LogAction("Removed merch for artist #" + this.artistID.ToString(), this.User);
                MySqlCommand merchDel = new MySqlCommand("DELETE FROM `merchandise` WHERE  `ArtistID`=@ARTISTID AND `MerchID`=@PIECEID LIMIT 1;", SQLConnection.GetConnection());
                merchDel.Prepare();
                merchDel.Parameters.AddWithValue("@ARTISTID", this.artistID.ToString());
                merchDel.Parameters.AddWithValue("@PIECEID", txtPieceID.Text);
                SQLResult merchResult = this.SQLConnection.Query(merchDel);
                if (merchResult.successful())
                {
                    MessageBox.Show("Item deleted Successfully!", "WOOHOO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnClear_Click(sender, e);
                    frmMerchEditor_Load(sender, e);
                }
            }
        }

        private void btnCreateSheet_Click(object sender, EventArgs e)
        {
            biddingsheet sheet = new biddingsheet(lblArtistID.Text, txtPieceID.Text, txtPieceTitle.Text, txtMedium.Text, txtPieceMinimumBid.Text, textBox1.Text, (checkBox1.Checked ? "1" : "0"), lblArtistName.Text, SQLConnection, User);

           sheet.process();
        }

        private void lstMerch_SelectedIndexChanged(object sender, EventArgs e)
        {
         

            lstMerch_MouseDoubleClick(  );
        }

        private void btnControlSheetGen_Click(object sender, EventArgs e)
        {
            controlsheet AN = new controlsheet(this.artistID.ToString(), this.SQLConnection, this.User);
            AN.generate();
        }


        











    
    }
}