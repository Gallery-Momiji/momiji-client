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
    public partial class frmQuickSale : Form
    {
        public SQL SQLConnection;
        public SQLResult User;
        public float total = 0;

        public frmQuickSale(SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (txtBarcode.Text.Length < 9){
                    return;

                }
                string pieceType = txtBarcode.Text.Substring(0, 2);
                if (pieceType != "AN" && txtBarcode.Text.IndexOf("-") == -1 && txtBarcode.Text.IndexOf("-") < txtBarcode.Text.Length)
                {
                    MessageBox.Show("Invalid Item!");
                    txtBarcode.Text = "";
                    txtBarcode.Focus();
                    return;
                }
                
                string artistID = txtBarcode.Text.Substring(2, txtBarcode.Text.IndexOf("-") - 2);
                string pieceID = txtBarcode.Text.Substring(txtBarcode.Text.IndexOf("-")+1, txtBarcode.Text.Length - txtBarcode.Text.IndexOf("-")-1);

                if (existsInList(artistID, pieceID))
                {
                    MessageBox.Show("Item already Scanned!", "I'm seeing doubles!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarcode.Text = "";
                    return;

                }


                MySqlCommand query = new MySqlCommand("SELECT * FROM `merchandise` WHERE `ArtistID` = @ARTISTID AND `MerchID` = @MERCHID;", SQLConnection.GetConnection());
                query.Prepare();
                query.Parameters.AddWithValue("@ARTISTID", artistID);
                query.Parameters.AddWithValue("@MERCHID", pieceID);


                SQLResult results = this.SQLConnection.Query(query);
                if (results.GetNumberOfRows() == 1)
                {
                    if (!hasBeenScanned(artistID, pieceID))
                    {
                        if (results.getCell("MerchQuickSale", 0) == "0")
                        {
                            txtBarcode.Text = "";
                            MessageBox.Show("This item has a 'NO QUICK SALE' flag! I cannot add it. This will be reported!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SQLConnection.LogAction("Attempted to Quick sell a non Quick sellable item (" + txtBarcode.Text + ")", this.User);
                            return;
                        }
                        else if (results.getCell("MerchSold",0) == "1")
                        {
                            txtBarcode.Text = "";
                            MessageBox.Show("This item has already been sold! Check receipt ID# " +
                                    results.getCell("ReceiptID", 0) + ". This will be reported!", "PROBLEM!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SQLConnection.LogAction("Attempted to Quick sell an already sold item(" + txtBarcode.Text + ")", this.User);
                            return;
                        
                        }
                        ListViewItem newItem = new ListViewItem(results.getCell("ArtistID", 0));

                        newItem.SubItems.Add(results.getCell("MerchTitle", 0));
                        newItem.SubItems.Add(results.getCell("MerchID", 0));
                        newItem.SubItems.Add(results.getCell("MerchQuickSale", 0));


                        this.total = this.total + float.Parse(cleanPrice(results.getCell("MerchQuickSale", 0)));
                        //this.total = this.total + float.Parse(cleanPrice(results.getCell("MarchMinBid", 0)));
                        txtTotal.Text = "$" + this.total.ToString();
                        listView1.Items.Add(newItem);
                        btnPay.Enabled = true;
                        txtBarcode.Text = "";
                    }


                }
                else
                {
                    SQLConnection.LogAction("Scanned a fake item barcode! (" + txtBarcode.Text + ")", this.User);
                    MessageBox.Show("Fake or invalid Serial number! This will be reported!", "Naughty Naughty...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarcode.Text = "";
                }

            }
        }

        private void frmQuickSale_Load(object sender, EventArgs e)
        {
            SQLConnection.LogAction("Started a Quick Sale!", this.User);
        }

        private void btnCancelClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Enabled = true;
            btnCancel.Enabled = true;
            btnPay.Enabled = true;
            txtPaid.Enabled = true;
            listView1.Items.Clear();
            txtTotal.Text = "";
            txtChange.Text = "";
            txtPaid.Text = "";
            this.total = 0;
        }


        private bool hasBeenScanned(string artistID, string pieceID)
        {
            return false;
        }

        private string cleanPrice(string price)
        {
         
            string temp = price;
          
            temp = temp.Replace(",", ".");
            
            if (temp.IndexOf(".") == -1)
            {
                temp = temp + ".00";
            
            }

            return temp;

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            float paid;

            try
            {
                paid = float.Parse(txtPaid.Text);
            }
            catch (Exception cept)
            {
                
                MessageBox.Show("Make sure you put a number in the 'PAID' Field. Tell me how much the client has paid!", cept.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Dude, why are you trying to sell nothing? If you want to donate, come see Tiago Medeiros!", "Please don't go full retard!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            if (this.total > paid)
            {
                MessageBox.Show("Insufficient Funds! Client still owes us moneys", "WII NIID MOAH INTARNET MAHNEY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtChange.Text = "$" + String.Format("{0:0,0.00}", (paid - this.total));
            frmProcessing processing = new frmProcessing();
            btnCancel.Enabled = false;
            processing.Show();


            btnCancel.Enabled = false;
            btnPay.Enabled = false;
            txtPaid.Enabled = false;
            txtBarcode.Enabled = false;

            //
            processing.label1.Text = "Creating Receipt...";
            processing.progressBar1.Value = 5;
            MySqlCommand query = new MySqlCommand("INSERT INTO `receipts` (`userID`, `price`, `paid`, `isQuickSale`, `itemArray`, `priceArray`) VALUES (@UID, @PRICE, @PAID, 1, @ITEMARRAY, @PRICEARRAY);", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@UID", this.User.getCell("id", 0));
            query.Parameters.AddWithValue("@PRICE", this.total);
            query.Parameters.AddWithValue("@PAID", paid);
            query.Parameters.AddWithValue("@ITEMARRAY", genItemArray());
            query.Parameters.AddWithValue("@PRICEARRAY", genPriceArray());
            //genItemArray

            SQLResult results = this.SQLConnection.Query(query);


            processing.label1.Text = "Obtaining ID";
            processing.progressBar1.Value = 10;


            query = new MySqlCommand("SELECT `id` from `receipts` where `userID` = @UID  AND `price` = @PRICE AND `paid` = @PAID AND `isQuickSale` = 1 ORDER BY `id` DESC;", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@UID", this.User.getCell("id", 0));
            query.Parameters.AddWithValue("@PRICE", this.total);
            query.Parameters.AddWithValue("@PAID", paid);
            results = this.SQLConnection.Query(query);

            int receiptID = Int32.Parse(results.getCell("id", 0).ToString());


            int i;
            for (i = 0; i < listView1.Items.Count; i++)
            {

                processing.label1.Text = "Processing... (0/" + listView1.Items.Count.ToString() + ")";
                query = new MySqlCommand("UPDATE `merchandise` SET `MerchSold`=1, `ReceiptID`=@RECEIPTID WHERE  `ArtistID`=@ARTISTID AND `MerchID`=@MERCHID LIMIT 1;", SQLConnection.GetConnection());
                query.Prepare();
                query.Parameters.AddWithValue("@RECEIPTID", receiptID);
                query.Parameters.AddWithValue("@ARTISTID", listView1.Items[i].SubItems[0].Text);
                query.Parameters.AddWithValue("@MERCHID", listView1.Items[i].SubItems[2].Text);
                results = this.SQLConnection.Query(query);
                
                processing.progressBar1.Value = (int)20+((i * 80) / listView1.Items.Count); 
                
                
            }
            processing.progressBar1.Value = 100;
            processing.Dispose();

            MessageBox.Show("Receipt processed! Please go to our receipt printer. This was transaction ID #" + receiptID.ToString());

            btnCancel.Enabled = true;
            
    
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private string forceLength(string src, int length, char fillerChar)
        {
          
            if (src.Length < length)
            {
                return src.PadLeft( length, fillerChar);
            }
            else
            {
                return src;
            }


        }

        private string genItemArray()
        {
            int count = listView1.Items.Count;
            string items = "";
            int i;
            for (i = 0; i < count; i++)
            {
                if (items.Length != 0) { items = items + "#"; }
                items = items + "AN" + forceLength(listView1.Items[i].SubItems[0].Text, 3, '0');
                items = items + "-" + forceLength(listView1.Items[i].SubItems[2].Text,3,'0');
            }
            return items;
        }



        private string genPriceArray()
        {
            int count = listView1.Items.Count;
            string prices = "";
            int i;
            for (i = 0; i < count; i++)
            {
                if (prices.Length != 0) { prices = prices + "#"; }
                prices = prices + listView1.Items[i].SubItems[3].Text;
            }
            return prices;


        }

        private bool existsInList(string artistID, string pieceID)
        {
            int count = listView1.Items.Count;
            int artist = Int32.Parse(artistID);
            int piece = Int32.Parse(pieceID);

            int i = 0;
            for (i = 0; i < count; i++)
            {
                int sArtist = Int32.Parse(  listView1.Items[i].SubItems[0].Text);
                int sPiece = Int32.Parse(listView1.Items[i].SubItems[2].Text);

                if (sArtist == artist && sPiece == piece)
                {
                    return true;
                }

            }

            return false;
        }


    }
}