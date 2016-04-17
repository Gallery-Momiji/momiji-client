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
		private Gtk.NodeStore merchStore;
		private Gtk.NodeStore gsmerchStore;
		private int artistID;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void RefreshInfo ()
		{
			//TODO// Clear tables, create tables, nodes
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand info = new MySqlCommand ("SELECT * FROM `artists` WHERE `ArtistID`=@ID",
				                    SQLConnection.GetConnection ());
			info.Prepare ();
			info.Parameters.AddWithValue ("@ID", artistID);

			SQLResult result = SQLConnection.Query (info);

			if (result.getCell ("ArtistCheckIn", 0) == "True") {
				MessageBox.Show (this, MessageType.Warning,
					"Warning, this artist is already checked in.");
				btnCheckIn.Sensitive = false;
			}

			//TODO// Load info into form
			MySqlCommand merchData = new MySqlCommand ("SELECT * FROM `merchandise` WHERE `ArtistID` = @ID;",
				                         SQLConnection.GetConnection ());
			merchData.Prepare ();
			merchData.Parameters.AddWithValue ("@ID", artistID);

			SQLResult merchResults = SQLConnection.Query (merchData);
			if (merchResults.GetNumberOfRows () > 0) {
				for (int i = 0; i < merchResults.GetNumberOfRows(); i++)
				{
					merchStore.AddNode (new StockNode (
						merchResults.getCellInt("MerchID", i),
						merchResults.getCell("MerchTitle", i),
						"$"+merchResults.getCell("MerchQuickSale", i),1,"")//TODO//
					);
				}
			}

			MySqlCommand GSmerchData = new MySqlCommand ("SELECT * FROM `GSmerchandise` WHERE `ArtistID` = @ID;",
				                           SQLConnection.GetConnection ());
			GSmerchData.Prepare ();
			GSmerchData.Parameters.AddWithValue ("@ID", artistID);

			SQLResult GSmerchResults = SQLConnection.Query (GSmerchData);
			if (GSmerchResults.GetNumberOfRows () > 0) {
				for (int i = 0; i < merchResults.GetNumberOfRows(); i++)
				{
					merchStore.AddNode (new StockNode (
						merchResults.getCellInt("PieceID", i),
						merchResults.getCell("PieceTitle", i),
						"$"+merchResults.getCell("PiecePrice", i),
						merchResults.getCellInt("PieceStock", i),
						merchResults.getCellInt("PieceStock", i)==1?"Yes":"No")
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
			StockNode.buildTable (ref lstMerch, ref merchStore);
			StockNode.buildTable (ref lstGSMerch, ref gsmerchStore);

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
#if DEBUG
			//TODO// Child forms aren't done
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnBtnReloadClicked (object sender, EventArgs e)
		{
			//TODO// This should be done automatically
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
				MessageBox.Show (this, MessageType.Error,
					"Artist checked in!");
			else
				MessageBox.Show (this, MessageType.Error,
					"Connection Error, please try again.");

			this.Destroy ();
		}
	}
}

