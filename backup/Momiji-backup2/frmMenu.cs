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
            this.SQLConnection.LogAction("Logged Out", this.User);
            LoginForm.Show();
            this.Hide();
            LoginForm.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            lblGreeting.Text = "Welcome, " + User.getCell("name", 0) + "! Your Rank is " + User.getCell("class",0) + "/11!";
            // So, I've decided to work more on the class system.
            // The higher it is, the more access you have!
            // You are only able to use this software during the event primarily if you're a level 3 or above.
            // Please see the code above to decide who can use what.

            int userClass = User.getCellInt("class", 0);
            
            // User class explanation:
            // 1 - Can do Gallery Store Sales
            // 2 - Can do Quick Sales
            // 3 - Can do Auction Sales     -- Can do essentials in POS system!
            // 4 - Can Re-Print Receipts
            // 5 - Can Check-in Artists
            // 6 - Generate Bidding sheets / checkout
            // 7 - Manage artists' stock
            // 8 - check the activity logs
            // 9 - check the monetary activity logs
            // 10 - Treasury
            // 11 - Everything else
            btnGalleryStoreSale.Enabled = userClass >= 1 ? true : false;
            btnQuickSale.Enabled = userClass >= 2 ? true : false;
            btnAuctionSale.Enabled = userClass >= 3 ? true : false;
            receiptRePrintToolStripMenuItem.Enabled = userClass >= 4 ? true : false;
            checkInToolStripMenuItem.Enabled = userClass >= 5 ? true : false;
            checkOutToolStripMenuItem.Enabled = userClass >= 6 ? true : false;
            generateBiddingSheetsToolStripMenuItem.Enabled = userClass >= 6 ? true : false;
            manageToolStripMenuItem.Enabled = userClass >= 7 ? true : false;
            checkUserActivitiesToolStripMenuItem.Enabled = userClass >= 8 ? true : false;
            checkLatestReceiptsToolStripMenuItem.Enabled = userClass >= 9 ? true : false;
            pricingToolStripMenuItem.Enabled = userClass == 11 ? true : false;
            usersToolStripMenuItem.Enabled = userClass == 11 ? true : false;

            object banner = Properties.Resources.ResourceManager.GetObject(User.getCell("banner",0));
            if (banner != null)
            {
                picBanner.Image = (Image)banner;
            }
            else
            {
                picBanner.Image = Properties.Resources.newbie;

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

Through it, we can help artists check-in/out, manage sales, make sales,
etc... All in the same place and format!","What is this?", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            MessageBox.Show(@"Depending on your rank, certain things might be greyed out. That means you have yet to have training on them.

Ask Tiago to help you by teaching you what you want to know! But remember, there might be things you'll
have to learn beforehand!", "Why can't I use certain features?", MessageBoxButtons.OK, MessageBoxIcon.Question);
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

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void galleryStoreCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void auctionCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchArtistByIDToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(5, this.SQLConnection, this.User);   // Checkin by ID
            src.Show();
        }

        private void searchArtistByNameToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(5, this.SQLConnection, this.User);    // mass gen bid sheets by name
            src.Show();
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Mgmt.frmUserRemove src = new User_Mgmt.frmUserRemove(this.SQLConnection, this.User);
            src.Show();
        }

        private void salesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option will now redirect you to a browser window.");
            System.Diagnostics.Process.Start("http://" + SQLConnection.getHost() + "/momiji/summary.php");

        }

        private void searchArtistByIDToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(7, this.SQLConnection, this.User);
            src.Show();
        }

        private void searchArtistByNAmeToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(7, this.SQLConnection, this.User);
            src.Show();
        }

        private void searchArtistByIDToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmSearchArtistById src = new frmSearchArtistById(8, this.SQLConnection, this.User);
            src.Show();
        }

        private void searchArtistByNAmeToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmSearchArtistByName src = new frmSearchArtistByName(8, this.SQLConnection, this.User);
            src.Show();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserEdit usr = new frmUserEdit(this.SQLConnection, this.User);
            usr.Show();
        }

    }
}
