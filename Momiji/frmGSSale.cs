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
                try
                {
                    if (txtBarcode.Text.Length < 9)
                    {
                        MessageBox.Show("ID too short, should be 9 characters. Example : PN011-001");
                        txtBarcode.Text = "";
                        return;

                    }



                    if (txtBarcode.Text.Substring(0, 2) != "PN")
                    {
                        MessageBox.Show("ID doesn't start with PN! Considered invalid");
                        txtBarcode.Text = "";
                        return;
                    }

                    int ArtistID = Int32.Parse(txtBarcode.Text.Substring(2, 3) );
                    int PieceID = Int32.Parse( txtBarcode.Text.Substring(6, 3) );

                    MySqlCommand query = new MySqlCommand("SELECT * FROM `GSmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;", SQLConnection.GetConnection());
                    query.Prepare();
                    query.Parameters.AddWithValue("@AID", ArtistID);
                    query.Parameters.AddWithValue("@PID", PieceID);


                    SQLResult results = this.SQLConnection.Query(query);

                    if (results.successful())
                    {
                        ListViewItem newItem = new ListViewItem(ArtistID.ToString());
                        
                        newItem.SubItems.Add(results.getCell("PieceTitle", 0));
                        newItem.SubItems.Add(PieceID.ToString());
                        newItem.SubItems.Add(results.getCell("PiecePrice", 0));

                        total = total + float.Parse(results.getCell("PiecePrice", 0));
                        listView1.Items.Add(newItem);
                    }
                    else
                    {
                        MessageBox.Show("Could not find this item in our database...");
                        txtBarcode.Text = "";
                        return;

                    }
                    txtTotal.Text = "$" + total.ToString();
                    items = items + txtBarcode.Text + "#";
                    prices = prices + results.getCell("PiecePrice", 0) + "#";
                    txtBarcode.Text = "";

                    
                    return;

                    
                    
                }
                catch (Exception d)
                {
                    MessageBox.Show("Something SERIOUSLY wrong happened. I'm not accepting this number!");
                    Console.Write(d.Message);
                    return;
                }

            }
        }

        private void frmQuickSale_Load(object sender, EventArgs e)
        {
            SQLConnection.LogAction("Started a GS Sale!", this.User);
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
            // An exception handler for fucking up a number. Just because >:C
            try
            {
                float pay = float.Parse(txtPaid.Text);
                if (total > pay)
                {
                    MessageBox.Show("Client still owes us moneys", "More moonies");
                    return;
                }

                if (total == 0)
                {
                    MessageBox.Show("Nothing to sell...");
                    return;

                }

                if (pay >= total)
                {
                    MySqlCommand query = new MySqlCommand("INSERT INTO `gallery`.`receipts` ( `userID`, `price`, `paid`, `isGalleryStoreSale`, `itemArray`, `priceArray`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES);", SQLConnection.GetConnection());
                    query.Prepare();
                    query.Parameters.AddWithValue("@UID", User.getCell("id", 0));
                    query.Parameters.AddWithValue("@TOTAL", total);
                    query.Parameters.AddWithValue("@PAID", pay);
                    query.Parameters.AddWithValue("@ITEMS", items);
                    query.Parameters.AddWithValue("@PRICES", prices);
                    SQLResult results = this.SQLConnection.Query(query);
                    if (results.successful())
                    {
                        // now we find the Transaction ID
                        query = new MySqlCommand("SELECT `id` FROM `receipts` WHERE `userID` = @UID AND `itemArray` = @ITEMS AND `priceArray` = @PRICES AND `isGalleryStoreSale` = 1 LIMIT 0,1;", SQLConnection.GetConnection());
                        query.Prepare();
                        query.Parameters.AddWithValue("@UID", User.getCell("id", 0));
                        query.Parameters.AddWithValue("@TOTAL", total);
                        query.Parameters.AddWithValue("@PAID", pay);
                        query.Parameters.AddWithValue("@ITEMS", items);
                        query.Parameters.AddWithValue("@PRICES", prices);
                        results = this.SQLConnection.Query(query);
                        MessageBox.Show("This was transaction ID # " + results.getCell("id", 0) + ". DO NOT PRESS OK UNTIL YOU HAVE A RECEIPT!", "CA-CHING", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtChange.Text = "$" + (pay - total).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong... Please call Tiago, STAT!");
                    }
                }

            }
            catch (Exception d)
            {
                MessageBox.Show("You should try putting a regular number in that paid box... nothing more...", "Fuck you");
                
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


    }
}