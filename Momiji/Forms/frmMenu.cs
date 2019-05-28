using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmMenu : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmLogin LoginForm;
		private frmGSSale GSSaleForm;
		private frmAuctionSale AuctionSaleForm;
		private frmSearchArtist SearchArtistForm;
		private frmSearchDate SearchDateForm;
		private SQL SQLConnection;
		private SQLResult User;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void CloseForm()
		{
			this.SQLConnection.LogAction("Logged Out", this.User);
			SQLConnection.Close();

			if (AuctionSaleForm != null)
				AuctionSaleForm.Destroy();
			if (GSSaleForm != null)
				GSSaleForm.Destroy();
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			if (SearchDateForm != null)
				SearchDateForm.Destroy();
			LoginForm.Show();
			LoginForm.GrabFocus();
			this.Destroy();
		}

		/////////////////////////
		//  Public Functions   //
		/////////////////////////

		/// <summary>
		/// This should be called when the user closes frmGSSale.
		/// </summary>
		public void CleanupGSSale()
		{
			GSSaleForm = null;
		}

		/// <summary>
		/// This should be called when the user closes frmAuctionSale.
		/// </summary>
		public void CleanupAuctionSale()
		{
			AuctionSaleForm = null;
		}

		/// <summary>
		/// This should be called when the user closes frmSearchArtist.
		/// </summary>
		public void CleanupSearchDate()
		{
			SearchDateForm = null;
		}

		/// <summary>
		/// This should be called when the user closes frmSearchArtist.
		/// </summary>
		public void CleanupSearchArtist()
		{
			SearchArtistForm = null;
		}

		/////////////////////////
		//  Public Accessors   //
		/////////////////////////

		public SQLResult currentUser
		{
			get { return User; }
		}

		public SQL currentSQLConnection
		{
			get { return SQLConnection; }
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmMenu(SQL SQLConnection, SQLResult results, frmLogin parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.LoginForm = parent;
			this.SQLConnection = SQLConnection;
			this.User = results;
			this.Build();

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
			//		Bidder Lookup
			//  7 - Manage artist stock
			//  8 - View Activity logs
			//  9 - View Monetary activity logs
			// 10 - Manage Treasury - refunds
			// 11 - Administrator
			////////////////////////////
			int userClass = User.getCellInt("class", 0);

			//Welcome Message:
			string userRank = userClass.ToString();
			if (userClass >= 11)
				userRank += " (Administrator)";
			else if (userClass >= 4)
				userRank += " (Advanced User)";
			else if (userClass >= 1)
				userRank += " (Basic User)";
			else
				userRank += " (No privileges)";
			lblGreeting.Text = "Welcome " + User.getCell("name", 0) + ", Your Rank is " + userRank;

			//Basic Functionality:
			btnGalleryStoreSale.Sensitive = userClass >= 1 ? true : false;
			btnAuctionSale.Sensitive = userClass >= 2 ? true : false;

			//Advanced Functionality:
			reprintReceiptAction.Sensitive = userClass >= 4 ? true : false;
			checkInAction.Sensitive = userClass >= 5 ? true : false;
			checkOutAction.Sensitive = userClass >= 6 ? true : false;
			manageArtistAction.Sensitive = userClass >= 7 ? true : false;
			usersPrefAction.Sensitive = userClass >= 11 ? true : false;
			biddersAction.Sensitive = userClass >= 6 ? true : false;
			generateBiddingSheetsAction.Sensitive = userClass >= 6 ? true : false;
			checkUserActivitiesAction.Sensitive = userClass >= 8 ? true : false;
			checkReceiptsAction.Sensitive = userClass >= 9 ? true : false;
			checkSalesAction.Sensitive = userClass >= 9 ? true : false;
			refundAction.Sensitive = userClass >= 10 ? true : false;
			manageArtistBalanceAction.Sensitive = userClass >= 10 ? true : false;
			SetInitialFloatAction.Sensitive = userClass >= 10 ? true : false;
			ManualPayoutAction.Sensitive = userClass >= 10 ? true : false;
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args)
		{
			CloseForm();
		}

		//File

		protected void OnCloseActionActivated(object sender, EventArgs e)
		{
			CloseForm();
		}

		protected void OnQuitActionActivated(object sender, EventArgs e)
		{
			this.SQLConnection.LogAction("Logged Out", this.User);
			SQLConnection.Close();

			if (AuctionSaleForm != null)
				AuctionSaleForm.Destroy();
			if (GSSaleForm != null)
				GSSaleForm.Destroy();
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			LoginForm.Destroy();
			this.Destroy();
			Application.Quit();
		}

		//Artists

		protected void OnCheckInActionActivated(object sender, EventArgs e)
		{
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			SearchArtistForm = new frmSearchArtist(frmSearchArtist.Operations.ArtistCheckin, this);
		}

		protected void OnCheckOutActionActivated(object sender, EventArgs e)
		{
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			SearchArtistForm = new frmSearchArtist(frmSearchArtist.Operations.ArtistCheckout, this);
		}

		//Artists > Manage

		protected void OnAddArtistActionActivated(object sender, EventArgs e)
		{
			//Negative ID means to make a new artist
			new frmArtistAdd(this);
		}

		protected void OnEditArtistActionActivated(object sender, EventArgs e)
		{
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			SearchArtistForm = new frmSearchArtist(frmSearchArtist.Operations.EditArtist, this);
		}

		protected void OnEditMerchandiseActionActivated(object sender, EventArgs e)
		{
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			SearchArtistForm = new frmSearchArtist(frmSearchArtist.Operations.EditMerchandise, this);
		}

		protected void OnEditGalleryStoreMerchandiseActionActivated(object sender, EventArgs e)
		{
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			SearchArtistForm = new frmSearchArtist(frmSearchArtist.Operations.EditGalleryStore, this);
		}

		protected void OnManageArtistBalanceActionActivated(object sender, EventArgs e)
		{
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			SearchArtistForm = new frmSearchArtist(frmSearchArtist.Operations.ManageArtistBalance, this);
		}

		//Tools

		protected void OnCheckSalesActionActivated(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://" + SQLConnection.getHost() + "/summary.php");
		}

		protected void OnRefundActionActivated(object sender, EventArgs e)
		{
			if (SearchDateForm != null)
				SearchDateForm.Destroy();
			SearchDateForm = new frmSearchDate(frmSearchDate.Operations.Refund, this);
		}

		protected void OnReprintReceiptActionActivated(object sender, EventArgs e)
		{
			new frmReceipts(this);
		}

		protected void OnCheckReceiptsActionActivated(object sender, EventArgs e)
		{
			if (SearchDateForm != null)
				SearchDateForm.Destroy();
			SearchDateForm = new frmSearchDate(frmSearchDate.Operations.CheckReceipts, this);
		}

		protected void OnCheckUserActivitiesActionActivated(object sender, EventArgs e)
		{
			if (SearchDateForm != null)
				SearchDateForm.Destroy();
			SearchDateForm = new frmSearchDate(frmSearchDate.Operations.CheckUserActivities, this);
		}

		protected void OnGenerateBiddingSheetsActionActivated(object sender, EventArgs e)
		{
			string filename =
				SaveFileDialog.rtf(this,
					"Save bidder sheets to file",
					"BiddingSheets.rtf");

			if (filename != "")
			{
				MySqlCommand artistquery = new MySqlCommand("SELECT `ArtistID`,`ArtistName` FROM `artists` ORDER BY `ArtistID`;",
											   SQLConnection.GetConnection());
				artistquery.Prepare();
				SQLResult artists = SQLConnection.Query(artistquery);

				if (artists.GetNumberOfRows() >= 1)
				{
					Biddersheet bidsheet = new Biddersheet(filename);

					for (int i = 0; i < artists.GetNumberOfRows(); i++)
					{
						MySqlCommand merchquery = new MySqlCommand("SELECT `MerchID`,`MerchTitle`,`MerchMinBid`,`MerchAAMB`,`MerchQuickSale`,`MerchMedium` FROM `merchandise` WHERE `ArtistID` = @ID ORDER BY `MerchID`;",
													  SQLConnection.GetConnection());
						merchquery.Prepare();
						merchquery.Parameters.AddWithValue("@ID", artists.getCellInt("ArtistID", i));
						SQLResult merch = SQLConnection.Query(merchquery);

						for (int j = 0; j < merch.GetNumberOfRows(); j++)
						{
							bidsheet.AddSheet(artists.getCell("ArtistID", i), merch.getCell("MerchID", j), artists.getCell("ArtistName", i),
								merch.getCell("MerchTitle", j), merch.getCell("MerchMedium", j), merch.getCell("MerchMinBid", j),
								merch.getCell("MerchQuickSale", j), merch.getCellInt("MerchAAMB", j) == 1);
						}
					}
					bidsheet.Finish();
					MessageBox.Show(this, MessageType.Info,
						"Bidder Sheets generated!");
				}
				else
				{
					MessageBox.Show(this, MessageType.Error,
						"Unable to find any artists");
				}
			}
		}

		//Preferences

		protected void OnUserPreferencesActionActivated(object sender, EventArgs e)
		{
			new frmUserEdit(User.getCellInt("id", 0), this);
		}

		protected void OnBiddersActionActivated(object sender, EventArgs e)
		{
			new frmBidders(this);
		}

		//Preferences > Users

		protected void OnAddUserActionActivated(object sender, EventArgs e)
		{
			new frmUserAdd(this);
		}

		protected void OnEditUserActionActivated(object sender, EventArgs e)
		{
			new frmUserEdit(this);
		}

		//About

		protected void OnAboutActionActivated(object sender, EventArgs e)
		{
			new AboutBox();
		}

		//Buttons

		protected void OnBtnAuctionSaleClicked(object sender, EventArgs e)
		{
			if (AuctionSaleForm != null)
				AuctionSaleForm.Present();
			else
				AuctionSaleForm = new frmAuctionSale(this);
		}

		protected void OnBtnGalleryStoreSaleClicked(object sender, EventArgs e)
		{
			if (GSSaleForm != null)
				GSSaleForm.Present();
			else
				GSSaleForm = new frmGSSale(this);
		}

		protected void OnBtnLogoutClicked(object sender, EventArgs e)
		{
			CloseForm();
		}

		protected void OnArtistGenBidsheetActionActivated(object sender, EventArgs e)
		{
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			SearchArtistForm = new frmSearchArtist(frmSearchArtist.Operations.GenerateBiddersheets, this);
		}

		protected void OnArtistGenBarcodeActionActivated(object sender, EventArgs e)
		{
			if (SearchArtistForm != null)
				SearchArtistForm.Destroy();
			SearchArtistForm = new frmSearchArtist(frmSearchArtist.Operations.GenerateBarcodes, this);
		}

		protected void OnSetInitialFloatActionActivated(object sender, EventArgs e)
		{
			string floatstring = "";
			MySqlCommand query = new MySqlCommand("Select `price` from receipts where `id` = 1;",
				currentSQLConnection.GetConnection());
			query.Prepare();
			SQLResult results = currentSQLConnection.Query(query);

			if (results.GetNumberOfRows() > 0)
			{
				floatstring = results.getCell("price", 0);
				if (!MessageBox.Ask(this,
					"The initial float is already defined as $" + floatstring +
					".\nDo you want to update it?"))
				{
					return;
				}
			}
			if (MessageBox.Entry(this, "Set Initial Float", ref floatstring))
			{
				if (!float.TryParse(floatstring, out float val))
				{
					MessageBox.Show(this, MessageType.Error, "Invalid Number!");
					return;
				}

				query = new MySqlCommand("DELETE FROM `receipts` WHERE `id`= 1; INSERT INTO `receipts` ( `id`, `userID`, `price`, `paid`, `itemArray`, `priceArray`, `timestamp`, `date`) VALUES ( 1, @UID, @AMOUNT, @AMOUNT, 'FLOAT#', '" + val.ToString() + "#', CURRENT_TIME, CURRENT_DATE);",
				currentSQLConnection.GetConnection());
				query.Prepare();
				query.Parameters.AddWithValue("@UID", User.getCell("id", 0));
				query.Parameters.AddWithValue("@AMOUNT", val);
				results = currentSQLConnection.Query(query);

				if (!results.successful())
				{
					MessageBox.Show(this, MessageType.Error, "Unable to update float!");
				}
			}
		}

		protected void OnRemoveActionActivated(object sender, EventArgs e)
		{
			string floatstring = "";
			if (MessageBox.Entry(this, "Manual Payout", ref floatstring))
			{
				if (!float.TryParse(floatstring, out float val))
				{
					MessageBox.Show(this, MessageType.Error, "Invalid Number!");
					return;
				}

				if (!MessageBox.Ask(this,
					"Are you sure you want to make a payout of $" +
					floatstring + "?"))
				{
					return;
				}
				val *= -1;

				MySqlCommand query = new MySqlCommand("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `itemArray`, `priceArray`, `timestamp`, `date`) VALUES ( @UID, @AMOUNT, @AMOUNT, 'MANUAL PAYOUT#', '" + val.ToString() + "#', CURRENT_TIME, CURRENT_DATE); SELECT LAST_INSERT_ID() as `id`;",
				currentSQLConnection.GetConnection());
				query.Prepare();
				query.Parameters.AddWithValue("@UID", User.getCell("id", 0));
				query.Parameters.AddWithValue("@AMOUNT", val);
				SQLResult results = currentSQLConnection.Query(query);

				if (results.successful())
				{
					MessageBox.Show(this, MessageType.Info,
						"Payout processed. This was transaction ID #"
						+ results.getCellInt("id", 0));
				}
				else
				{
					MessageBox.Show(this, MessageType.Error, "Unable to update float!");
				}
			}
		}
	}
}

