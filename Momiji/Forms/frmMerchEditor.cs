using System;
using System.Text;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmMerchEditor : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int artistID;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmMerchEditor (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.artistID = artistID;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		//TODO//

		protected void OnBtnGenIDClicked (object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT MAX(`PieceID`)+1 as `next_id` FROM `merchandise` limit 0,1;", SQLConnection.GetConnection ());
			query.Prepare ();

			SQLResult results = SQLConnection.Query (query);

			txtPieceID.Text = results.getCell ("next_id", 0);
		}

		protected void OnBtnUpdateClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnBtnAddClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnBtnClearClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnBtnDeleteClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnBtnCreateSheetClicked (object sender, EventArgs e)
		{
			string pieceid =
				String.Format ("PN{0:D3}-" + txtPieceID.Text.PadLeft (3, '0'),
					artistID);
			string filename =
				SaveFileDialog.rtf (this,
					"Save bidder sheet to file",
					"PN" + artistID.ToString () + ".rtf");

			if (filename != "") {
				string output = ""; //TODO// RTF template
				output = output.Replace ("PIECE_ID", pieceid);
				output = output.Replace ("ARTIST_ID", lblArtistName.Text);
				output = output.Replace ("PIECE_TITLE", txtPieceTitle.Text);
				output = output.Replace ("PIECE_MEDIUM", txtMedium.Text);
				output = output.Replace ("PIECE_MINBID", "$" + txtPieceMinimumBid.Text);
				output = output.Replace ("PIECE_QS", (txtQuickSale.Text == "0" || txtQuickSale.Text == "" ? "N/A" : "$" + txtQuickSale.Text));
				output = output.Replace ("PIECE_MS", (chkAAMB.Active ? "YES" : "NO"));

				try {
					System.IO.File.WriteAllText (filename, output);
				} catch (Exception d) {
					MessageBox.Show (this, MessageType.Error,
						"Unable to save file:\n" + d.Message.ToString ());
				}
			}
		}

		protected void OnBtnGenCSClicked (object sender, EventArgs e)
		{
			string filename =
				SaveFileDialog.rtf (this,
					"Save control sheet to file",
					"PN" + artistID.ToString () + ".rtf");

			if (filename != "") {
				string output = ""; //TODO// RTF template

				try {
					System.IO.File.WriteAllText (filename, output);
				} catch (Exception d) {
					MessageBox.Show (this, MessageType.Error,
						"Unable to save file:\n" + d.Message.ToString ());
				}
			}
		}

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}
	}
}

