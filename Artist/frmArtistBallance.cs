using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
    public partial class frmArtistBallance : Form
    {

        public SQL SQLConnection;
        public SQLResult User;
        public string ArtistID;
        public SQLResult ArtistInfo;

        public frmArtistBallance(string ArtistID, SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            this.ArtistID = ArtistID;
            InitializeComponent();
        }

        private void frmArtistBallance_Load(object sender, EventArgs e)
        {
            lblFullPanel.Text = getOption("fullpanelprice");
            lblHalfPanel.Text = getOption("halfpanelprice");
            lblQuarterPanel.Text = getOption("quarterpanelprice");

            lblFullTable.Text = getOption("fulltableprice");
            lblHalfTable.Text = getOption("halftableprice");
            lblQuarterTable.Text = getOption("quartertableprice");

            MySqlCommand query = new MySqlCommand("select * from `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", ArtistID);
            SQLResult ArtistInfo = this.SQLConnection.Query(query);

            lblArtistEmail.Text = ArtistInfo.getCell("ArtistEmail", 0);
            lblArtistID.Text = ArtistID;
            lblArtistName.Text = ArtistInfo.getCell("ArtistName", 0);
            lblArtistURL.Text = ArtistInfo.getCell("ArtistUrl", 0);

            txtTables.Text = ArtistInfo.getCell("ArtistTables", 0);
            txtPanels.Text = ArtistInfo.getCell("ArtistPanels", 0);
            txtAmtDue.Text = ArtistInfo.getCell("ArtistDue", 0);
            txtAmtPaid.Text = ArtistInfo.getCell("ArtistPaid", 0);
            chkPaid.Checked = (ArtistInfo.getCell("ArtistPaidFully", 0) == "0" ? false : true);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private string getOption(string optionName)
        {

            MySqlCommand query = new MySqlCommand("select `value` from `options` WHERE `option` = @OPTION;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@OPTION", optionName);
            SQLResult results = this.SQLConnection.Query(query);
            if (results.GetNumberOfRows() != 1)
            {
                return "";

            }
            else
            {
                return results.getCell("value", 0);

            }

        }

        private void lblArtistURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process myProcess = new Process();

            try
            {
                if (lblArtistURL.Text.IndexOf("http://") < 0)
                {
                    myProcess.StartInfo.FileName = "http://" + lblArtistURL.Text;
                }
                else
                {
                    myProcess.StartInfo.FileName =lblArtistURL.Text ;
                }

                // true is the default, but it is important not to set it to false
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.Start();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            float priceFullPanel, priceHalfPanel, priceQuarterPanel;
            float priceFullTable, priceHalfTable, priceQuarterTable;

            priceFullPanel = float.Parse(getOption("fullpanelprice"));
            priceHalfPanel = float.Parse(getOption("halfpanelprice"));
            priceQuarterPanel = float.Parse(getOption("quarterpanelprice"));

            priceFullTable = float.Parse(getOption("fulltableprice"));
            priceHalfTable = float.Parse(getOption("halftableprice"));
            priceQuarterTable = float.Parse(getOption("quartertableprice"));

            float total = 0;
            total = total + calculateAmtDue(txtPanels, priceFullPanel,priceHalfPanel,priceQuarterPanel);
            total = total + calculateAmtDue(txtTables, priceFullTable, priceHalfTable, priceQuarterTable);

            txtAmtDue.Text = total.ToString();
        }

        private float calculateAmtDue(TextBox amount, float priceFull, float priceHalf, float priceQuarter)
        {
            float value = 0;

            try
            {
                value = float.Parse(amount.Text);
            }
            catch (Exception d)
            {
                Console.Write(d.Message);
                return 0;
            }

            float full = value - (value % 1);
            value = value - full;

            float half = (float)(value - (value % 0.50));

            value = value - half;
            float quarter = value;

            return  ((full      != 0 ? full     : 0) * priceFull    ) + 
                    ((half      != 0 ? 1        : 0) * priceHalf    ) + 
                    ((quarter   != 0 ? 1        : 0) * priceQuarter );

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // UPDATE `gallery`.`artists` SET `ArtistTables`=1, `ArtistPanels`=1, `ArtistDue`=40, `ArtistPaid`=40, `ArtistPaidFully`=1 WHERE  `ArtistID`=3;
            MySqlCommand query = new MySqlCommand("UPDATE `artists` SET `ArtistTables`=@TABLES, `ArtistPanels`=@PANELS, `ArtistDue`=@AMTDUE, `ArtistPaid`=@AMTPAID, `ArtistPaidFully`=@PAID WHERE  `ArtistID`=@ARTISTID;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@TABLES", txtTables.Text);
            query.Parameters.AddWithValue("@PANELS", txtPanels.Text);
            query.Parameters.AddWithValue("@AMTDUE", txtAmtDue.Text);
            query.Parameters.AddWithValue("@AMTPAID", txtAmtPaid.Text);
            query.Parameters.AddWithValue("@PAID", (chkPaid.Checked == true ? 1 : 0));
            query.Parameters.AddWithValue("@ARTISTID", ArtistID );
            SQLResult results = this.SQLConnection.Query(query);

            if (results.successful()){
                MessageBox.Show("Done!","YAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else{
                MessageBox.Show("An error occured :( Sorry", "O NOES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
