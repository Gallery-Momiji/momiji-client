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
			txtTotal.Text = "";
			txtChange.Text = "";
			txtPaid.Text = "";
			this.items = "";
			this.prices = "";
			this.total = 0;
			txtBarcode.GrabFocus ();
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

		protected void OnTxtBarcodeActivated (object sender, System.EventArgs e)
		{
			if (txtBarcode.Text.Length < 9) {
				txtBarcode.Text = "";
				return;
			}

			txtBarcode.Text = txtBarcode.Text.ToUpper ();

			if (txtBarcode.Text.Substring (0, 2) != "PN") {
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Info, ButtonsType.Ok,
										"Invalid Gallery Store Piece");
				md.Run ();
				md.Destroy ();
				txtBarcode.Text = "";
				return;
			}

			try {
				int ArtistID = Int32.Parse (txtBarcode.Text.Substring (2, 3));
				int PieceID = Int32.Parse (txtBarcode.Text.Substring (6, 3));
				SQL SQLConnection = parent.currentSQLConnection;

				MySqlCommand query = new MySqlCommand ("SELECT * FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;", SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@AID", ArtistID);
				query.Parameters.AddWithValue ("@PID", PieceID);
				SQLResult results = SQLConnection.Query (query);

				if (results.GetNumberOfRows () == 1) {
					merchStore.AddNode (new MerchNode (ArtistID.ToString (),
										PieceID.ToString (),
										results.getCell ("PieceTitle", 0),
										"$" + String.Format ("{0:0.00}",
											results.getCell ("PiecePrice", 0))
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
					MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
											MessageType.Error, ButtonsType.Ok,
											"Could not find piece in the database");
					md.Run ();
					md.Destroy ();
					txtBarcode.Text = "";
				}
			} catch (Exception d) {
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Error, ButtonsType.Ok,
										"Error, please show this to your administrator:\n"
										+ d.ToString ());
				md.Run ();
				md.Destroy ();
				txtBarcode.Text = "";
				return;
			}
		}

		protected void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			ResetForm ();

			MerchNode.clearTable (ref lstMerch, ref merchStore);
		}

		protected void OnBtnPayClicked (object sender, System.EventArgs e)
		{
			if (txtPaid.Text == "") {
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Info, ButtonsType.Ok,
										"Please specify the amount that the customer has paid");
				md.Run ();
				md.Destroy ();
				return;
			}

			float paid;

			try {
				paid = float.Parse (txtPaid.Text);
			} catch {
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Info, ButtonsType.Ok,
										"Please enter a valid number in the paid box");
				md.Run ();
				md.Destroy ();
				return;
			}

			if (total > paid) {
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Info, ButtonsType.Ok,
										"Paid amount is too small");
				md.Run ();
				md.Destroy ();
				return;
			}

			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			MySqlCommand query = new MySqlCommand ("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isGalleryStoreSale`, `itemArray`, `priceArray`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES);", SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
			query.Parameters.AddWithValue ("@TOTAL", total);
			query.Parameters.AddWithValue ("@PAID", paid);
			query.Parameters.AddWithValue ("@ITEMS", items);
			query.Parameters.AddWithValue ("@PRICES", prices);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				query = new MySqlCommand ("SELECT `id` FROM `receipts` WHERE `userID` = @UID AND `itemArray` = @ITEMS AND `priceArray` = @PRICES AND `isGalleryStoreSale` = 1 ORDER BY `id` DESC LIMIT 0,1;", SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@UID", User.getCell ("id", 0));
				query.Parameters.AddWithValue ("@TOTAL", total);
				query.Parameters.AddWithValue ("@PAID", paid);
				query.Parameters.AddWithValue ("@ITEMS", items);
				query.Parameters.AddWithValue ("@PRICES", prices);
				results = SQLConnection.Query (query);
				txtChange.Text = "$" + String.Format ("{0:0.00}", (paid - total));

				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Error, ButtonsType.Ok,
										"Receipt processed, please give the following change: "
										+ txtChange.Text +
										"\n\nPlease check the receipt printer.\nThis was transaction ID #"
										+ results.getCell ("id", 0));
				md.Run ();
				md.Destroy ();
				SQLConnection.LogAction ("Made a gallery store sale with receipt #" + results.getCell ("id", 0), User);
				btnPay.Sensitive = false;
				txtPaid.Sensitive = false;
				txtBarcode.Sensitive = false;

			} else {
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Error, ButtonsType.Ok,
										"Connection Error, please close and try again.");
				md.Run ();
				md.Destroy ();
			}
		}
	}
}

