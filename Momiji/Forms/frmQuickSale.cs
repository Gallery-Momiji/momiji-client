using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmQuickSale : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private Gtk.NodeStore merchStore;
		private float total = 0;
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
			txtBarcode.Text = "";
			txtTotal.Text = "";
			txtChange.Text = "";
			txtPaid.Text = "";
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

		public frmQuickSale (frmMenu parent) :
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
			parent.CleanupQuickSale ();
		}

		protected void OnTxtBarcodeActivated (object sender, EventArgs e)
		{
			//Wildcards are considered null characters
			txtBarcode.Text = txtBarcode.Text.Replace ("*", "").ToUpper ();

			if (txtBarcode.Text.Length < 9) {
				txtBarcode.Text = "";
				return;
			}

			//Catch for format, AN###-###
			if (txtBarcode.Text.Substring (0, 2) != "AN" ||
			    txtBarcode.Text.Substring (5, 1) != "-") {
				MessageBox.Show (this, MessageType.Error,
					"Invalid merchandise barcode");

				txtBarcode.Text = "";
				return;
			}

			if (existsInList (txtBarcode.Text)) {
				MessageBox.Show (this, MessageType.Info,
					"Item already scanned");

				txtBarcode.Text = "";
				return;
			}

			//Catch an invalid barcode, should be AN###-###
			int ArtistID, MerchID;
			if (!int.TryParse (txtBarcode.Text.Substring (2, 3), out ArtistID) ||
			    !int.TryParse (txtBarcode.Text.Substring (6, 3), out MerchID)) {
				MessageBox.Show (this, MessageType.Error,
					"Invalid barcode format");

				txtBarcode.Text = "";
				return;
			}

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT `MerchTitle`,`MerchQuickSale`,`MerchSold` FROM `merchandise` WHERE `ArtistID` = @AID AND `MerchID` = @MID;",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", ArtistID);
			query.Parameters.AddWithValue ("@MID", MerchID);
			SQLResult results = SQLConnection.Query (query);

			if (results.GetNumberOfRows () == 1) {
				if (results.getCell ("MerchQuickSale", 0) == "0") {
					MessageBox.Show (this, MessageType.Error,
						"This item cannot be sold as quicksale. This will be reported.");

					SQLConnection.LogAction ("Attempted to quick sell a non quick sellable item (" + txtBarcode.Text + ")",
						parent.currentUser);
				} else if (results.getCell ("MerchSold", 0) == "1") {
					MessageBox.Show (this, MessageType.Error,
						"This item has already been sold. This will be reported.");

					SQLConnection.LogAction ("Attempted to quick sell an already sold item (" +
					txtBarcode.Text + ")",
						parent.currentUser);
				} else {
					float price = float.Parse (results.getCell ("MerchQuickSale", 0));
					merchStore.AddNode (new MerchNode (ArtistID,
						MerchID,
						results.getCell ("MerchTitle", 0),
						"$" + String.Format ("{0:0.00}",
							price)
					));

					total = total + price;
					txtTotal.Text = String.Format ("{0:0.00}", total);

					items = items + txtBarcode.Text + "#";
					prices = prices + results.getCell ("MerchQuickSale", 0) + "#";

					btnPay.Sensitive = true;
					txtPaid.Sensitive = true;
					btnCancel.Sensitive = true;
				}
			} else {
				MessageBox.Show (this, MessageType.Error,
					"Could not find merchandise in the database");
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
			if (txtPaid.Text == "") {
				MessageBox.Show (this, MessageType.Info,
					"Please specify the amount that the customer has paid");
				return;
			}

			float paid;
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

			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			MySqlCommand query = new MySqlCommand ("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isQuickSale`, `itemArray`, `priceArray`, `timestamp`, `date`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES, CURRENT_TIME, CURRENT_DATE);",
				                     SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
			query.Parameters.AddWithValue ("@TOTAL", total);
			query.Parameters.AddWithValue ("@PAID", paid);
			query.Parameters.AddWithValue ("@ITEMS", items);
			query.Parameters.AddWithValue ("@PRICES", prices);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				//Get receiptid
				//TODO// Possible redundant code
				query = new MySqlCommand ("SELECT `id` FROM `receipts` WHERE `userID` = @UID AND `itemArray` = @ITEMS AND `priceArray` = @PRICES AND `isQuickSale` = 1 ORDER BY `id` DESC LIMIT 0,1;",
					SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
				query.Parameters.AddWithValue ("@TOTAL", total);
				query.Parameters.AddWithValue ("@PAID", paid);
				query.Parameters.AddWithValue ("@ITEMS", items);
				query.Parameters.AddWithValue ("@PRICES", prices);
				results = SQLConnection.Query (query);
				txtChange.Text = String.Format ("{0:0.00}", (paid - total));
				//End of possible redundant code//
				int receiptID = results.getCellInt ("id", 0);

				//Mark items as sold
				//TODO// Test me!
				/*query = new MySqlCommand ("UPDATE `merchandise` SET `MerchSold`=1, `ReceiptID`=@RECEIPTID WHERE  LOCATE(`ArtistID`+'-'+`MerchID`,@ITEMS)>0",
					SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@RECEIPTID", receiptID);
				query.Parameters.AddWithValue ("@ITEMS", items);
				results = SQLConnection.Query (query);*/

				MessageBox.Show (this, MessageType.Info,
					"Receipt processed, please give the following change: "
					+ txtChange.Text +
					"\n\nPlease check the receipt printer.\nThis was transaction ID #"
					+ receiptID);

				SQLConnection.LogAction ("Made a quick sale with receipt #" + receiptID,
					User);
				btnPay.Sensitive = false;
				txtPaid.Sensitive = false;
				txtBarcode.Sensitive = false;
				btnCancel.GrabFocus ();
			} else {
				MessageBox.Show (this, MessageType.Error,
					"Connection Error, please close and try again.");
			}
		}

		protected void OnTxtPaidActivated (object sender, EventArgs e)
		{
			OnBtnPayClicked (sender, e);
		}
	}
}

