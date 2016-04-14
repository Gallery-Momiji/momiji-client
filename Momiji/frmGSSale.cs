using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmGSSale : Gtk.Window
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
			MySqlCommand query = new MySqlCommand ("SELECT * FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;",
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
			//TODO decrease stock count and tag receipt
			if (txtPaid.Text == "") {
				MessageBox.Show (this, MessageType.Info,
									"Please specify the amount that the customer has paid");
				return;
			}

			float paid;
			if(!float.TryParse (txtPaid.Text, out paid)) {
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

			MySqlCommand query = new MySqlCommand ("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isGalleryStoreSale`, `itemArray`, `priceArray`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES);",
													SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
			query.Parameters.AddWithValue ("@TOTAL", total);
			query.Parameters.AddWithValue ("@PAID", paid);
			query.Parameters.AddWithValue ("@ITEMS", items);
			query.Parameters.AddWithValue ("@PRICES", prices);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				query = new MySqlCommand ("SELECT `id` FROM `receipts` WHERE `userID` = @UID AND `itemArray` = @ITEMS AND `priceArray` = @PRICES AND `isGalleryStoreSale` = 1 ORDER BY `id` DESC LIMIT 0,1;",
											SQLConnection.GetConnection ());
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

				SQLConnection.LogAction ("Made a gallery store sale with receipt #"
											+ results.getCell ("id", 0), User);
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

