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

				if(temp.Substring (0, 9) == barcode)
					return true;

				temp = temp.Substring(temp.Length-10);
			}

			return false;
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmQuickSale (frmMenu parent) : 
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
			parent.CleanupQuickSale ();
		}

		protected void OnTxtBarcodeActivated (object sender, System.EventArgs e)
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
										"Invalid Quicksale Piece");

				txtBarcode.Text = "";
				return;
			}

			if (existsInList (txtBarcode.Text.ToUpper ())) {
				MessageBox.Show (this, MessageType.Info,
									"Item already scanned");

				txtBarcode.Text = "";
				return;
			}

			//Catch an invalid barcode, should be AN###-###
			int ArtistID, PieceID;
			try {
				ArtistID = Int32.Parse (txtBarcode.Text.Substring (2, 3));
				PieceID = Int32.Parse (txtBarcode.Text.Substring (6, 3));
			} catch {
				MessageBox.Show (this, MessageType.Error,
										"Invalid barcode");

				txtBarcode.Text = "";
				return;
			}

			try {
				SQL SQLConnection = parent.currentSQLConnection;
				MySqlCommand query = new MySqlCommand ("SELECT * FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;", SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@AID", ArtistID);
				query.Parameters.AddWithValue ("@PID", PieceID);
				SQLResult results = SQLConnection.Query (query);

				if (results.GetNumberOfRows () == 1) {

					if (results.getCell ("MerchQuickSale", 0) == "0") {
						MessageBox.Show (this, MessageType.Error,
										"This item cannot be sold as quicksale. This will be reported.");

						SQLConnection.LogAction ("Attempted to quick sell a non quick sellable item (" + txtBarcode.Text + ")", parent.currentUser);
						return;
					} else if (results.getCell ("MerchSold", 0) == "1") {
						MessageBox.Show (this, MessageType.Error,
										"This item has already been sold. This will be reported.");

						SQLConnection.LogAction ("Attempted to quick sell an already sold item (" + txtBarcode.Text + ")", parent.currentUser);
						return;
					}

					merchStore.AddNode (new MerchNode (ArtistID.ToString (),
										PieceID.ToString (),
										results.getCell ("PieceTitle", 0),
										"$" + String.Format ("{0:0.00}",
										float.Parse (results.getCell ("PiecePrice", 0)))
										));

					total = total + float.Parse (results.getCell ("PiecePrice", 0));
					txtTotal.Text = String.Format ("{0:0.00}", total);

					items = items + txtBarcode.Text.ToUpper () + "#";
					prices = prices + results.getCell ("PiecePrice", 0) + "#";

					txtBarcode.Text = "";
					btnPay.Sensitive = true;
					txtPaid.Sensitive = true;
					btnCancel.Sensitive = true;
				} else {
					MessageBox.Show (this, MessageType.Error,
											"Could not find piece in the database");

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
