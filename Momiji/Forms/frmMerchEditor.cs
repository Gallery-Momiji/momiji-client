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
		private frmCheckin parent2;
		private NodeStore merchStore;
		private int artistID;
		StockNode selectednode;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void LoadInfo(int ID, frmMenu parent, SQLResult merch)
		{
			this.parent = parent;
			this.artistID = ID;
			this.Build();
			lblArtistID.Text = ID.ToString();
			StockNode.buildTableMerch(ref lstMerch, ref merchStore);

			if (merch.GetNumberOfRows() > 0)
			{
				for (int i = 0; i < merch.GetNumberOfRows(); i++)
				{
					merchStore.AddNode(new StockNode(
						merch.getCellInt("MerchID", i),
						merch.getCell("MerchTitle", i),
						merch.getCell("MerchMinBid", i),
						merch.getCell("MerchQuickSale", i),
						merch.getCellInt("MerchAAMB", i))
					);
				}
			}
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("SELECT `ArtistName` FROM `artists` WHERE `ArtistID` = @ID;",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@ID", artistID);

			SQLResult results = SQLConnection.Query(query);
			lblArtistName.Text = results.getCell("ArtistName", 0);

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
		public frmMerchEditor(int artistID, frmMenu parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.parent2 = null;
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand merchData = new MySqlCommand("SELECT `MerchID`,`MerchTitle`,`MerchMinBid`,`MerchQuickSale`,`MerchAAMB` FROM `merchandise` WHERE `ArtistID` = @ID;",
										 SQLConnection.GetConnection());
			merchData.Prepare();
			merchData.Parameters.AddWithValue("@ID", artistID);

			LoadInfo(artistID, parent, SQLConnection.Query(merchData));
		}

		//This can be used to load cached data directly
		public frmMerchEditor(int artistID, frmMenu parent, frmCheckin parent2, SQLResult merchResults) :
			base(Gtk.WindowType.Toplevel)
		{
			this.parent2 = parent2;
			LoadInfo(artistID, parent, merchResults);
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnGenIDClicked(object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("SELECT MAX(`MerchID`)+1 as `next_id` FROM `merchandise` WHERE `ArtistID` = @ID limit 0,1;",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@ID", artistID);

			SQLResult results = SQLConnection.Query(query);

			txtPieceID.Text = results.getCell("next_id", 0);

			selectednode = null;
			btnAdd.Sensitive = true;
			btnDelete.Sensitive = false;
			btnUpdate.Sensitive = false;
		}

		protected void OnBtnUpdateClicked(object sender, EventArgs e)
		{
			if (txtPieceTitle.Text == "" ||
				txtPieceMinimumBid.Text == "" ||
				txtQuickSale.Text == "" ||
				txtMedium.Text == "")
			{
				MessageBox.Show(this, MessageType.Error,
					"Please fill in all the fields");
				return;
			}

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("UPDATE `merchandise` SET `MerchTitle`=@TITLE, `MerchMinBid`=@MINBID,`MerchAAMB`=@AAMB,`MerchQuickSale`=@QS,`MerchMedium`=@MED WHERE `ArtistID` = @AID AND `MerchID` = @MID;",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@AID", artistID);
			query.Parameters.AddWithValue("@MID", txtPieceID.Text);
			query.Parameters.AddWithValue("@TITLE", txtPieceTitle.Text);
			query.Parameters.AddWithValue("@MINBID", txtPieceMinimumBid.Text);
			query.Parameters.AddWithValue("@AAMB", chkAAMB.Active ? 1 : 0);
			query.Parameters.AddWithValue("@QS", txtQuickSale.Text);
			query.Parameters.AddWithValue("@MED", txtMedium.Text);

			SQLResult results = SQLConnection.Query(query);

			if (results.successful())
			{
				//Update list
				int.TryParse(txtPieceID.Text, out selectednode.PieceID);
				selectednode.PieceTitle = txtPieceTitle.Text;
				selectednode.PieceMinPrice = "$" + txtPieceMinimumBid.Text;
				selectednode.PieceOther = "$" + txtQuickSale.Text;
				selectednode.PieceBool = chkAAMB.Active ? "Yes" : "No";

				MessageBox.Show(this, MessageType.Info,
					"Updated piece successfully.");
				OnBtnClearClicked(sender, e);
			}
			else
			{
				MessageBox.Show(this, MessageType.Error,
					"Could not update piece.\nPlease contact your administrator.\");");
			}
		}

		protected void OnBtnAddClicked(object sender, EventArgs e)
		{
			if (txtPieceID.Text == "" ||
				txtPieceTitle.Text == "" ||
				txtPieceMinimumBid.Text == "" ||
				txtQuickSale.Text == "" ||
				txtMedium.Text == "")
			{
				MessageBox.Show(this, MessageType.Error,
					"Please fill in all the fields");
				return;
			}

			int pieceid;
			if (!int.TryParse(txtPieceID.Text, out pieceid))
			{
				MessageBox.Show(this, MessageType.Error,
					"Invalid Piece ID");
				return;
			}

			//Make sure it doesn't already exist
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("SELECT `MerchID` FROM `merchandise` WHERE `ArtistID`=@AID AND `MerchID`=@MID;",
				SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@AID", artistID);
			query.Parameters.AddWithValue("@MID", pieceid);

			SQLResult results = SQLConnection.Query(query);

			if (results.GetNumberOfRows() > 0)
			{
				MessageBox.Show(this, MessageType.Error,
					"This Piece ID is already taken");
				return;
			}

			query = new MySqlCommand("INSERT INTO `merchandise` (`ArtistID`, `MerchID`, `MerchTitle`, `MerchMinBid`,`MerchAAMB`,`MerchQuickSale`,`MerchMedium`) VALUES (@AID, @MID, @TITLE, @MINBID, @AAMB, @QS, @MED);",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@AID", artistID);
			query.Parameters.AddWithValue("@MID", pieceid);
			query.Parameters.AddWithValue("@TITLE", txtPieceTitle.Text);
			query.Parameters.AddWithValue("@MINBID", txtPieceMinimumBid.Text);
			query.Parameters.AddWithValue("@AAMB", chkAAMB.Active ? 1 : 0);
			query.Parameters.AddWithValue("@QS", txtQuickSale.Text);
			query.Parameters.AddWithValue("@MED", txtMedium.Text);

			results = SQLConnection.Query(query);

			if (results.successful())
			{
				merchStore.AddNode(new StockNode(
					pieceid,
					txtPieceTitle.Text,
					txtPieceMinimumBid.Text,
					txtQuickSale.Text,
					chkAAMB.Active ? 1 : 0)
				);
				MessageBox.Show(this, MessageType.Info,
					"Added new piece successfully.");
				OnBtnClearClicked(sender, e);
			}
			else
			{
				MessageBox.Show(this, MessageType.Error,
					"Could not add piece, please try again.\nHint: Does this piece id already exist? If so, did you mean to hit update?");
			}
		}

		protected void OnBtnClearClicked(object sender, EventArgs e)
		{
			txtPieceID.Text = "";
			txtPieceTitle.Text = "";
			txtPieceMinimumBid.Text = "";
			txtQuickSale.Text = "";
			txtMedium.Text = "";
			chkAAMB.Active = false;
		}

		protected void OnBtnDeleteClicked(object sender, EventArgs e)
		{
			if (!MessageBox.Ask(this, "Are you sure you want to delete this piece?"))
				return;

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("DELETE FROM `merchandise` WHERE `ArtistID` = @AID AND `MerchID` = @MID;",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@AID", artistID);
			query.Parameters.AddWithValue("@MID", txtPieceID.Text);
			SQLResult results = SQLConnection.Query(query);

			if (results.successful())
			{
				//Update list
				//TODO workaround for now, i don't know how to delete specific nodes
				selectednode.PieceID = 0;
				selectednode.PieceTitle = "DELETED";
				selectednode.PieceMinPrice = "";
				selectednode.PieceOther = "";
				selectednode.PieceBool = "";

				MessageBox.Show(this, MessageType.Info, "Piece deleted successfully");
				OnBtnClearClicked(sender, e);
			}
			else
			{
				MessageBox.Show(this, MessageType.Error, "Could not delete piece.\nPlease contact your administrator.");
			}
		}

		protected void OnBtnCreateSheetClicked(object sender, EventArgs e)
		{
			string pieceid =
				String.Format("AN{0:D3}-" + txtPieceID.Text.PadLeft(3, '0'),
					artistID);
			string filename =
				SaveFileDialog.rtf(this,
					"Save bidder sheet to file",
					pieceid + ".rtf");

			if (filename != "")
			{
				Biddersheet bidsheet = new Biddersheet(filename);
				bidsheet.AddSheet(pieceid, lblArtistName.Text,
					txtPieceTitle.Text, txtMedium.Text, txtPieceMinimumBid.Text,
					txtQuickSale.Text, chkAAMB.Active);
				bidsheet.Finish();
				MessageBox.Show(this, MessageType.Info,
					"Bidder Sheet generated!");
			}
		}

		protected void OnBtnGenCSClicked(object sender, EventArgs e)
		{
			string filename =
				SaveFileDialog.rtf(this,
					"Save control sheet to file",
					"AN" + artistID.ToString() + ".rtf");

			if (filename != "")
			{
				string output = ""; //TODO// RTF template

				try
				{
					System.IO.File.WriteAllText(filename, output);
				}
				catch (Exception d)
				{
					MessageBox.Show(this, MessageType.Error,
						"Unable to save file:\n" + d.Message.ToString());
				}
			}
		}

		protected void OnBtnCloseClicked(object sender, EventArgs e)
		{
			this.Destroy();
		}

		protected void OnLstMerchRowActivated(object o, RowActivatedArgs args)
		{
			StockNode selectednode = (StockNode)merchStore.GetNode((TreePath)args.Path);

			if (selectednode.PieceID == 0)
				return;

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("SELECT `MerchMedium`,`MerchQuickSale` FROM `merchandise` WHERE `ArtistID` = @AID AND `MerchID` = @MID;",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@AID", artistID);
			query.Parameters.AddWithValue("@MID", selectednode.PieceID);

			SQLResult results = SQLConnection.Query(query);
			txtMedium.Text = results.getCell("MerchMedium", 0);
			txtQuickSale.Text = results.getCell("MerchQuickSale", 0);

			txtPieceID.Text = selectednode.PieceID.ToString();
			txtPieceTitle.Text = selectednode.PieceTitle;
			txtPieceMinimumBid.Text = selectednode.PieceMinPrice.Substring(1, selectednode.PieceMinPrice.Length - 1);
			chkAAMB.Active = selectednode.PieceBool == "Yes";

			btnAdd.Sensitive = false;
			btnDelete.Sensitive = true;
			btnUpdate.Sensitive = true;
			//Workaround for mono bug
			this.selectednode = selectednode;
		}

		protected void OnTxtPieceIDChanged(object sender, EventArgs e)
		{
			selectednode = null;
			btnAdd.Sensitive = true;
			btnDelete.Sensitive = false;
			btnUpdate.Sensitive = false;
		}

		protected void OnDeleteEvent(object sender, EventArgs e)
		{
			if (parent2 != null)
				parent2.RefreshInfo();
		}
	}
}

