using System;
using Gtk;
using MySql.Data.MySqlClient;

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
		//Cached data:
		SQLResult merchCache, GSmerchCache;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void RefreshInfo ()
		{
			SQL SQLConnection = parent.currentSQLConnection;
			//Load minimal data for now
			MySqlCommand info = new MySqlCommand ("SELECT `ArtistCheckIn` FROM `artists` WHERE `ArtistID` = @ID;",
				SQLConnection.GetConnection ());

			info.Prepare ();
			info.Parameters.AddWithValue ("@ID", artistID);

			SQLResult temp = SQLConnection.Query (info);

			if (!(temp.successful ()) || temp.GetNumberOfRows () == 0) {
				MessageBox.Show (this, MessageType.Error,
					"Could not load artist information.\nPlease try again, and if this issue persists, please contact your administrator.");
				return;
			}

			if (temp.getCell ("ArtistCheckIn", 0) == "True") {
				MessageBox.Show (this, MessageType.Warning,
					"Warning, this artist is already checked in.");
				btnCheckIn.Sensitive = false;
			}

			MySqlCommand merchData = new MySqlCommand ("SELECT `MerchID`,`MerchTitle`,`MerchMinBid`,`MerchQuickSale`,`MerchAAMB` FROM `merchandise` WHERE `ArtistID` = @ID;",
				                         SQLConnection.GetConnection ());
			merchData.Prepare ();
			merchData.Parameters.AddWithValue ("@ID", artistID);

			merchCache = SQLConnection.Query (merchData);
			if (merchCache.GetNumberOfRows () > 0) {
				for (int i = 0; i < merchCache.GetNumberOfRows (); i++) {
					merchStore.AddNode (new StockNode (
						merchCache.getCellInt ("MerchID", i),
						merchCache.getCell ("MerchTitle", i),
						merchCache.getCell ("MerchMinBid", i),
						merchCache.getCell ("MerchQuickSale", i),
						merchCache.getCellInt ("MerchAAMB", i))
					);
				}
			}

			MySqlCommand GSmerchData = new MySqlCommand ("SELECT `PieceID`,`PieceTitle`,`PiecePrice`,`PieceStock`,`PieceSDC` FROM `gsmerchandise` WHERE `ArtistID` = @ID;",
				                           SQLConnection.GetConnection ());
			GSmerchData.Prepare ();
			GSmerchData.Parameters.AddWithValue ("@ID", artistID);

			GSmerchCache = SQLConnection.Query (GSmerchData);
			if (GSmerchCache.GetNumberOfRows () > 0) {
				for (int i = 0; i < GSmerchCache.GetNumberOfRows (); i++) {
					gsmerchStore.AddNode (new StockNode (
						GSmerchCache.getCellInt ("PieceID", i),
						GSmerchCache.getCell ("PieceTitle", i),
						GSmerchCache.getCell ("PiecePrice", i),
						GSmerchCache.getCellInt ("PieceStock", i),
						GSmerchCache.getCellInt ("PieceSDC", i))
					);
				}
			}
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmCheckin (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.artistID = artistID;
			this.Build ();
			StockNode.buildTableMerch (ref lstMerch, ref merchStore);
			StockNode.buildTableGSMerch (ref lstGSMerch, ref gsmerchStore);

			this.Title += " (Artist #" + artistID.ToString() + ")";

			RefreshInfo ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void OnBtnEditArtistClicked (object sender, EventArgs e)
		{
			switch (tabControlMerch.CurrentPage) {
			case 0:
				new frmMerchEditor (artistID, parent, merchCache);
				break;
			case 1:
				new frmGSManager (artistID, parent, GSmerchCache);
				break;
			}
		}

		protected void OnBtnReloadClicked (object sender, EventArgs e)
		{
			//TODO// This should be done automatically
			StockNode.clearTable (ref lstMerch, ref merchStore);
			StockNode.clearTable (ref lstGSMerch, ref gsmerchStore);

			RefreshInfo ();
		}

		protected void OnBtnCheckInClicked (object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand update = new MySqlCommand ("UPDATE `artists` SET `ArtistCheckIn`=1 WHERE  `ArtistID`=@ID",
				                      SQLConnection.GetConnection ());
			update.Prepare ();
			update.Parameters.AddWithValue ("@ID", artistID);

			SQLResult result = SQLConnection.Query (update);
			if (result.successful ())
				MessageBox.Show (this, MessageType.Info,
					"Artist checked in!");
			else
				MessageBox.Show (this, MessageType.Error,
					"Connection Error, please try again.");

			this.Destroy ();
		}
	}
}

