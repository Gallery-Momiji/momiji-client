using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmArtistCheckinGallery : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private Gtk.NodeStore merchStore;
		int artistID;

		/////////////////////////
		//  Public Functions   //
		/////////////////////////

		public frmArtistCheckinGallery (int artistID, frmMenu parent) :
				base(Gtk.WindowType.Toplevel)
		{
			this.artistID = artistID;
			this.parent = parent;
			SQL SQLConnection = parent.currentSQLConnection;

			SQLConnection.LogAction ("Loaded GS merch for artist #" + artistID, parent.currentUser);
			MySqlCommand query = new MySqlCommand ("SELECT ArtistName, ArtistGSCheckedIn FROM `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@ID", artistID);

			SQLResult results = SQLConnection.Query (query);

			if (results.GetNumberOfRows () != 1) {
				MessageBox.Show (this, MessageType.Error, "This artist does not exist");
				this.Destroy ();
			}

			lblArtistID.Text = artistID.ToString ();
			lblArtistName.Text = results.getCell ("ArtistName", 0);

			if (results.getCellInt ("ArtistGSCheckedIn", 0) == 1) {
				MessageBox.Show (this, Gtk.MessageType.Error, "This artist already checked in!");
				this.Destroy ();
			}

			MySqlCommand merchData = new MySqlCommand ("SELECT * FROM `gsmerchandise` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection ());
			merchData.Prepare ();
			merchData.Parameters.AddWithValue ("@ID", artistID);

			SQLResult merchResults = SQLConnection.Query (merchData);
			if (merchResults.GetNumberOfRows () > 0) {
				int i;
				for (i = 0; i < merchResults.GetNumberOfRows(); i++) {
					merchStore.AddNode (new MerchNode (merchResults.getCellInt ("PieceID", i),
									merchResults.getCell ("PieceTitle", i),
									merchResults.getCell ("PiecePrice", i),
									merchResults.getCellInt ("PieceInitialStock", i),
									merchResults.getCellInt ("PieceStock", i),
									merchResults.getCellInt ("PieceSDC", i) == 1
									));
				}

			}

			MerchNode.buildTable (ref lstMerch, ref merchStore);
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnCheckInClicked (object sender, EventArgs e)
		{
			if (chkBinder.Active && chkGSCS.Active && chkMatch.Active) {
				SQL SQLConnection = parent.currentSQLConnection;
				MySqlCommand checkinQuery = new MySqlCommand ("UPDATE `artists` SET `ArtistGSCheckedIn`=1 WHERE `ArtistID`=@ID;", SQLConnection.GetConnection ());
				checkinQuery.Prepare ();
				checkinQuery.Parameters.AddWithValue ("@ID", this.artistID);
				SQLResult checkinQueryResults = SQLConnection.Query (checkinQuery);

				if (checkinQueryResults.successful ())
					MessageBox.Show (this, MessageType.Info, "Artist is not checked in");
				else
					MessageBox.Show (this, MessageType.Error, "Error checking in artist");
			} else {

				MessageBox.Show (this, MessageType.Warning, "Please make sure you completed all steps in the list above.");
				return;
			}
		}
	}
}
