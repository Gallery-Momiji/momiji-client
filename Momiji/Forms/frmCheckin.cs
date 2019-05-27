using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmCheckin : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private NodeStore merchStore;
		private NodeStore gsmerchStore;
		private int artistID;
		private bool printsummary;
		//Cached data:
		SQLResult merchCache, GSmerchCache;

		/////////////////////////
		//  Public Functions   //
		/////////////////////////

		public void RefreshInfo()
		{
			StockNode.clearTable(ref lstMerch, ref merchStore);
			StockNode.clearTable(ref lstGSMerch, ref gsmerchStore);

			SQL SQLConnection = parent.currentSQLConnection;
			//Load minimal data for now
			MySqlCommand info = new MySqlCommand("SELECT `ArtistCheckIn` FROM `artists` WHERE `ArtistID` = @ID;",
									SQLConnection.GetConnection());

			info.Prepare();
			info.Parameters.AddWithValue("@ID", artistID);

			SQLResult temp = SQLConnection.Query(info);

			if (!(temp.successful()) || temp.GetNumberOfRows() == 0)
			{
				MessageBox.Show(this, MessageType.Error,
					"Could not load artist information.\nPlease try again, and if this issue persists, please contact your administrator.");
				return;
			}

			if (temp.getCell("ArtistCheckIn", 0) == "True")
			{
				MessageBox.Show(this, MessageType.Warning,
					"Warning, this artist is already checked in.");
				btnCheckIn.Sensitive = false;
			}

			MySqlCommand merchData = new MySqlCommand("SELECT `MerchID`,`MerchTitle`,`MerchMinBid`,`MerchQuickSale`,`MerchAAMB` FROM `merchandise` WHERE `ArtistID` = @ID;",
										 SQLConnection.GetConnection());
			merchData.Prepare();
			merchData.Parameters.AddWithValue("@ID", artistID);

			merchCache = SQLConnection.Query(merchData);
			if (merchCache.GetNumberOfRows() > 0)
			{
				for (int i = 0; i < merchCache.GetNumberOfRows(); i++)
				{
					merchStore.AddNode(new StockNode(
						merchCache.getCellInt("MerchID", i),
						merchCache.getCell("MerchTitle", i),
						merchCache.getCell("MerchMinBid", i),
						merchCache.getCell("MerchQuickSale", i),
						merchCache.getCellInt("MerchAAMB", i))
					);
				}
			}

			MySqlCommand GSmerchData = new MySqlCommand("SELECT `PieceID`,`PieceTitle`,`PiecePrice`,`PieceInitialStock`,`PieceSDC` FROM `gsmerchandise` WHERE `ArtistID` = @ID;",
										   SQLConnection.GetConnection());
			GSmerchData.Prepare();
			GSmerchData.Parameters.AddWithValue("@ID", artistID);

			GSmerchCache = SQLConnection.Query(GSmerchData);
			if (GSmerchCache.GetNumberOfRows() > 0)
			{
				for (int i = 0; i < GSmerchCache.GetNumberOfRows(); i++)
				{
					gsmerchStore.AddNode(new StockNode(
						GSmerchCache.getCellInt("PieceID", i),
						GSmerchCache.getCell("PieceTitle", i),
						GSmerchCache.getCell("PiecePrice", i),
						GSmerchCache.getCellInt("PieceInitialStock", i),
						GSmerchCache.getCellInt("PieceSDC", i))
					);
				}
			}
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmCheckin(int artistID, frmMenu parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.artistID = artistID;
			this.printsummary = false;
			this.Build();
			StockNode.buildTableMerch(ref lstMerch, ref merchStore);
			StockNode.buildTableGSMerch(ref lstGSMerch, ref gsmerchStore);

			this.Title += " (Artist #" + artistID.ToString() + ")";

			RefreshInfo();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnCancelClicked(object sender, EventArgs e)
		{
			this.Destroy();
		}

		protected void OnBtnEditArtistClicked(object sender, EventArgs e)
		{
			MessageBox.Show(this, MessageType.Info, "If any changes need to be made, excluding removal of items, please remember to click the service fee checkbox.");

			switch (tabControlMerch.CurrentPage)
			{
				case 0:
					new frmMerchEditor(artistID, parent, this, merchCache);
					break;
				case 1:
					new frmGSManager(artistID, parent, this, GSmerchCache);
					break;
			}
		}

		protected void OnBtnCheckInClicked(object sender, EventArgs e)
		{
			if (!printsummary)
			{
				MessageBox.Show(this, MessageType.Error, "Please review all items with the artist and if they are happy with it, print the summary and have time sign it.\n\nIf any changes or additions (not including removals) need to be done, please make the changes above, click on the service fee checkbox, and reprint the summary.");
				return;
			}
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand update = new MySqlCommand("UPDATE `artists` SET `ArtistCheckIn`=1,`ArtistDue`=`ArtistDue`+@FEE WHERE `ArtistID`=@ID",
									  SQLConnection.GetConnection());
			update.Prepare();
			update.Parameters.AddWithValue("@ID", artistID);
			if (chkService.Active)
				update.Parameters.AddWithValue("@FEE", 10);
			else
				update.Parameters.AddWithValue("@FEE", 0);

			SQLResult result = SQLConnection.Query(update);
			if (result.successful())
				MessageBox.Show(this, MessageType.Info,
					"Artist checked in!");
			else
				MessageBox.Show(this, MessageType.Error,
					"Connection Error, please try again.");

			this.Destroy();
		}

		protected void OnBtnPrintSummaryClicked(object sender, EventArgs e)
		{
			if (chkService.Active)
				Process.Start("http://" + parent.currentSQLConnection.getHost() + "/checkin.php?fee=10&id=" + artistID);
			else
				Process.Start("http://" + parent.currentSQLConnection.getHost() + "/checkin.php?id=" + artistID);
			printsummary = MessageBox.Ask(this, "Did you show the artist all of our records? Did they see no issues with it?");
		}

		protected void OnChkServiceToggled(object sender, EventArgs e)
		{
			if (chkService.Active)
				MessageBox.Show(this, MessageType.Info, "If the artist is able to pay now, remember to balance their account and print a receipt, so they do not get charged at checkout.");
		}
	}
}

