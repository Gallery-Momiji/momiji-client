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
    public partial class frmPricing : Form
    {
        public SQL SQLConnection;
        public SQLResult User;

        public frmPricing(SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void frmPricing_Load(object sender, EventArgs e)
        {
            txtFullPanel.Text = getOption("fullpanelprice");
            txtFullTable.Text = getOption("fulltableprice");
            txtHalfPanel.Text = getOption("halfpanelprice");
            txtHalfTable.Text = getOption("halftableprice");
            txtQuarterPanel.Text = getOption("quarterpanelprice");
            txtQuarterTable.Text = getOption("quartertableprice");
            txtOverduePercentage.Text = getOption("overduepercentage");

            string overduedate = getOption("overduedate");
            int year = getYear(overduedate);
            int month = getMonth(overduedate);
            int day = getDay(overduedate);

            dtpOverdueDate.Value = new DateTime(year, month, day);
            SQLConnection.LogAction("Loaded options menu", this.User);

        }

        private void btnCalcPanels_Click(object sender, EventArgs e)
        {
            calculatePrices(txtFullPanel, txtHalfPanel, txtQuarterPanel, "Panel");

        }

        private int getDay(string date)
        {
            return Int32.Parse( date.Substring(date.Length - 2));

        }

        private int getMonth(string date)
        {
            return Int32.Parse(date.Substring(5, 2));

        }

        private int getYear(string date)
        {
            return Int32.Parse(date.Substring(0, 4));
        }

        private void calculatePrices(TextBox mainPrice, TextBox halfPrice, TextBox quarterPrice, string name)
        {
            if (mainPrice.Text.Length != 0)
            {
                float fltFullprice = float.Parse(mainPrice.Text);
                float fltHalfprice = fltFullprice / 2;
                float fltQuarterprice = fltFullprice / 4;

                halfPrice.Text = fltHalfprice.ToString();
                quarterPrice.Text = fltQuarterprice.ToString();

            }
            else
            {
                MessageBox.Show("Please make sure to specify a price for a full " + name + " to calculate the rest", "Specify Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

        }

        private void btnCalcTables_Click(object sender, EventArgs e)
        {
            calculatePrices(txtFullTable, txtHalfTable, txtQuarterTable, "Table");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            setOption("fullpanelprice", txtFullPanel.Text);
            setOption("fulltableprice", txtFullTable.Text);
            setOption("halfpanelprice", txtHalfPanel.Text);
            setOption("halftableprice", txtHalfTable.Text);
            setOption("quarterpanelprice", txtQuarterPanel.Text);
            setOption("quartertableprice", txtQuarterTable.Text);
            setOption("overduepercentage", txtOverduePercentage.Text);

            string date = dtpOverdueDate.Value.Year.ToString() + "-";
            date = date + (dtpOverdueDate.Value.Month.ToString().Length < 2 ? "0" : "") + dtpOverdueDate.Value.Month.ToString() + "-";
            date = date + (dtpOverdueDate.Value.Day.ToString().Length < 2 ? "0" : "") + dtpOverdueDate.Value.Day.ToString();

            setOption("overduedate", date);

            SQLConnection.LogAction("Updated Pricing preferences.", this.User);

            MessageBox.Show("Pricing Updated.");
        }

        private bool setOption(string optionName, string optionValue)
        {
            MySqlCommand query = new MySqlCommand("UPDATE `options` SET `value`= @VALUE WHERE  `option` = @OPTION;", SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@OPTION", optionName);
            query.Parameters.AddWithValue("@VALUE", optionValue);
            SQLResult results = this.SQLConnection.Query(query);
            return results.successful();

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
    }
}
