using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;

namespace Momiji
{
    public partial class frmGSSale : Form
    {
        public SQL SQLConnection;
        public SQLResult User;
        public float total = 0;
        public string items = "";
        public string prices = "";

        public frmGSSale(SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (txtBarcode.Text.Length < 9)
                {
                    SystemSounds.Beep.Play();
                    txtBarcode.Text = "";
                    return;
                }

                txtBarcode.Text = txtBarcode.Text.ToUpper();

                if (txtBarcode.Text.Substring(0, 2) != "PN")
                {
                    MessageBox.Show("Part Numbers should start with PN.","Invalid ID");
                    txtBarcode.Text = "";
                    return;
                }

                try
                {
                    int ArtistID = Int32.Parse(txtBarcode.Text.Substring(2, 3) );
                    int PieceID = Int32.Parse( txtBarcode.Text.Substring(6, 3) );

                    MySqlCommand query = new MySqlCommand("SELECT * FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;", SQLConnection.GetConnection());
                    query.Prepare();
                    query.Parameters.AddWithValue("@AID", ArtistID);
                    query.Parameters.AddWithValue("@PID", PieceID);
                    SQLResult results = this.SQLConnection.Query(query);

                    if (results.successful())
                    {
                        ListViewItem newItem = new ListViewItem(ArtistID.ToString());
  
                        newItem.SubItems.Add(results.getCell("PieceTitle", 0));
                        newItem.SubItems.Add(PieceID.ToString());
                        newItem.SubItems.Add("$" + String.Format("{0:0.00}", results.getCell("PiecePrice", 0)));

                        total = total + float.Parse(results.getCell("PiecePrice", 0));
                        listView1.Items.Add(newItem);
                        btnPay.Enabled = true;
                        
                    }
                    else
                    {
                        MessageBox.Show("Could not find this item in our database.");
                        txtBarcode.Text = "";
                        return;
                    }

                    txtTotal.Text = String.Format("{0:0.00}", total.ToString());
                    items = items + txtBarcode.Text.ToUpper() + "#";
                    prices = prices + results.getCell("PiecePrice", 0) + "#";
                    txtBarcode.Text = "";

                    return;
                }
                catch (Exception d)
                {
                    Console.WriteLine(d.ToString());
                    SystemSounds.Beep.Play();
                    txtBarcode.Text = "";
                    return;
                }
            }
        }

        private void frmQuickSale_Load(object sender, EventArgs e)
        {
            SQLConnection.LogAction("Started a GS Sale!", this.User);
            //Reset All values on init (redundancy check)
            txtBarcode.Enabled = true;
            btnCancel.Enabled = true;
            btnPay.Enabled = false;
            txtPaid.Enabled = true;
            listView1.Items.Clear();
            txtTotal.Text = "";
            this.items = "";
            this.prices = "";
            txtChange.Text = "";
            txtPaid.Text = "";
            this.total = 0;
            this.ActiveControl = txtBarcode;
        }

        private void btnCancelClear_Click(object sender, EventArgs e)
        {
            //Reset All values on clear
            txtBarcode.Enabled = true;
            btnCancel.Enabled = true;
            btnPay.Enabled = false;
            txtPaid.Enabled = true;
            listView1.Items.Clear();
            txtTotal.Text = "";
            txtChange.Text = "";
            this.items = "";
            this.prices = "";
            txtPaid.Text = "";
            this.total = 0;
            this.ActiveControl = txtBarcode;

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

            if (txtPaid.Text == "")
            {
                MessageBox.Show("Please specify amount customer has paid.", "Paid Amount Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               paid = float.Parse(txtPaid.Text);
            }
            catch (Exception d)
            {
                Console.Write(d.Message);
                MessageBox.Show("Error reading paid price. Make sure it is a valid number.");
                return;
            }

            if (total > paid)
            {
                MessageBox.Show("Amount specified will not cover the cost of the item(s)", "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (total == 0)
            {
                MessageBox.Show("No items specified for sale.", "No Items", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //catch a bad ID number
            try
            {
                if (paid >= total)
                {
                    MySqlCommand query = new MySqlCommand("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isGalleryStoreSale`, `itemArray`, `priceArray`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES);", SQLConnection.GetConnection());
                    query.Prepare();
                    query.Parameters.AddWithValue("@UID", User.getCell("id", 0));
                    query.Parameters.AddWithValue("@TOTAL", total);
                    query.Parameters.AddWithValue("@PAID", paid);
                    query.Parameters.AddWithValue("@ITEMS", items);
                    query.Parameters.AddWithValue("@PRICES", prices);
                    SQLResult results = this.SQLConnection.Query(query);
                    if (results.successful())
                    {
                        // now we find the Transaction ID
                        query = new MySqlCommand("SELECT `id` FROM `receipts` WHERE `userID` = @UID AND `itemArray` = @ITEMS AND `priceArray` = @PRICES AND `isGalleryStoreSale` = 1 ORDER BY `id` DESC LIMIT 0,1;", SQLConnection.GetConnection());
                        query.Prepare();
                        query.Parameters.AddWithValue("@UID", User.getCell("id", 0));
                        query.Parameters.AddWithValue("@TOTAL", total);
                        query.Parameters.AddWithValue("@PAID", paid);
                        query.Parameters.AddWithValue("@ITEMS", items);
                        query.Parameters.AddWithValue("@PRICES", prices);
                        results = this.SQLConnection.Query(query);
                        txtChange.Text = "$" + String.Format("{0:0.00}", (paid - total));
                        MessageBox.Show("Receipt processed, please give the following change: " + txtChange.Text + "\n\nPlease check the receipt printer.\nThis was transaction ID #" + results.getCell("id", 0), "Sale Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        SQLConnection.LogAction("Made a gallery store sale with receipt #" + results.getCell("id", 0), User);
                        btnCancel.Enabled = true;
                        btnPay.Enabled = false;
                        txtPaid.Enabled = false;
                        txtBarcode.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("SQL database error. Please call Tiago as soon as possible.");
                    }
                }

            }
            catch (Exception d)
            {
                MessageBox.Show("Invalid number, please try again.", "Invalid Serial Number");

                Console.Write(d.Message);
                return;
            }
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
                items = items + "PN" + forceLength(listView1.Items[i].SubItems[0].Text, 3, '0');
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

        private void txtPaid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnPay_Click(sender, e);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
