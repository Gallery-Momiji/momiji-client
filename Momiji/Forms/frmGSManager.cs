using System;
using System.IO;
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
		private frmCheckin parent2;
		private NodeStore merchStore;
		private int artistID;
		StockNode selectednode;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void LoadInfo (int ID, frmMenu parent, SQLResult merch)
		{
			this.parent = parent;
			this.artistID = ID;
			this.Build ();
			lblArtistID.Text = ID.ToString ();
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
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT `ArtistName` FROM `artists` WHERE `ArtistID` = @ID;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@ID", artistID);

			SQLResult results = SQLConnection.Query (query);
			lblArtistName.Text = results.getCell ("ArtistName", 0);

			selectednode = null;
			btnAdd.Sensitive = true;
			btnDelete.Sensitive = false;
			btnUpdate.Sensitive = false;

			//TODO not done
			btnGenCS.Sensitive = false;
		}

		/////////////////////////
		//     Contructors     //
		/////////////////////////

		//This pulls fresh data
		public frmGSManager (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent2 = null;
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand merchData = new MySqlCommand ("SELECT `PieceID`,`PieceTitle`,`PiecePrice`,`PieceStock`,`PieceSDC` FROM `gsmerchandise` WHERE `ArtistID` = @ID;",
				                         SQLConnection.GetConnection ());
			merchData.Prepare ();
			merchData.Parameters.AddWithValue ("@ID", artistID);

			LoadInfo (artistID, parent, SQLConnection.Query (merchData));
		}

		//This loads cached data directly
		public frmGSManager (int artistID, frmMenu parent, frmCheckin parent2, SQLResult merchResults) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent2 = parent2;
			LoadInfo (artistID, parent, merchResults);
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnGenIDClicked (object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT MAX(`PieceID`)+1 as `next_id` FROM `gsmerchandise` WHERE `ArtistID` = @ID limit 0,1;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@ID", artistID);

			SQLResult results = SQLConnection.Query (query);

			txtPieceID.Text = results.getCell ("next_id", 0);

			btnAdd.Sensitive = true;
			btnDelete.Sensitive = false;
			btnUpdate.Sensitive = false;
		}

		protected void OnBtnUpdateClicked (object sender, EventArgs e)
		{
			if (txtPieceTitle.Text == "" ||
			    txtPricePerUnit.Text == "" ||
			    txtGivenStock.Text == "") {
				MessageBox.Show (this, MessageType.Error,
					"Please fill in all the fields");
				return;
			}

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("UPDATE `gsmerchandise` SET `PieceTitle`=@TITLE, `PiecePrice`=@PRICE,`PieceSDC`=@SDC,`PieceStock`=@STOCK,`PieceInitialStock`=@ISTOCK WHERE `ArtistID` = @AID AND `PieceID` = @PID;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", artistID);
			query.Parameters.AddWithValue ("@PID", txtPieceID.Text);
			query.Parameters.AddWithValue ("@TITLE", txtPieceTitle.Text);
			query.Parameters.AddWithValue ("@PRICE", txtPricePerUnit.Text);
			query.Parameters.AddWithValue ("@SDC", chkSDC.Active ? 1 : 0);
			query.Parameters.AddWithValue ("@ISTOCK", txtGivenStock.Text);
			query.Parameters.AddWithValue ("@STOCK", txtStock.Text);

			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				//Update list
				int.TryParse (txtPieceID.Text, out selectednode.PieceID);
				selectednode.PieceTitle = txtPieceTitle.Text;
				selectednode.PieceMinPrice = "$" + txtPricePerUnit.Text;
				selectednode.PieceOther = txtStock.Text;
				selectednode.PieceBool = chkSDC.Active ? "Yes" : "No";

				MessageBox.Show (this, MessageType.Info,
					"Updated piece successfully.");
				OnBtnClearClicked (sender, e);
			} else {
				MessageBox.Show (this, MessageType.Error,
					"Could not update piece.\nPlease contact your administrator.\");");
			}
		}

		protected void OnBtnAddClicked (object sender, EventArgs e)
		{
			if (txtPieceID.Text == "" ||
			    txtPieceTitle.Text == "" ||
			    txtPricePerUnit.Text == "" ||
			    txtGivenStock.Text == "") {
				MessageBox.Show (this, MessageType.Error,
					"Please fill in all the fields");
				return;
			}

			int pieceid;
			if (!int.TryParse (txtPieceID.Text, out pieceid)) {
				MessageBox.Show (this, MessageType.Error,
					"Invalid Piece ID");
				return;
			}

			int stock;
			if (!int.TryParse (txtStock.Text, out stock)) {
				MessageBox.Show (this, MessageType.Error,
					"Invalid Piece ID");
				return;
			}

			//Make sure it doesn't already exist
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT `PieceID` FROM `gsmerchandise` WHERE `ArtistID`=@AID AND `PieceID`=@PID;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", artistID);
			query.Parameters.AddWithValue ("@PID", pieceid);

			SQLResult results = SQLConnection.Query (query);

			if (results.GetNumberOfRows () > 0) {
				MessageBox.Show (this, MessageType.Error,
					"This Piece ID is already taken");
				return;
			}

			SQLConnection = parent.currentSQLConnection;
			query = new MySqlCommand ("INSERT INTO `gsmerchandise` (`ArtistID`, `PieceID`, `PieceTitle`, `PiecePrice`,`PieceSDC`,`PieceInitialStock`,`PieceStock`) VALUES (@AID, @PID, @TITLE, @PRICE, @SDC, @ISTOCK, @STOCK);",
				SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", artistID);
			query.Parameters.AddWithValue ("@PID", txtPieceID.Text);
			query.Parameters.AddWithValue ("@TITLE", txtPieceTitle.Text);
			query.Parameters.AddWithValue ("@PRICE", txtPricePerUnit.Text);
			query.Parameters.AddWithValue ("@SDC", chkSDC.Active ? 1 : 0);
			query.Parameters.AddWithValue ("@ISTOCK", txtGivenStock.Text);
			query.Parameters.AddWithValue ("@STOCK", stock);

			results = SQLConnection.Query (query);

			if (results.successful ()) {//todo check if piece exists
				merchStore.AddNode (new StockNode (
					pieceid,
					txtPieceTitle.Text,
					txtPricePerUnit.Text,
					stock,
					chkSDC.Active ? 1 : 0)
				);
				MessageBox.Show (this, MessageType.Info,
					"Added new piece successfully.");
				OnBtnClearClicked (sender, e);
			} else {
				MessageBox.Show (this, MessageType.Error,
					"Could not add piece, please try again.\nHint: Does this piece id already exist? If so, did you mean to hit update?");
			}
		}

		protected void OnBtnClearClicked (object sender, EventArgs e)
		{
			txtPieceID.Text = "";
			txtPieceTitle.Text = "";
			txtPricePerUnit.Text = "";
			txtGivenStock.Text = "";
			txtStock.Text = "";
			chkSDC.Active = false;
		}

		protected void OnBtnDeleteClicked (object sender, EventArgs e)
		{
			if (!MessageBox.Ask (this, "Are you sure you want to delete this piece?"))
				return;

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("DELETE FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", artistID);
			query.Parameters.AddWithValue ("@PID", txtPieceID.Text);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				//Update list
				//TODO workaround for now, i don't know how to delete specific nodes
				selectednode.PieceID = 0;
				selectednode.PieceTitle = "DELETED";
				selectednode.PieceMinPrice = "";
				selectednode.PieceOther = "";
				selectednode.PieceBool = "";

				MessageBox.Show (this, MessageType.Info, "Piece deleted successfully");
				OnBtnClearClicked (sender, e);
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not delete piece.\nPlease contact your administrator.");
			}
		}

		protected void OnBtnGenBarcodeClicked (object sender, EventArgs e)
		{
			string pieceid =
				String.Format ("PN{0:D3}-" + txtPieceID.Text.PadLeft (3, '0'),
					artistID);
			float price;
			if (!float.TryParse (txtPricePerUnit.Text, out price)) {
				MessageBox.Show (this, MessageType.Error, "Invalid price listed");
				return;
			}
			string filename =
				SaveFileDialog.rtf (this,
					"Save barcode to file",
					pieceid + "barcode.rtf");

			if (filename != "") {
				Barcodes barcode = new Barcodes (filename);
				barcode.AddCode (pieceid, price);
				barcode.Finish ();
				MessageBox.Show (this, MessageType.Info,
					"Barcode generated!");
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
					File.WriteAllText (filename, output);
				} catch (Exception d) {
					MessageBox.Show (this, MessageType.Error,
						"Unable to save file:\n" + d.Message.ToString ());
				}
			}
		}

		protected void OnBtnCloseClicked (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void OnLstMerchRowActivated (object o, RowActivatedArgs args)
		{
			StockNode selectednode = (StockNode)merchStore.GetNode((TreePath)args.Path);

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT `PieceInitialStock` FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", artistID);
			query.Parameters.AddWithValue ("@PID", selectednode.PieceID);

			SQLResult results = SQLConnection.Query (query);
			txtGivenStock.Text = results.getCell ("PieceInitialStock", 0);

			txtPieceID.Text = selectednode.PieceID.ToString ();
			txtPieceTitle.Text = selectednode.PieceTitle;
			txtPricePerUnit.Text = selectednode.PieceMinPrice.Substring (1, selectednode.PieceMinPrice.Length - 1);
			txtStock.Text = selectednode.PieceOther;
			chkSDC.Active = selectednode.PieceBool == "Yes";

			btnAdd.Sensitive = false;
			btnDelete.Sensitive = true;
			btnUpdate.Sensitive = true;
			//Workaround for mono bug
			this.selectednode = selectednode;
		}

		protected void OnTxtPieceIDChanged (object sender, EventArgs e)
		{
			btnAdd.Sensitive = true;
			btnDelete.Sensitive = false;
			btnUpdate.Sensitive = false;
		}

		protected void OnDeleteEvent (object sender, EventArgs e)
		{
			if (parent2 != null)
				parent2.RefreshInfo ();
		}

		protected void OnChkSDCToggled (object sender, EventArgs e)
		{
			if (chkSDC.Active)
				MessageBox.Show (this, MessageType.Info, "Remember to add one to the stock, as the stock should include the display copy as well.");
		}
	}
}

