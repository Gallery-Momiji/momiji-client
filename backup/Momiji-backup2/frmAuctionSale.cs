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
    public partial class frmAuctionSale : Form
    {

        public SQL SQLConnection;
        public SQLResult User;
        public float total = 0;
        public string Items = "";
        public string Prices = "";

        public frmAuctionSale(SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void frmAuctionSale_Load(object sender, EventArgs e)
        {
            SQLConnection.LogAction("Started an Auction Sale!", this.User);
            this.ActiveControl = txtID;
            btnPaid.Enabled = false;
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                this.ActiveControl = txtPrice;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnAddToList_Click(sender, null);
            }
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

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length == 0)
            {
                MessageBox.Show("No item ID specified.", "No ID Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPrice.Text.Length == 0)
            {
                MessageBox.Show("No price specified.", "No Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isNumeric(txtPrice.Text))
            {
                MessageBox.Show("Price is not a valid number. Use only numbers and '.' for a decimal.", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtID.Text.Substring(0, 2).ToUpper() != "AN")
            {
                MessageBox.Show("Not a valid auction item, check your Item ID.\nItem ID should start with an 'AN'", "Invalid Item ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isNumeric(txtID.Text.Substring(2, 3)))
            {
                MessageBox.Show("Item ID should start with 'AN', followed by 3 numbers: 'AN###'", "Invalid Item ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtID.Text.Substring(5, 1) != "-")
            {
                MessageBox.Show("Item ID should have a '-' following AN###", "Invalid Item ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isNumeric(txtID.Text.Substring(6, 3))) {
                MessageBox.Show("Item ID should end with 3 numbers", "Invalid Item ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int MID = Int32.Parse(txtID.Text.Substring(6, 3));
                int AID = Int32.Parse(txtID.Text.Substring(2, 3));

                MySqlCommand query = new MySqlCommand("SELECT * FROM `merchandise` WHERE `ArtistID` = @AID AND `MerchID` = @MID LIMIT 0,1;", SQLConnection.GetConnection());
                query.Prepare();
                query.Parameters.AddWithValue("@AID", AID);
                query.Parameters.AddWithValue("@MID", MID);

                SQLResult results = this.SQLConnection.Query(query);

                if (results.successful() != true)
                {
                    throw new Exception("Failed to grab item details.");
                }

                ListViewItem newItem = new ListViewItem( AID.ToString()   );
                newItem.SubItems.Add( results.getCell("MerchTitle", 0)   );
                newItem.SubItems.Add(MID.ToString());
                newItem.SubItems.Add(txtPrice.Text);

                if (isNumeric(txtPrice.Text))
                {
                    total = total + float.Parse(txtPrice.Text);
                }
                else
                {
                    throw new Exception("Invalid price");
                }

                listView1.Items.Add(newItem);
                Items = Items + txtID.Text + "#";
                Prices = Prices + txtPrice.Text + "#";
                txtPrice.Text = "";
                txtID.Text = "";
                txtTotal.Text = total.ToString();
                this.ActiveControl = txtID;
                btnPaid.Enabled = true;
            }
            catch (Exception d)
            {
                MessageBox.Show("Error, possible lost connection to SQL Database server. Please contact your supervisor as soon as possible", "SQL Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("System had this to say : " + d.Message);
                Console.Write(d.Message);
                Application.Exit();
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPrice.Text = "";
            txtID.Text = "";
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Items = "";
            Prices = "";
            total = 0;
            listView1.Items.Clear();
            txtPrice.Text = "";
            txtID.Text = "";
            txtPaid.Text = "";
            txtTotal.Text = "";
            txtChange.Text = "";
            this.ActiveControl = txtID;
            btnPaid.Enabled = false;
        }

        private void btnPaid_Click(object sender, EventArgs e)
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

            if (paid < total)
            {
                MessageBox.Show("Amount specified will not cover the cost of the item(s)", "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return;
            }

            txtChange.Text = "$" + (paid - total).ToString();
            btnPaid.Enabled = false;
            MySqlCommand query = new MySqlCommand("INSERT INTO `receipts` (`userID`, `price`, `paid`, `isAuctionSale`, `itemArray`, `priceArray`) VALUES (@UID, @PRICE, @PAID, 1, @ITEMARRAY, @PRICEARRAY);", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@UID", this.User.getCell("id", 0));
            query.Parameters.AddWithValue("@PRICE", this.total);
            query.Parameters.AddWithValue("@PAID", paid);
            query.Parameters.AddWithValue("@ITEMARRAY", Items);
            query.Parameters.AddWithValue("@PRICEARRAY", Prices);
            //genItemArray
            SQLResult results = this.SQLConnection.Query(query);

            query = new MySqlCommand("SELECT `id` from `receipts` where `userID` = @UID  AND `price` = @PRICE AND `paid` = @PAID AND `isAuctionSale` = 1 ORDER BY `id` DESC;", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@UID", this.User.getCell("id", 0));
            query.Parameters.AddWithValue("@PRICE", this.total);
            query.Parameters.AddWithValue("@PAID", paid);
            results = this.SQLConnection.Query(query);

            int receiptID = Int32.Parse(results.getCell("id", 0).ToString());

            int i;
            for (i = 0; i < listView1.Items.Count; i++)
            {
                query = new MySqlCommand("UPDATE `merchandise` SET `MerchSold`=1, `ReceiptID`=@RECEIPTID WHERE  `ArtistID`=@ARTISTID AND `MerchID`=@MERCHID LIMIT 1;", SQLConnection.GetConnection());
                query.Prepare();
                query.Parameters.AddWithValue("@RECEIPTID", receiptID);
                query.Parameters.AddWithValue("@ARTISTID", listView1.Items[i].SubItems[0].Text);
                query.Parameters.AddWithValue("@MERCHID", listView1.Items[i].SubItems[2].Text);
                results = this.SQLConnection.Query(query);
                SQLConnection.LogAction("Made an auction sale with receipt #" + receiptID.ToString(), User);
                MessageBox.Show("Receipt processed, please give the following change: " + txtChange.Text + "\n\nPlease check the receipt printer.\nThis was transaction ID #" + receiptID.ToString(), "Sale Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void txtPaid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnPaid_Click(sender, e);
            }
        }

    }
}
