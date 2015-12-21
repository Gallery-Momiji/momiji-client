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
    public partial class frmArtistAdd : Form
    {

        public SQL SQLConnection;
        public SQLResult User;
        public int action;
        public int artistID;

        public frmArtistAdd(SQL Link, SQLResult UserIdentifier, int action, int artistID)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            this.action = action;
            this.artistID = artistID;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtArtistID_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void txtArtistName_TextChanged(object sender, EventArgs e)
        {
            this.txtArtistID_TextChanged(sender, e);
        }

        private void txtArtistAddress_TextChanged(object sender, EventArgs e)
        {
            this.txtArtistID_TextChanged(sender, e);
        }

        private void txtArtistPhone_TextChanged(object sender, EventArgs e)
        {
            this.txtArtistID_TextChanged(sender, e);
        }

        private void txtArtistWebsite_TextChanged(object sender, EventArgs e)
        {
            this.txtArtistID_TextChanged(sender, e);
        }

        private void txtAgentName_TextChanged(object sender, EventArgs e)
        {
            this.txtArtistID_TextChanged(sender, e);
        }

        private void txtAgentAddress_TextChanged(object sender, EventArgs e)
        {
            this.txtArtistID_TextChanged(sender, e);
        }

        private void txtAddressPhone_TextChanged(object sender, EventArgs e)
        {
            this.txtArtistID_TextChanged(sender, e);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            bool ready = false;
            ready = (txtArtistAddress.Text.Length != 0) &&
                    (txtArtistName.Text.Length != 0) &&
                    (txtArtistID.Text.Length != 0) &&
                    (txtArtistPhone.Text.Length != 0);

            switch (this.action){
                case 3:
                    if (ready)
                    {
                        btnAdd.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show("One or more fields are missing, you need AT LEAST an artist's Name, ID, Address and Phone. Everything else is optional", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case 0:
                    if (ready)
                    {
                        btnUpdate.Enabled = true;
                    }
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"This is where you put the Artist's ID

Example : 12

Where 12 is the ID Number, the AN/PN is done in the Database automagically.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Literally, Artist's LEGAL name", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Literally, Artist's LEGAL address", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Literally, Artist's Phone Number", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Artist's Portfolio Website (Usually where they demo their artwork)", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"(Optional)Artist's Agent's name", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"(Optional)Artist's Agent's Legal Address", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"(Optional)Artist's Agent's Phone Number", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DialogResult generate = MessageBox.Show("Are you sure you want me to check the database for an ID?", "Generate ID", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (generate == DialogResult.Yes)
            {

                MySqlCommand query = new MySqlCommand("SELECT COUNT(`ArtistID`)+1 as `last_id` FROM `artists` limit 0,1;", SQLConnection.GetConnection());
                query.Prepare();

                SQLResult results = this.SQLConnection.Query(query);

                txtArtistID.Text = results.getCell("last_id",0);

                SQLConnection.LogAction("Generated ID for Artist Registration", this.User);
                MessageBox.Show("Seems like the latest ID I can make for this artist is " + results.getCell("last_id", 0).ToString(), "Got it!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            MySqlCommand query = new MySqlCommand("INSERT INTO `artists` (`ArtistID`, `ArtistName`, `ArtistEmail`, `ArtistAddress`, `ArtistUrl`, `ArtistAgentName`, `ArtistAgentPhone`, `ArtistPhone`, `ArtistAgentAddress`, `ArtistAgentEmail`, `ArtistShowName`) VALUES (@ID, @NAME, @EMAIL, @ADDRESS, @URL, @AGENTNAME, @AGENTPHONE, @PHONE, @AGENTADDRESS, @AGENTEMAIL, @ARTISTSHOWNAME);", SQLConnection.GetConnection());

            //@ID, @NAME, @EMAIL, @ADDRESS, @URL, @AGENTNAME, @AGENTPHONE, @PHONE, @AGENTADDRESS, @AGENTEMAIL
            query.Prepare();
            query.Parameters.AddWithValue("@ID", txtArtistID.Text);
            query.Parameters.AddWithValue("@NAME", txtArtistName.Text);
            query.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
            query.Parameters.AddWithValue("@ADDRESS", txtArtistAddress.Text);
            query.Parameters.AddWithValue("@URL", txtArtistWebsite.Text);
            query.Parameters.AddWithValue("@AGENTNAME", txtAgentName.Text);
            query.Parameters.AddWithValue("@AGENTPHONE", txtAgentPhone.Text);
            query.Parameters.AddWithValue("@PHONE", txtArtistPhone.Text);
            query.Parameters.AddWithValue("@AGENTADDRESS", txtAgentAddress.Text);
            query.Parameters.AddWithValue("@AGENTEMAIL", txtAgentEmail.Text);
            query.Parameters.AddWithValue("@ARTISTSHOWNAME", txtArtistShowName.Text);

            SQLResult results = this.SQLConnection.Query(query);

            if (results.successful())
            {
                SQLConnection.LogAction("Added artist named " + txtArtistName.Text, this.User);
                MessageBox.Show("Artist Created! Clearing all fields...");
                txtArtistID.Text = "";
                txtArtistName.Text= "";
                txtEmail.Text= "";
                txtArtistAddress.Text= "";
                txtArtistWebsite.Text= "";
                txtAgentName.Text= "";
                txtAgentPhone.Text= "";
                txtArtistPhone.Text= "";
                txtAgentAddress.Text= "";
                txtAgentEmail.Text = "";
                txtArtistShowName.Text = "";
            }
            else
            {
                MessageBox.Show("Could not add Artist, Something went wrong!", "Oh noes!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"(Optional)Artist's Agent's email", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Artist's email address", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmArtistAdd_Load(object sender, EventArgs e)
        {
            // 0 - Edit Artist
            // 1 - Delete Artist
            // 2 - Edit Artist's Merchandise
            // 3 - Add Artist
            switch(this.action)
            {
                case 0:

                    MySqlCommand query = new MySqlCommand("SELECT * FROM `artists` WHERE `ArtistID` = @id;", SQLConnection.GetConnection());
                    query.Prepare();
                    query.Parameters.AddWithValue("@id", this.artistID);

                    SQLResult results = this.SQLConnection.Query(query);

                    if (results.GetNumberOfRows() == 1)
                    {
                        txtAgentAddress.Text = results.getCell("ArtistAgentAddress", 0);
                        txtAgentEmail.Text = results.getCell("ArtistAgentEmail", 0);
                        txtAgentPhone.Text = results.getCell("ArtistAgentPhone", 0);
                        txtAgentName.Text = results.getCell("ArtistAgentName", 0);
                        txtArtistID.Text = this.artistID.ToString();
                        txtArtistName.Text = results.getCell("ArtistName", 0);
                        txtEmail.Text  = results.getCell("ArtistEmail", 0);
                        txtArtistAddress.Text = results.getCell("ArtistAddress",0);
                        txtArtistWebsite.Text = results.getCell("ArtistUrl", 0);
                        txtArtistPhone.Text = results.getCell("ArtistPhone", 0);
                        txtArtistShowName.Text = results.getCell("ArtistShowName", 0);
                        btnAdd.Visible = false;
                        btnUpdate.Visible = true;
                        btnUpdate.Enabled = false;
                        txtArtistID.Enabled = false;
                        btnGenerate.Enabled = false;
                        this.Text = "Edit Artist";
                    }
                    else
                    {
                        MessageBox.Show("An internal error occured. This program tried to load an artist that does not exist. Exiting...", "UH OH!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Application.Exit();

                    }

                    break;
                default:

                    break;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MySqlCommand query = new MySqlCommand("UPDATE `artists` SET `ArtistName` = @NAME , `ArtistEmail` = @EMAIL, `ArtistAddress` = @ADDRESS, `ArtistUrl` = @URL, `ArtistAgentName` = @AGENTNAME, `ArtistAgentPhone` = @AGENTPHONE, `ArtistPhone` = @PHONE, `ArtistAgentAddress` = @AGENTADDRESS, `ArtistAgentEmail` = @AGENTEMAIL, `ArtistShowName`= @ARTISTSHOWNAME WHERE `ArtistID` = @ID;", SQLConnection.GetConnection());

            //@ID, @NAME, @EMAIL, @ADDRESS, @URL, @AGENTNAME, @AGENTPHONE, @PHONE, @AGENTADDRESS, @AGENTEMAIL
            query.Prepare();
            query.Parameters.AddWithValue("@ID", txtArtistID.Text);
            query.Parameters.AddWithValue("@NAME", txtArtistName.Text);
            query.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
            query.Parameters.AddWithValue("@ADDRESS", txtArtistAddress.Text);
            query.Parameters.AddWithValue("@URL", txtArtistWebsite.Text);
            query.Parameters.AddWithValue("@AGENTNAME", txtAgentName.Text);
            query.Parameters.AddWithValue("@AGENTPHONE", txtAgentPhone.Text);
            query.Parameters.AddWithValue("@PHONE", txtArtistPhone.Text);
            query.Parameters.AddWithValue("@AGENTADDRESS", txtAgentAddress.Text);
            query.Parameters.AddWithValue("@AGENTEMAIL", txtAgentEmail.Text);
            query.Parameters.AddWithValue("@ARTISTSHOWNAME", txtArtistShowName.Text);

            SQLResult results = this.SQLConnection.Query(query);

            if (results.successful())
            {
                SQLConnection.LogAction("Artist updated : " + txtArtistName.Text, this.User);
                MessageBox.Show("Artist Updated");

            }
            else
            {
                MessageBox.Show("Could not add Artist, Something went wrong!", "Oh noes!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"Some artists don't like using their real name when showing their art publicly.
This is where you put the 'nickname' they go by.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
