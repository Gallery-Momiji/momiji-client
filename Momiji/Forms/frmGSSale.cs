using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmGSSale : Gtk.Window
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
			txtBarcode.Text = "";
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

		private int countInList (string barcode)
		{
			string temp = items;
			int count = 0;

			while (temp.Length >= 10) {
				if (temp.Substring (0, 9) == barcode)
					count++;
				temp = temp.Substring (10);
			}

			return count;
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmGSSale (frmMenu parent) :
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
			parent.CleanupGSSale ();
		}

		protected void OnTxtBarcodeActivated (object sender, EventArgs e)
		{
			//Wildcards are considered null characters
			txtBarcode.Text = txtBarcode.Text.Replace ("*", "").ToUpper ();

			if (txtBarcode.Text.Length < 9) {
				txtBarcode.Text = "";
				return;
			}

			//Catch for format, PN###-###
			if (txtBarcode.Text.Substring (0, 2) != "PN" ||
			    txtBarcode.Text.Substring (5, 1) != "-") {
				MessageBox.Show (this, MessageType.Error,
					"Invalid Gallery Store barcode");
				txtBarcode.Text = "";
				return;
			}

			//Catch an invalid barcode, should be PN###-###
			int ArtistID, PieceID;
			if (!int.TryParse (txtBarcode.Text.Substring (2, 3), out ArtistID) ||
			    !int.TryParse (txtBarcode.Text.Substring (6, 3), out PieceID)) {
				MessageBox.Show (this, MessageType.Error,
					"Invalid barcode format");
				txtBarcode.Text = "";
				return;
			}

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT `PieceTitle`,`PiecePrice`,`PieceStock` FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", ArtistID);
			query.Parameters.AddWithValue ("@PID", PieceID);
			SQLResult results = SQLConnection.Query (query);

			if (results.GetNumberOfRows () == 1) {

				int count = countInList (txtBarcode.Text);
				if (results.getCellInt ("PieceStock", 0) <= count) {
					MessageBox.Show (this, MessageType.Error,
						"This is item is out of stock.");
				} else {
					merchStore.AddNode (new MerchNode (ArtistID,
						PieceID,
						results.getCell ("PieceTitle", 0),
						"$" + String.Format ("{0:0.00}",
							float.Parse (results.getCell ("PiecePrice", 0)))
					));

					total = total + float.Parse (results.getCell ("PiecePrice", 0));
					txtTotal.Text = String.Format ("{0:0.00}", total);

					items = items + txtBarcode.Text + "#";
					prices = prices + results.getCell ("PiecePrice", 0) + "#";

					btnPay.Sensitive = true;
					txtPaid.Sensitive = true;
					drpPaymentType.Sensitive = true;
					btnCancel.Sensitive = true;
				}
			} else {
				MessageBox.Show (this, MessageType.Error,
					"Could not find piece in the database");
			}

			txtBarcode.Text = "";
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

			MySqlCommand query = new MySqlCommand ("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isGalleryStoreSale`, `itemArray`, `priceArray`, `Last4digitsCard`, `timestamp`, `date`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES, @FOURDIG, CURRENT_TIME, CURRENT_DATE);",
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
				query = new MySqlCommand ("SELECT `id` FROM `receipts` WHERE `userID` = @UID AND `itemArray` = @ITEMS AND `priceArray` = @PRICES AND `isGalleryStoreSale` = 1 ORDER BY `id` DESC LIMIT 0,1;",
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

				//Readjust the stock counts
				//TODO// Test me!
				/*string temp = items;
				while (temp.Length >= 10) {
					query = new MySqlCommand ("UPDATE `gsmerchandise` SET `PieceStock`=`PieceStock`-1 WHERE  `ArtistID`=@ARTISTID AND `MerchID`=@MERCHID LIMIT 1;",
						SQLConnection.GetConnection ());
					query.Prepare ();
					query.Parameters.AddWithValue ("@ARTISTID", temp.Substring (2, 3));
					query.Parameters.AddWithValue ("@MERCHID", temp.Substring (6, 3));
					results = SQLConnection.Query (query);
					temp = temp.Substring (10);
				}*/

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

				SQLConnection.LogAction ("Made a gallery store sale with receipt #" + receiptID,
					User);
				btnPay.Sensitive = false;
				txtPaid.Sensitive = false;
				drpPaymentType.Sensitive = false;
				txtBarcode.Sensitive = false;
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

