using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmSearchArtist : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private Operations operation;
		private NodeStore artistStore;
		private frmMenu parent;

		/////////////////////////
		//   Public Attributes //
		/////////////////////////

		public enum Operations
		{
			ArtistCheckin,
			ArtistCheckout,
			EditArtist,
			EditMerchandise,
			EditGalleryStore,
			ManageArtistBalance,
			GenerateBiddersheets,
			GenerateBarcodes
		}

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private string getSearchID()
		{
			//If numeric, return it, elsewise just return -1
			int number;
			if (int.TryParse(txtSearch.Text, out number))
				return txtSearch.Text;
			else
				return "-1";
		}

		private void SearchForArtist()
		{
			txtSearch.Text = txtSearch.Text.Trim();
			if (txtSearch.Text.Length == 0)
			{
				MessageBox.Show(this, MessageType.Error,
					"Nothing entered into the search field");
				return;
			}

			ArtistNode.clearTable(ref lstArtists, ref artistStore);
			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			SQLConnection.LogAction("Searched for artist", User);
			MySqlCommand query = new MySqlCommand("SELECT ArtistID, ArtistName, ArtistShowName FROM `artists` WHERE `ArtistID` = @ID OR `ArtistName` LIKE @name OR `ArtistShowName` LIKE @name;",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@name", '%' + txtSearch.Text + '%');
			query.Parameters.AddWithValue("@ID", getSearchID());

			SQLResult results = SQLConnection.Query(query);

			if (results.GetNumberOfRows() >= 1)
			{
				for (int i = 0; i < results.GetNumberOfRows(); i++)
				{
					artistStore.AddNode(new ArtistNode(results.getCellInt("ArtistID", i),
						results.getCell("ArtistName", i),
						results.getCell("ArtistShowName", i)));
				}
			}
			else
			{
				MessageBox.Show(this, MessageType.Info,
					"Could not find any artists");
			}
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmSearchArtist(Operations operation, frmMenu parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.operation = operation;
			this.parent = parent;
			this.Build();
			ArtistNode.buildTable(ref lstArtists, ref artistStore);

			//Set Window title
			switch (operation)
			{
				case Operations.ArtistCheckin:
					this.Title = "Search for Artist Check In";
					break;
				case Operations.ArtistCheckout:
					this.Title = "Search for Artist Check Out";
					break;
				case Operations.EditArtist:
					this.Title = "Search for Editing an Artist";
					break;
				case Operations.EditMerchandise:
					this.Title = "Search for Editing Merchandise";
					break;
				case Operations.EditGalleryStore:
					this.Title = "Search for Editing GS Merchandise";
					break;
				case Operations.ManageArtistBalance:
					this.Title = "Search for Managing Artist Balance";
					break;
				case Operations.GenerateBiddersheets:
					this.Title = "Search for Generating Bidder Sheets";
					break;
				case Operations.GenerateBarcodes:
					this.Title = "Search for Generating Bidder Sheets";
					break;
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent(object sender, EventArgs e)
		{
			parent.CleanupSearchArtist();
		}

		protected void OnTxtSearchActivated(object sender, EventArgs e)
		{
			SearchForArtist();
		}

		protected void OnBtnSearchClicked(object sender, EventArgs e)
		{
			SearchForArtist();
		}

		protected void OnLstArtistsRowActivated(object o, RowActivatedArgs args)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			ArtistNode selectednode = (ArtistNode)artistStore.GetNode((TreePath)args.Path);
			switch (operation)
			{
				case Operations.ArtistCheckin:
					new frmCheckin(selectednode.ArtistID, parent);
					break;
				case Operations.ArtistCheckout:
					new frmArtistCheckout(selectednode.ArtistID, parent);
					break;
				case Operations.EditArtist:
					new frmArtistAdd(selectednode.ArtistID, parent);
					break;
				case Operations.EditMerchandise:
					new frmMerchEditor(selectednode.ArtistID, parent);
					break;
				case Operations.EditGalleryStore:
					new frmGSManager(selectednode.ArtistID, parent);
					break;
				case Operations.GenerateBiddersheets:
					string filename =
					SaveFileDialog.rtf(this,
						"Save bidder sheets to file",
						"BiddingSheets - " +
						selectednode.ArtistID.ToString() +
						".rtf");

					if (filename != "")
					{
						Biddersheet bidsheet = new Biddersheet(filename);

						MySqlCommand merchquery = new MySqlCommand("SELECT `MerchID`,`MerchTitle`,`MerchMinBid`,`MerchAAMB`,`MerchQuickSale`,`MerchMedium` FROM `merchandise` WHERE `ArtistID` = @ID ORDER BY `MerchID`;",
														  SQLConnection.GetConnection());
						merchquery.Prepare();
						merchquery.Parameters.AddWithValue("@ID", selectednode.ArtistID);
						SQLResult merch = SQLConnection.Query(merchquery);

						for (int j = 0; j < merch.GetNumberOfRows(); j++)
						{
							bidsheet.AddSheet(selectednode.ArtistID.ToString(), merch.getCell("MerchID", j), selectednode.ArtistShowName == "" ? selectednode.ArtistName : selectednode.ArtistShowName,
									merch.getCell("MerchTitle", j), merch.getCell("MerchMedium", j), merch.getCell("MerchMinBid", j),
									merch.getCell("MerchQuickSale", j), merch.getCellInt("MerchAAMB", j) == 1);
						}

						bidsheet.Finish();
						MessageBox.Show(this, MessageType.Info,
							"Bidder Sheets generated!");
					}
					break;
				case Operations.GenerateBarcodes:
					string filename2 =
					SaveFileDialog.rtf(this,
						"Save barcodes to file",
						"Barcodes - " +
						selectednode.ArtistID.ToString() +
						".rtf");

					if (filename2 != "")
					{
						Barcodes barcode = new Barcodes(filename2);

						MySqlCommand gsmerchquery = new MySqlCommand("SELECT `PieceID`,`PiecePrice` FROM `gsmerchandise` WHERE `ArtistID` = @ID ORDER BY `PieceID`;",
														  SQLConnection.GetConnection());
						gsmerchquery.Prepare();
						gsmerchquery.Parameters.AddWithValue("@ID", selectednode.ArtistID);
						SQLResult gsmerch = SQLConnection.Query(gsmerchquery);

						for (int j = 0; j < gsmerch.GetNumberOfRows(); j += 2)
						{
							if (j < gsmerch.GetNumberOfRows() - 1)
								barcode.AddCode(selectednode.ArtistID.ToString(), gsmerch.getCell("PieceID", j), float.Parse(gsmerch.getCell("PiecePrice", j)),
										gsmerch.getCell("PieceID", j + 1), float.Parse(gsmerch.getCell("PiecePrice", j + 1)));
							else
								barcode.AddCode(String.Format("PN{0:D3}-" + gsmerch.getCell("PieceID", j).PadLeft(3, '0'),
																selectednode.ArtistID), float.Parse(gsmerch.getCell("PiecePrice", j)));
						}

						barcode.Finish();
						MessageBox.Show(this, MessageType.Info,
							"Barcodes generated!");
					}
					break;
				case Operations.ManageArtistBalance:
					MySqlCommand artistquery = new MySqlCommand("SELECT ArtistDue, ArtistPaid, ArtistCheckIn FROM `artists` WHERE `ArtistID` = @ID;",
														  SQLConnection.GetConnection());
					artistquery.Prepare();
					artistquery.Parameters.AddWithValue("@ID", selectednode.ArtistID);
					SQLResult artistinfo = SQLConnection.Query(artistquery);

					if (artistinfo.getCell("ArtistCheckIn", 0) == "0")
					{
						MessageBox.Show(this, MessageType.Info,
										"Please check in artist before managing their balance.");
						return;
					}

					float fee = float.Parse(artistinfo.getCell("ArtistDue", 0));

					if (fee <= 0.0)
					{
						MessageBox.Show(this, MessageType.Info,
										"This Artist does not have an outstanding balance.");
						return;
					}

					string message = "The Artist has an outstanding balance of $"
						+ fee
						+ ".\n\nDo they wish to pay this back now? (Cash only)";
					if (MessageBox.Ask(this, message))
					{
						SQLResult User = parent.currentUser;

						MySqlCommand query = new MySqlCommand("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `itemArray`, `priceArray`, `Last4digitsCard`, `timestamp`, `date`) VALUES ( @UID, @TOTAL, @PAID, @ITEMS, @FEE, 0, CURRENT_TIME, CURRENT_DATE); SELECT LAST_INSERT_ID() as `id`; UPDATE `artists` SET `ArtistPaid`=@ARTISTPAID, `ArtistDue`=0 WHERE `ArtistID` = @AID;",
												 SQLConnection.GetConnection());
						query.Prepare();
						query.Parameters.AddWithValue("@UID", User.getCell("id", 0));
						query.Parameters.AddWithValue("@TOTAL", fee);
						query.Parameters.AddWithValue("@PAID", fee);
						query.Parameters.AddWithValue("@ITEMS", "ARTIST" + selectednode.ArtistID.ToString().PadLeft(3, '0') + " BALANCE PAID#");
						query.Parameters.AddWithValue("@FEE", fee);
						query.Parameters.AddWithValue("@ARTISTPAID", float.Parse(artistinfo.getCell("ArtistPaid", 0)) + fee);
						query.Parameters.AddWithValue("@AID", selectednode.ArtistID);
						SQLResult results = SQLConnection.Query(query);

						if (results.successful())
						{
							MessageBox.Show(this, MessageType.Info,
											"Please make sure you take the money from the artist and give them the receipt. Click on OK now to generate the receipt.");
							Process.Start("http://" + parent.currentSQLConnection.getHost() + "/momiji/receipt.php?id=" + results.getCellInt("id", 0));
						}
					}
					break;
			}
		}
	}
}

