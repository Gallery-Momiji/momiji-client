using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmArtistCheckout : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int artistID;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmArtistCheckout (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.artistID = artistID;
			this.Build ();

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT `ArtistName`,`ArtistCheckedOut` FROM `artists` WHERE `ArtistID` = @ID;", SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@ID", this.artistID);

			SQLResult results = SQLConnection.Query (query);
			if (results.successful ()) {
				if (results.getCellInt ("ArtistCheckedOut", 0) == 1) {
					btnMarkCheckout.Sensitive = false;
					MessageBox.Show (this, MessageType.Warning,
						"Artist already marked as Checked Out.");
				}

				lblArtistID.Text = artistID.ToString();
				lblArtistName.Text = results.getCell ("ArtistName", 0);
			} else {
				MessageBox.Show (this, MessageType.Error,
					"An error occured finding this Artists' details!");
				this.Destroy ();
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnGenSaleSumClicked (object sender, EventArgs e)
		{
			Process.Start ("http://" + parent.currentSQLConnection.getHost () + "/momiji/checkout.php?id=" + artistID);
		}

		protected void OnBtnMarkCheckoutClicked (object sender, EventArgs e)
		{
			if (chkStep1.Active && chkStep2.Active && chkStep3.Active) {
				SQL SQLConnection = parent.currentSQLConnection;
				MySqlCommand checkinQuery = new MySqlCommand ("UPDATE `artists` SET `ArtistCheckedOut`=1 WHERE  `ArtistID`=@ID;", SQLConnection.GetConnection ());
				checkinQuery.Prepare ();
				checkinQuery.Parameters.AddWithValue ("@ID", this.artistID);
				SQLResult checkinQueryResults = SQLConnection.Query (checkinQuery);

				if (checkinQueryResults.successful ()) {
					MessageBox.Show (this, MessageType.Info, "Artist successfully checked out");
					this.Destroy ();
				} else {
					MessageBox.Show (this, MessageType.Error, "Error Checking Out artist.\nPlease try again, and if this issue persists, please contact your administrator.");
				}
			} else {
				MessageBox.Show (this, MessageType.Error, "Please make sure you followed all steps and checked each box after completing each action.");
			}
		}

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
			this.Destroy ();
		}
	}
}

