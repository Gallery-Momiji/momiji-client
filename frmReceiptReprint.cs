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
    public partial class frmReceiptReprint : Form
    {
        public SQL SQLConnection;
        public SQLResult User;

        public frmReceiptReprint(SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Every receipt has a transaction ID usually shown as 'Transaction #123'

if you know that number, in this case, 123, input it into the field in this form and press re-print!", "HELP", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnReprintLast_Click(object sender, EventArgs e)
        {

            MySqlCommand query = new MySqlCommand("UPDATE `receipts` SET `isPrinted`=0  ORDER BY id DESC LIMIT 1;" , SQLConnection.GetConnection());
            query.Prepare();
            SQLResult results = this.SQLConnection.Query(query);

            if (results.successful())
            {
                MessageBox.Show("Last receipt reprinted.\nPlease check receipt printer.", "Receipt Reprint");
            }
            else
            {
                MessageBox.Show("Server refused to reprint receipt.\nPlease contact your supervisor.", "Receipt Reprint Error");
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (isNumeric(txtTransactionID.Text))
            {
                MySqlCommand reprint = new MySqlCommand("UPDATE `receipts` SET `isPrinted`=0 WHERE `id` = @ID;", SQLConnection.GetConnection());
                reprint.Prepare();
                reprint.Parameters.AddWithValue("@ID", txtTransactionID.Text);

                SQLResult result = this.SQLConnection.Query(reprint);

                if (result.successful())
                {

                    MessageBox.Show("Attempted to reprint receipt.\nPlease check receipt printer.", "Receipt Reprint");
                }
                else
                {
                    MessageBox.Show("Server refused to reprint receipt. Are you sure this is the right ID number?\nPlease contact your supervisor if you continue to have issues.", "Receipt Reprint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("ID must be a number, please try again.", "Not an ID Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

    }
}
