using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmAuctionSale : frmParentSale
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private int ArtistID;
		private int MerchID;
		private string MerchTitle;
		private float MinBid;
		private string MerchSQLQuery;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void ResetForm()
		{
			txtBarcode.Sensitive = true;
			btnCancel.Sensitive = false;
			btnPay.Sensitive = false;
			txtPaid.Sensitive = false;
			drpPaymentType.Sensitive = false;
			btnPrintReceipt.Sensitive = false;
			txtPrice.Sensitive = false;
			btnAddToList.Sensitive = true;
			btnClear.Sensitive = true;
			txtBarcode.Text = "";
			txtPrice.Text = "";
			txtTotal.Text = "";
			txtChange.Text = "";
			txtPaid.Text = "";
			drpPaymentType.Active = 0;
			lblPaid.LabelProp = "Paid: <b>$</b>";
			this.items = "";
			this.prices = "";
			this.total = 0;
			this.MerchSQLQuery = "false";
			txtBarcode.GrabFocus();
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmAuctionSale(frmMenu parent) :
			base(parent)
		{
			this.Build();
			MerchNode.buildTable(ref lstMerch, ref merchStore);

			ResetForm();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args)
		{
			parent.CleanupAuctionSale();
		}

		protected void OnTxtBarcodeActivated(object sender, EventArgs e)
		{
			if (!ExistsInList(txtBarcode.Text))
			{
				txtBarcode.Text = txtBarcode.Text.Replace("*", "").ToUpper();
				if (!ParseBarcode(txtBarcode.Text, "AN", out ArtistID, out MerchID))
				{
					OnBtnClearClicked(sender, e);
					return;
				}

				SQL SQLConnection = parent.currentSQLConnection;
				MySqlCommand query = new MySqlCommand("SELECT `MerchTitle`,`MerchMinBid`,`MerchSold`,`MerchAAMB`,`MerchQuicksale`,COUNT(`value`) as `BidCount`,MAX(`value`) as `CurrentBid`,`AuctionEnd`,`EnableDigitalBid`,`AuctionCutoff` FROM `merchandise` LEFT JOIN `bids` USING (`ArtistID`,`MerchID`) CROSS JOIN `options` WHERE `ArtistID` = @AID AND `MerchID` = @MID GROUP BY `ArtistID`,`MerchID`;",
										 SQLConnection.GetConnection());
				query.Prepare();
				query.Parameters.AddWithValue("@AID", ArtistID);
				query.Parameters.AddWithValue("@MID", MerchID);
				SQLResult results = SQLConnection.Query(query);

				if (results.GetNumberOfRows() < 1)
				{
					MessageBox.Show(this, MessageType.Error,
						"Could not find merchandise in the database");
					txtBarcode.Text = "";
				}
				else if (results.getCell("MerchSold", 0) == "1")
				{
					MessageBox.Show(this, MessageType.Error,
						"This item has already been sold. This will be reported.");

					SQLConnection.LogAction("Attempted to auction sell an already sold item (" + txtBarcode.Text + ")",
						parent.currentUser);
					txtBarcode.Text = "";
				}
				else
				{
					MerchTitle = results.getCell("MerchTitle", 0);
					MinBid = float.Parse(results.getCell("MerchMinBid", 0));
					txtBarcode.Sensitive = false;
					txtPrice.Sensitive = true;
					txtPrice.GrabFocus();

					if (results.getCell("EnableDigitalBid", 0) != "1") {
						return;
					}

					int BidCount = results.getCellInt("BidCount", 0);
					if (BidCount > 0)
					{
						if (results.getCell("AuctionEnd", 0) == "0")
						{
							MessageBox.Show(this, MessageType.Error,
								"This item cannot be sold as quicksale as it has bids on it. This will be reported.");

							SQLConnection.LogAction("Attempted to sell an item with bids (" + txtBarcode.Text + ")",
								parent.currentUser);
							OnBtnClearClicked(sender, e);
						}
						else if (BidCount < results.getCellInt("AuctionCutoff", 0))
						{
							txtPrice.Text = results.getCell("CurrentBid", 0);
							OnBtnAddToListClicked(sender, e);
						}
					}
					else
					{
						float price;
						if (results.getCell("AuctionEnd", 0) == "1" &&
							results.getCell("MerchAAMB", 0) == "1")
						{
							price = MinBid;
						}
						else
						{
							price = float.Parse(results.getCell("MerchQuicksale", 0));
						}

						if (price > 0)
						{
							txtPrice.Text = price.ToString();
							OnBtnAddToListClicked(sender, e);
						}
						else
						{
							MessageBox.Show(this, MessageType.Error,
								"This item cannot be sold as quicksale. This will be reported.");

							SQLConnection.LogAction("Attempted to quick sell a non quick sellable item (" + txtBarcode.Text + ")",
								parent.currentUser);
							OnBtnClearClicked(sender, e);
						}
					}
				}
			}
			else
			{
				txtBarcode.Text = "";
			}
		}

		protected void OnBtnAddToListClicked(object sender, EventArgs e)
		{
			if (txtBarcode.Sensitive)
			{
				OnTxtBarcodeActivated(sender, e);
				return;
			}

			//Catch an invalid price
			float Price;
			if (!float.TryParse(txtPrice.Text, out Price))
			{
				MessageBox.Show(this, MessageType.Error,
					"Invalid Price");

				txtPrice.Text = "";
				txtPrice.GrabFocus();
			}
			else if (MinBid > Price)
			{
				MessageBox.Show(this, MessageType.Error,
					"Price is too low.\nThis item has a minimum bid of $" +
					String.Format("{0:0.00}", MinBid));
				txtPrice.Text = "";
				txtPrice.GrabFocus();
			}
			else
			{
				merchStore.AddNode(new MerchNode(ArtistID,
					MerchID,
					MerchTitle,
					"$" + String.Format("{0:0.00}", Price)));

				total = total + Price;
				txtTotal.Text = String.Format("{0:0.00}", total);

				items = items + txtBarcode.Text + "#";
				prices = prices + Price.ToString() + "#";
				MerchSQLQuery = MerchSQLQuery + " OR (`ArtistID` = " +
					ArtistID.ToString() +" AND `MerchID` = " +
					MerchID.ToString()+")";

				btnPay.Sensitive = true;
				txtPaid.Sensitive = true;
				drpPaymentType.Sensitive = true;
				btnCancel.Sensitive = true;
				OnBtnClearClicked(sender, e);
			}
		}

		protected void OnTxtPriceActivated(object sender, EventArgs e)
		{
			OnBtnAddToListClicked(sender, e);
		}

		protected void OnBtnClearClicked(object sender, EventArgs e)
		{
			txtBarcode.Text = "";
			txtPrice.Text = "";
			txtBarcode.Sensitive = true;
			txtPrice.Sensitive = false;
			txtBarcode.GrabFocus();
		}

		protected void OnBtnCancelClicked(object sender, EventArgs e)
		{
			MerchNode.clearTable(ref lstMerch, ref merchStore);

			ResetForm();
		}

		protected void OnBtnPayClicked(object sender, EventArgs e)
		{
			float paid;
			int fourdigits;

			if (!CheckPaidAmount(drpPaymentType.Active, txtPaid.Text,
					out paid, out fourdigits))
			{
				return;
			}

			//Disable before querying to avoid double clicks
			btnPay.Sensitive = false;

			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			MySqlCommand query = new MySqlCommand("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isAuctionSale`, `itemArray`, `priceArray`, `Last4digitsCard`, `timestamp`, `date`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES, @FOURDIG, CURRENT_TIME, CURRENT_DATE); SELECT LAST_INSERT_ID() as `id`; UPDATE `merchandise` SET `MerchSold`=1, `ReceiptID`=LAST_INSERT_ID() WHERE " + MerchSQLQuery + ";",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@UID", User.getCell("id", 0));
			query.Parameters.AddWithValue("@TOTAL", total);
			query.Parameters.AddWithValue("@PAID", paid);
			query.Parameters.AddWithValue("@ITEMS", items);
			query.Parameters.AddWithValue("@PRICES", prices);
			query.Parameters.AddWithValue("@FOURDIG", fourdigits);
			SQLResult results = SQLConnection.Query(query);

			if (results.successful())
			{
				//Get receiptid
				receiptID = results.getCellInt("id", 0);

				txtChange.Text = String.Format("{0:0.00}", (paid - total));

				FinishSaleMessage(txtChange.Text, paid);

				SQLConnection.LogAction("Made a auction sale with receipt #" + receiptID,
					User);
				txtPaid.Sensitive = false;
				txtBarcode.Sensitive = false;
				txtPrice.Sensitive = false;
				btnAddToList.Sensitive = false;
				drpPaymentType.Sensitive = false;
				btnClear.Sensitive = false;
				btnPrintReceipt.Sensitive = true;
				btnPrintReceipt.GrabFocus();
			}
			else
			{
				MessageBox.Show(this, MessageType.Error,
					"Connection Error, please close and try again.");
				btnPay.Sensitive = true;
			}
		}

		protected void OnTxtPaidActivated(object sender, EventArgs e)
		{
			OnBtnPayClicked(sender, e);
		}

		protected void OnDrpPaymentTypeChanged(object sender, EventArgs e)
		{
			if (drpPaymentType.Active == 0)
			{
				lblPaid.LabelProp = "Paid: <b>$</b>";
			}
			else
			{
				lblPaid.LabelProp = "Last 4 Digits:";
			}
		}

		protected void OnBtnPrintReceiptClicked(object sender, EventArgs e)
		{
			PrintReceipt();
		}
	}
}

