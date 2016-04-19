using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmGSManager : Gtk.Window
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
			StockNode.buildTableGSMerch (ref lstMerch, ref merchStore);

			if (merch.GetNumberOfRows () > 0) {
				for (int i = 0; i < merch.GetNumberOfRows (); i++) {
					merchStore.AddNode (new StockNode (
						merch.getCellInt ("PieceID", i),
						merch.getCell ("PieceTitle", i),
						merch.getCell ("PiecePrice", i),
						merch.getCellInt ("PieceStock", i),
						merch.getCellInt ("PieceSDC", i))
					);
				}
			}
		}

		/////////////////////////
		//     Contructors     //
		/////////////////////////

		//This pulls fresh data
		public frmGSManager (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand merchData = new MySqlCommand ("SELECT `PieceID`,`PieceTitle`,`PiecePrice`,`PieceStock`,`PieceSDC` FROM `GSmerchandise` WHERE `ArtistID` = @ID;",
				                         SQLConnection.GetConnection ());
			merchData.Prepare ();
			merchData.Parameters.AddWithValue ("@ID", artistID);

			LoadInfo (artistID, parent, SQLConnection.Query (merchData));
		}

		//This loads cached data directly
		public frmGSManager (int artistID, frmMenu parent, SQLResult merchResults) :
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
			MySqlCommand query = new MySqlCommand ("SELECT MAX(`PieceID`)+1 as `next_id` FROM `gsmerchandise` limit 0,1;",
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

		protected void OnBtnGenBarcodeClicked (object sender, EventArgs e)
		{
			string pieceid =
				String.Format ("PN{0:D3}-" + txtPieceID.Text.PadLeft (3, '0'),
					artistID);
			string filename =
				SaveFileDialog.rtf (this,
					"Save barcode to file",
					pieceid + "barcode.rtf");

			if (filename != "") {
				string output = ""; //TODO// RTF template
				output = output.Replace ("PIECE_ID", pieceid);

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

		//TODO// Rename this button
		protected void OnButton6Clicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}
	}
}

