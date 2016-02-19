using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmAuctionSale : Gtk.Window
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
			btnAddToList.Sensitive = false;
			btnClear.Sensitive = false;
			txtBarcode.Text = "";
			txtPrice.Text = "";
			txtTotal.Text = "";
			txtChange.Text = "";
			txtPaid.Text = "";
			this.items = "";
			this.prices = "";
			this.total = 0;
			//txtBarcode.GrabFocus ();
		}

		private bool existsInList (string barcode)
		{
			string temp = items;

			while (temp.Length >= 10) {

				if(temp.Substring (0, 9) == barcode)
					return true;

				temp = temp.Substring(temp.Length-10);
			}

			return false;
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmAuctionSale (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
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

		protected void OnBtnAddToListClicked (object sender, System.EventArgs e)
		{
			//Wildcards are considered null characters
			txtBarcode.Text = txtBarcode.Text.Replace ("*", "").ToUpper ();

			if (txtBarcode.Text.Length < 9) {
				txtBarcode.Text = "";
				return;
			}

			//Catch for format, AN###-###
			if (txtBarcode.Text.Substring (0, 2) != "AN" &&
				txtBarcode.Text.Substring (5, 1) != "-") {
				MessageBox.Show (this, MessageType.Error,
										"Invalid merchandise barcode");

				txtBarcode.Text = "";
				return;
			}

			if (existsInList (txtBarcode.Text.ToUpper ())) {
				MessageBox.Show (this, MessageType.Info,
									"Item already added");

				txtBarcode.Text = "";
				txtPrice.Text = "";
				return;
			}

			//Catch an invalid barcode, should be AN###-###
			int ArtistID, MerchID;
			try {
				ArtistID = Int32.Parse (txtBarcode.Text.Substring (2, 3));
				MerchID = Int32.Parse (txtBarcode.Text.Substring (6, 3));
			} catch {
				MessageBox.Show (this, MessageType.Error,
										"Invalid barcode format");

				txtBarcode.Text = "";
				return;
			}

			//Catch an invalid price
			int Price;
			try {
				Price = Int32.Parse (txtPrice.Text);
			} catch {
				MessageBox.Show (this, MessageType.Error,
										"Invalid Price");

				txtPrice.Text = "";
				return;
			}

			try {
				SQL SQLConnection = parent.currentSQLConnection;
				MySqlCommand query = new MySqlCommand ("SELECT * FROM `merchandise` WHERE `ArtistID` = @AID AND `MerchID` = @MID;", SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@AID", ArtistID);
				query.Parameters.AddWithValue ("@MID", MerchID);
				SQLResult results = SQLConnection.Query (query);

				if (results.GetNumberOfRows () == 1) {

					if (float.Parse (results.getCell ("MerchMinBid ", 0)) > Price) {
						MessageBox.Show (this, MessageType.Error,
										"Price is too low.\nThis item has a minimum bid of " +
										results.getCell ("MerchMinBid ", 0));
						return;
					}

					merchStore.AddNode (new MerchNode (ArtistID.ToString (),
										MerchID.ToString (),
										results.getCell ("MerchTitle", 0),
										"$" + String.Format ("{0:0.00}", Price)));

					total = total + Price;
					txtTotal.Text = String.Format ("{0:0.00}", total);

					items = items + txtBarcode.Text.ToUpper () + "#";
					prices = prices + Price.ToString() + "#";

					txtBarcode.Text = "";
					btnPay.Sensitive = true;
					txtPaid.Sensitive = true;
					btnCancel.Sensitive = true;
				} else {
					MessageBox.Show (this, MessageType.Error,
											"Could not find merchandise in the database");

					txtBarcode.Text = "";
				}
			} catch (Exception d) {
				MessageBox.Show (this, MessageType.Error,
										"Error, please show this to your administrator:\n"
										+ d.ToString ());

				txtBarcode.Text = "";
				return;
			}
		}

		protected void OnBtnClearClicked (object sender, System.EventArgs e)
		{
			txtBarcode.Text = "";
			txtPrice.Text = "";
		}

		protected void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			MerchNode.clearTable (ref lstMerch, ref merchStore);

			ResetForm ();
		}

		protected void OnBtnPayClicked (object sender, System.EventArgs e)
		{
			//TODO mark items as sold
			if (txtPaid.Text == "") {
				MessageBox.Show (this, MessageType.Info,
										"Please specify the amount that the customer has paid");
				return;
			}

			float paid;

			try {
				paid = float.Parse (txtPaid.Text);
			} catch {
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

			MySqlCommand query = new MySqlCommand ("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isQuickSale`, `itemArray`, `priceArray`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES);", SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
			query.Parameters.AddWithValue ("@TOTAL", total);
			query.Parameters.AddWithValue ("@PAID", paid);
			query.Parameters.AddWithValue ("@ITEMS", items);
			query.Parameters.AddWithValue ("@PRICES", prices);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				query = new MySqlCommand ("SELECT `id` FROM `receipts` WHERE `userID` = @UID AND `itemArray` = @ITEMS AND `priceArray` = @PRICES AND `isQuickSale` = 1 ORDER BY `id` DESC LIMIT 0,1;", SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
				query.Parameters.AddWithValue ("@TOTAL", total);
				query.Parameters.AddWithValue ("@PAID", paid);
				query.Parameters.AddWithValue ("@ITEMS", items);
				query.Parameters.AddWithValue ("@PRICES", prices);
				results = SQLConnection.Query (query);
				txtChange.Text = String.Format ("{0:0.00}", (paid - total));

				MessageBox.Show (this, MessageType.Info,
										"Receipt processed, please give the following change: "
										+ txtChange.Text +
										"\n\nPlease check the receipt printer.\nThis was transaction ID #"
										+ results.getCell ("id", 0));

				SQLConnection.LogAction ("Made a quick sale with receipt #" + results.getCell ("id", 0), User);
				btnPay.Sensitive = false;
				txtPaid.Sensitive = false;
				txtBarcode.Sensitive = false;

			} else {
				MessageBox.Show (this, MessageType.Error,
										"Connection Error, please close and try again.");
			}
		}
	}
}

