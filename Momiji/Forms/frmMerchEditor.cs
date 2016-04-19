using System;
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
		private NodeStore merchStore;
		private int artistID;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void LoadInfo (int ID, frmMenu parent, SQLResult merch)
		{
			this.parent = parent;
			this.artistID = ID;
			this.Build ();
			StockNode.buildTableMerch (ref lstMerch, ref merchStore);

			if (merch.GetNumberOfRows () > 0) {
				for (int i = 0; i < merch.GetNumberOfRows (); i++) {
					merchStore.AddNode (new StockNode (
						merch.getCellInt ("MerchID", i),
						merch.getCell ("MerchTitle", i),
						merch.getCell ("MerchMinBid", i),
						merch.getCell ("MerchQuickSale", i),
						merch.getCellInt ("MerchAAMB", i))
					);
				}
			}
		}

		/////////////////////////
		//     Contructors     //
		/////////////////////////

		//This pulls fresh data
		public frmMerchEditor (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand merchData = new MySqlCommand ("SELECT `MerchID`,`MerchTitle`,`MerchMinBid`,`MerchQuickSale`,`MerchAAMB` FROM `merchandise` WHERE `ArtistID` = @ID;",
				SQLConnection.GetConnection ());
			merchData.Prepare ();
			merchData.Parameters.AddWithValue ("@ID", artistID);

			LoadInfo (artistID, parent, SQLConnection.Query (merchData));
		}

		//This can be used to load cached data directly
		public frmMerchEditor (int artistID, frmMenu parent, SQLResult merchResults) :
			base (Gtk.WindowType.Toplevel)
		{
			LoadInfo (artistID, parent, merchResults);
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		//TODO//

		protected void OnBtnGenIDClicked (object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT MAX(`PieceID`)+1 as `next_id` FROM `merchandise` limit 0,1;",
				SQLConnection.GetConnection ());
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

