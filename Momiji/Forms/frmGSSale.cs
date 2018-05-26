using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmGSSale : frmParentSale
	{

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
			txtBarcode.Text = "";
			txtTotal.Text = "";
			txtChange.Text = "";
			txtPaid.Text = "";
			drpPaymentType.Active = 0;
			lblPaid.LabelProp = "Paid: <b>$</b>";
			this.items = "";
			this.prices = "";
			this.total = 0;
			txtBarcode.GrabFocus();
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmGSSale(frmMenu parent) :
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
			parent.CleanupGSSale();
		}

		protected void OnTxtBarcodeActivated(object sender, EventArgs e)
		{
			//Wildcards are considered null characters
			txtBarcode.Text = txtBarcode.Text.Replace("*", "").ToUpper();

			int ArtistID, PieceID;
			if (!ParseBarcode(txtBarcode.Text, "PN", out ArtistID, out PieceID))
			{
				txtBarcode.Text = "";
				txtBarcode.GrabFocus();
				return;
			}

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("SELECT `PieceTitle`,`PiecePrice` FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@AID", ArtistID);
			query.Parameters.AddWithValue("@PID", PieceID);
			SQLResult results = SQLConnection.Query(query);

			if (results.GetNumberOfRows() == 1)
			{
				merchStore.AddNode(new MerchNode(ArtistID,
					PieceID,
					results.getCell("PieceTitle", 0),
					"$" + String.Format("{0:0.00}",
						float.Parse(results.getCell("PiecePrice", 0)))
				));

				total = total + float.Parse(results.getCell("PiecePrice", 0));
				txtTotal.Text = String.Format("{0:0.00}", total);

				items = items + txtBarcode.Text + "#";
				prices = prices + results.getCell("PiecePrice", 0) + "#";

				btnPay.Sensitive = true;
				txtPaid.Sensitive = true;
				drpPaymentType.Sensitive = true;
				btnCancel.Sensitive = true;
			}
			else
			{
				MessageBox.Show(this, MessageType.Error,
					"Could not find piece in the database");
			}

			txtBarcode.Text = "";
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

			MySqlCommand query = new MySqlCommand("INSERT INTO `receipts` ( `userID`, `price`, `paid`, `isGalleryStoreSale`, `itemArray`, `priceArray`, `Last4digitsCard`, `timestamp`, `date`) VALUES ( @UID, @TOTAL, @PAID, 1, @ITEMS, @PRICES, @FOURDIG, CURRENT_TIME, CURRENT_DATE); SELECT LAST_INSERT_ID() as `id`;",
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

				SQLConnection.LogAction("Made a gallery store sale with receipt #" + receiptID,
					User);
				txtPaid.Sensitive = false;
				drpPaymentType.Sensitive = false;
				txtBarcode.Sensitive = false;
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

