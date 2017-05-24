using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmAuctionSale : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private NodeStore merchStore;
		private float total = 0;
		private int receiptID = 0;
		public string items = "";
		public string prices = "";

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void ResetForm ()
		{
			txtBarcode.Sensitive = true;
			btnCancel.Sensitive = false;
			btnPay.Sensitive = false;
			txtPaid.Sensitive = false;
			drpPaymentType.Sensitive = false;
			btnPrintReceipt.Sensitive = false;
			txtPrice.Sensitive = true;
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
			txtBarcode.GrabFocus ();
		}

		private bool existsInList (string barcode)
		{
			string temp = items;

			while (temp.Length >= 10) {
				if (temp.Substring (0, 9) == barcode)
					return true;
				temp = temp.Substring (10);
			}

			return false;
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmAuctionSale (frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			MerchNode.buildTable (ref lstMerch, ref merchStore);

			ResetForm ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			parent.CleanupAuctionSale ();
		}

		protected void OnTxtBarcodeActivated (object sender, EventArgs e)
		{
			txtPrice.GrabFocus ();
		}

		protected void OnBtnAddToListClicked (object sender, EventArgs e)
		{
			//Wildcards are considered null characters
			txtBarcode.Text = txtBarcode.Text.Replace ("*", "").ToUpper ();

			if (txtBarcode.Text.Length < 9) {
				txtBarcode.Text = "";
				txtBarcode.GrabFocus ();
				return;
			}

			//Catch for format, AN###-###
			if (txtBarcode.Text.Substring (0, 2) != "AN" ||
			    txtBarcode.Text.Substring (5, 1) != "-") {
				MessageBox.Show (this, MessageType.Error,
					"Invalid merchandise barcode");

				txtBarcode.Text = "";
				txtBarcode.GrabFocus ();
				return;
			}

			if (existsInList (txtBarcode.Text)) {
				MessageBox.Show (this, MessageType.Info,
					"Item already added");

				txtBarcode.Text = "";
				txtPrice.Text = "";
				txtBarcode.GrabFocus ();
				return;
			}

			//Catch an invalid barcode, should be AN###-###
			int ArtistID, MerchID;
			if (!int.TryParse (txtBarcode.Text.Substring (2, 3), out ArtistID) ||
			    !int.TryParse (txtBarcode.Text.Substring (6, 3), out MerchID)) {
				MessageBox.Show (this, MessageType.Error,
					"Invalid barcode format");

				txtBarcode.Text = "";
				txtBarcode.GrabFocus ();
				return;
			}

			//Catch an invalid price
			float Price;
			if (!float.TryParse (txtPrice.Text, out Price)) {
				MessageBox.Show (this, MessageType.Error,
					"Invalid Price");

				txtPrice.Text = "";
				txtPrice.GrabFocus ();
				return;
			}

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT `MerchTitle`,`MerchMinBid`,`MerchSold` FROM `merchandise` WHERE `ArtistID` = @AID AND `MerchID` = @MID;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", ArtistID);
			query.Parameters.AddWithValue ("@MID", MerchID);
			SQLResult results = SQLConnection.Query (query);

			if (results.GetNumberOfRows () == 1) {
				float minbid = float.Parse (results.getCell ("MerchMinBid", 0));
				if (minbid > Price) {
					MessageBox.Show (this, MessageType.Error,
						"Price is too low.\nThis item has a minimum bid of $" +
						String.Format ("{0:0.00}", minbid));
					txtPrice.Text = "";
					txtPrice.GrabFocus ();
					return;
				} else if (results.getCell ("MerchSold", 0) == "1") {
					MessageBox.Show (this, MessageType.Error,
						"This item has already been sold. This will be reported.");

					SQLConnection.LogAction ("Attempted to auction sell an already sold item (" + txtBarcode.Text + ")",
						parent.currentUser);
				} else {
					merchStore.AddNode (new MerchNode (ArtistID,
						MerchID,
						results.getCell ("MerchTitle", 0),
						"$" + String.Format ("{0:0.00}", Price)));

					total = total + Price;
					txtTotal.Text = String.Format ("{0:0.00}", total);

					items = items + txtBarcode.Text + "#";
					prices = prices + Price.ToString () + "#";

					btnPay.Sensitive = true;
					txtPaid.Sensitive = true;
					drpPaymentType.Sensitive = true;
					btnCancel.Sensitive = true;
				}
			} else {
				MessageBox.Show (this, MessageType.Error,
					"Could not find merchandise in the database");
			}

			txtBarcode.GrabFocus ();
			txtBarcode.Text = "";
			txtPrice.Text = "";
		}

		protected void OnTxtPriceActivated (object sender, EventArgs e)
		{
			OnBtnAddToListClicked (sender, e);
		}

		protected void OnBtnClearClicked (object sender, EventArgs e)
		{
			txtBarcode.Text = "";
			txtPrice.Text = "";
			txtBarcode.GrabFocus ();
		}

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
			MerchNode.clearTable (ref lstMerch, ref merchStore);

			ResetForm ();
		}

		protected void OnBtnPayClicked (object sender, EventArgs e)
		{
			float paid;
			int fourdigits = 0;

			if(drpPaymentType.Active == 0) {
				if (txtPaid.Text == "") {
					MessageBox.Show (this, MessageType.Info,
						"Please specify the amount that the customer has paid");
					return;
				}

				if (!float.TryParse (txtPaid.Text, out paid)) {
					MessageBox.Show (this, MessageType.Info,
						"Please enter a valid number in the paid box");
					return;
				}

				if (total > paid) {
					MessageBox.Show (this, MessageType.Info,
						"Paid amount is too small");
					return;
				}
			} else {
				if (txtPaid.Text.Length != 4) {
					MessageBox.Show (this, MessageType.Info,
						"Please enter the last 4 digits on the credit card");
					return;
				}

				if (!int.TryParse (txtPaid.Text, out fourdigits)) {
					MessageBox.Show (this, MessageType.Info,
						"Please enter a valid set of 4 digits");
					return;
				}

				if (!MessageBox.Ask (this, "Has the credit card transaction been approved?"))
					return;

				paid = total;
			}

			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			MySqlCommand query = new MySqlCommand ("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isAuctionSale`, `itemArray`, `priceArray`, `Last4digitsCard`, `timestamp`, `date`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES, @FOURDIG, CURRENT_TIME, CURRENT_DATE);",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
			query.Parameters.AddWithValue ("@TOTAL", total);
			query.Parameters.AddWithValue ("@PAID", paid);
			query.Parameters.AddWithValue ("@ITEMS", items);
			query.Parameters.AddWithValue ("@PRICES", prices);
			query.Parameters.AddWithValue ("@FOURDIG", fourdigits);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				//Get receiptid
				query = new MySqlCommand ("SELECT `id` FROM `receipts` WHERE `userID` = @UID AND `itemArray` = @ITEMS AND `priceArray` = @PRICES AND `isAuctionSale` = 1 ORDER BY `id` DESC LIMIT 0,1;",
					SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
				query.Parameters.AddWithValue ("@TOTAL", total);
				query.Parameters.AddWithValue ("@PAID", paid);
				query.Parameters.AddWithValue ("@ITEMS", items);
				query.Parameters.AddWithValue ("@PRICES", prices);
				results = SQLConnection.Query (query);
				receiptID = results.getCellInt ("id", 0);

				txtChange.Text = String.Format ("{0:0.00}", (paid - total));

				//Mark items as sold
				//TODO// Test me!
				/*query = new MySqlCommand ("UPDATE `merchandise` SET `MerchSold`=1, `ReceiptID`=@RECEIPTID WHERE  LOCATE(`ArtistID`+'-'+`MerchID`,@ITEMS)>0",
					SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@RECEIPTID", receiptID);
				query.Parameters.AddWithValue ("@ITEMS", items);
				results = SQLConnection.Query (query);*/

				if(paid == total) {
					MessageBox.Show (this, MessageType.Info,
						"Sale processed!\n\nClick on the button below to generate a receipt.\nThis was transaction ID #"
						+ receiptID);
				} else {
					MessageBox.Show (this, MessageType.Info,
						"Sale processed, please give the following change: $"
						+ txtChange.Text +
						"\n\nClick on the button below to generate a receipt.\nThis was transaction ID #"
						+ receiptID);
				}

				SQLConnection.LogAction ("Made a auction sale with receipt #" + receiptID,
					User);
				btnPay.Sensitive = false;
				txtPaid.Sensitive = false;
				txtBarcode.Sensitive = false;
				txtPrice.Sensitive = false;
				btnAddToList.Sensitive = false;
				drpPaymentType.Sensitive = false;
				btnClear.Sensitive = false;
				btnPrintReceipt.Sensitive = true;
				btnPrintReceipt.GrabFocus ();

			} else {
				MessageBox.Show (this, MessageType.Error,
					"Connection Error, please close and try again.");
			}
		}

		protected void OnTxtPaidActivated (object sender, EventArgs e)
		{
			OnBtnPayClicked (sender, e);
		}

		protected void OnDrpPaymentTypeChanged (object sender, EventArgs e)
		{
			if(drpPaymentType.Active == 0) {
				lblPaid.LabelProp = "Paid: <b>$</b>";
			} else {
				lblPaid.LabelProp = "Last 4 Digits:";
			}
		}

		protected void OnBtnPrintReceiptClicked (object sender, EventArgs e)
		{
			Process.Start ("http://" + parent.currentSQLConnection.getHost () + "/momiji/receipt.php?id=" + receiptID);
		}
	}
}

