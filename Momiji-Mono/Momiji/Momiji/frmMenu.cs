using System;
using Gtk;

namespace Momiji
{
	public partial class frmMenu : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmLogin LoginForm;
		private frmGSSale GSSaleForm;
		private frmQuickSale QuickSaleForm;
		private frmAuctionSale AuctionSaleForm;
		private SQL SQLConnection;
		private SQLResult User;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void CloseForm ()
		{
			this.SQLConnection.LogAction ("Logged Out", this.User);
			SQLConnection.Close ();

			if (QuickSaleForm != null)
				QuickSaleForm.Destroy ();
			if (AuctionSaleForm != null)
				AuctionSaleForm.Destroy ();
			if (GSSaleForm != null)
				GSSaleForm.Destroy ();
			LoginForm.Show ();
			LoginForm.GrabFocus ();
			this.Destroy ();
		}

		/////////////////////////
		//  Public Functions   //
		/////////////////////////

		/// <summary>
		/// This should be called when the user closes frmGSSale.
		/// </summary>
		public void CleanupGSSale ()
		{
			GSSaleForm = null;
		}

		/// <summary>
		/// This should be called when the user closes frmQuickSale.
		/// </summary>
		public void CleanupQuickSale ()
		{
			QuickSaleForm = null;
		}

		/// <summary>
		/// This should be called when the user closes frmAuctionSale.
		/// </summary>
		public void CleanupAuctionSale ()
		{
			AuctionSaleForm = null;
		}

		/////////////////////////
		//  Public Accessors   //
		/////////////////////////

		public SQLResult currentUser {
			get { return User;}
		}

		public SQL currentSQLConnection {
			get { return SQLConnection;}
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmMenu (SQL SQLConnection, SQLResult results, frmLogin parent) :
				base(Gtk.WindowType.Toplevel)
		{
			this.LoginForm = parent;
			this.SQLConnection = SQLConnection;
			this.User = results;
			this.Build ();

			////////////////////////////
			// User class explanation //
			////////////////////////////
			// Basic Functionality:
			//  1 - Gallery Store Sales
			//  2 - Quick Sales
			//  3 - Auction Sales
			// Advanced Functionality:
			//  4 - Re-Print Receipts
			//  5 - Check-in Artists
			//  6 - Generate Bidding sheets,
			//      Check-out Artists
			//  7 - Manage artist stock
			//  8 - View Activity logs
			//  9 - View Monetary activity logs
			// 10 - Manage Treasury
			// 11 - Administrator
			////////////////////////////
			int userClass = User.getCellInt ("class", 0);

			//Welcome Message:
			string userRank = userClass.ToString ();
			if (userClass >= 11)
				userRank += " (Administrator)";
			else if (userClass >= 4)
				userRank += " (Advanced User)";
			else if (userClass >= 1)
				userRank += " (Basic User)";
			else
				userRank += " (No privileges)";
			lblGreeting.Text = "Welcome " + User.getCell ("name", 0) +
								", Your Rank is " + userRank;

			//Basic Functionality:
			btnGalleryStoreSale.Sensitive = userClass >= 1 ? true : false;
			btnQuickSale.Sensitive = userClass >= 2 ? true : false;
			//TODO should be block until a certain time, except admin
			btnAuctionSale.Sensitive = userClass >= 3 ? true : false;

			//Advanced Functionality:
			//TODO Advanced functions not implemented
			//receiptRePrintToolStripMenuItem.Sensitive = userClass >= 4 ? true : false;
			//checkInToolStripMenuItem.Sensitive = userClass >= 5 ? true : false;
			//checkOutToolStripMenuItem.Sensitive = userClass >= 6 ? true : false;
			//generateBiddingSheetsToolStripMenuItem.Sensitive = userClass >= 6 ? true : false;
			//manageToolStripMenuItem.Sensitive = userClass >= 7 ? true : false;
			//checkUserActivitiesToolStripMenuItem.Sensitive = userClass >= 8 ? true : false;
			//checkLatestReceiptsToolStripMenuItem.Sensitive = userClass >= 9 ? true : false;
			//pricingToolStripMenuItem.Sensitive = userClass == 11 ? true : false;
			//usersToolStripMenuItem.Sensitive = userClass == 11 ? true : false;
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			CloseForm ();
		}

		protected void OnBtnLogoutClicked (object sender, System.EventArgs e)
		{
			CloseForm ();
		}

		protected void OnExitActionActivated (object sender, System.EventArgs e)
		{
			CloseForm ();
		}

		protected void OnBtnQuickSaleClicked (object sender, System.EventArgs e)
		{
			if (QuickSaleForm != null)
				QuickSaleForm.Present ();
			else
				QuickSaleForm = new frmQuickSale (this);
		}

		protected void OnBtnAuctionSaleClicked (object sender, System.EventArgs e)
		{
			if (AuctionSaleForm != null)
				AuctionSaleForm.Present ();
			else
				AuctionSaleForm = new frmAuctionSale (this);
		}

		protected void OnBtnGalleryStoreSaleClicked (object sender, System.EventArgs e)
		{
			if (GSSaleForm != null)
				GSSaleForm.Present ();
			else
				GSSaleForm = new frmGSSale (this);
		}

		protected void OnQuitActionActivated (object sender, System.EventArgs e)
		{
			this.SQLConnection.LogAction ("Logged Out", this.User);
			SQLConnection.Close ();

			if (QuickSaleForm != null)
				QuickSaleForm.Destroy ();
			if (AuctionSaleForm != null)
				AuctionSaleForm.Destroy ();
			if (GSSaleForm != null)
				GSSaleForm.Destroy ();
			LoginForm.Destroy ();
			this.Destroy ();
			Application.Quit ();
		}
	}
}

