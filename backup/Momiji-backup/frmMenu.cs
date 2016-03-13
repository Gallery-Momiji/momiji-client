using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Momiji
{
    public partial class frmMenu : Form
    {
        public bool forceclose = false;
        public SQL SQLConnection;
        public SQLResult User;
        public frmLogin LoginForm;


        public frmMenu(SQL Link, SQLResult UserIdentifier, frmLogin parent)
        {
            this.LoginForm = parent;
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.exitToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                this.SQLConnection.LogAction("Logged Out", this.User);
                LoginForm.Dispose();
                Application.Exit();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            lblGreeting.Text = "Welcome, " + User.getCell("name", 0);
            if (User.getCell("class", 0) != "10")
            {
                treasuryToolStripMenuItem.Enabled = false;
                artistsToolStripMenuItem.Enabled = false;
                logToolStripMenuItem.Enabled = false;
                preferencesToolStripMenuItem.Enabled = false;
                btnAuctionSale.Enabled = false;
            }
        }

        private void addArtistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArtistAdd tmpArtistAdd = new frmArtistAdd(this.SQLConnection, this.User, 3, 0);
            tmpArtistAdd.Show();
        }

        private void searchByIDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(0, this.SQLConnection, this.User);   // Edit by ID
            src.Show();
        }

        private void searchByNameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(0, this.SQLConnection, this.User);    // edit by name
            src.Show();
        }

        private void searchByIDToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(1, this.SQLConnection, this.User);    // delete by ID
            src.Show();
        }

        private void searchByNameToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(1, this.SQLConnection, this.User);    // delete by Name
            src.Show();
        }

        private void searchArtistByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(2, this.SQLConnection, this.User);   // Edit merchandise by ID
            src.Show();              
        }

        private void searchArtistByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(2, this.SQLConnection, this.User);   // Edit merchandise by Name
            src.Show();
        }

        private void checkUserActivitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLog tmpLog = new frmLog(this.SQLConnection, this.User);
            tmpLog.Show();
        }

        private void whatIsThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SQLConnection.LogAction("Asked what this is", this.User);
            MessageBox.Show(@"This is the Point-Of-Sale system for Gallery Momiji @ Anime North. 
This program was designed to manage the gallery completely!

Through it, we can do anything from changing your name to Nancy, 
to miraculously make Artists' do the chicken dance!","What is this?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void whatDoIDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SQLConnection.LogAction("Asked what to do", this.User);
            MessageBox.Show(@"Depending on your assigned position, you will handle gallery store sales,
quick sales, or auction sales. Pretty simple, huh?", "What do I do?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void whyCantIUseCertainFeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SQLConnection.LogAction("Asked why certain features are locked", this.User);
            MessageBox.Show(@"Depending on your role within the gallery, certain features might be disabled/enabled for you,
This had to be done because Mike Tyson threatened to kill the programmer if he didn't.", "Why can't I use certain features?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 tmpAbout = new AboutBox1();
            tmpAbout.Show(); 
        }

        private void btnQuickSale_Click(object sender, EventArgs e)
        {
            frmQuickSale quickSale = new frmQuickSale(this.SQLConnection, this.User);
            quickSale.Show();
        }

        private void searchArtistByIDToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(3, this.SQLConnection, this.User);    // mass gen bid sheets by ID
            src.Show();
        }

        private void searchArtistByNameToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(3, this.SQLConnection, this.User);    // mass gen bid sheets by name
            src.Show();
        }

        private void pricingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPricing pricing = new frmPricing(this.SQLConnection, this.User);
            pricing.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(4, this.SQLConnection, this.User);    // mass gen bid sheets by ID
            src.Show();
        }

        private void searchArtistByNameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(4, this.SQLConnection, this.User);    // mass gen bid sheets by name
            src.Show();
        }

        private void searchArtistByIDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(5, this.SQLConnection, this.User);    // mass gen bid sheets by ID
            src.Show();
        }

        private void searchArtistByNameToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(5, this.SQLConnection, this.User);    // mass gen bid sheets by name
            src.Show();
        }

        private void searchArtistByIDToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(6, this.SQLConnection, this.User);    // mass gen bid sheets by ID
            src.Show();
        }

        private void searchArtistByNameToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(6, this.SQLConnection, this.User);    // mass gen bid sheets by name
            src.Show();
        }

        private void receiptRePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReceiptReprint reprint = new frmReceiptReprint(SQLConnection, User);
            reprint.Show();
        }

        private void btnAuctionSale_Click(object sender, EventArgs e)
        {
            frmAuctionSale auction = new frmAuctionSale(SQLConnection, User);
            auction.Show();
        }

        private void btnGalleryStoreSale_Click(object sender, EventArgs e)
        {
            frmGSSale gssale = new frmGSSale(SQLConnection, User);
            gssale.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserAdd test = new frmUserAdd(this.SQLConnection, this.User);
            test.Show();

        }

  
 
      

       
    }
}