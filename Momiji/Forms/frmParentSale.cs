using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	//Parent Class for common Sales code
	public class frmParentSale : Gtk.Window
	{
		/////////////////////////
		//  Attributes         //
		/////////////////////////

		protected frmMenu parent;
		protected NodeStore merchStore;
		protected float total = 0;
		protected int receiptID = 0;
		public string items = "";
		public string prices = "";

		/////////////////////////
		//  Functions          //
		/////////////////////////

		public frmParentSale(frmMenu parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
		}

		protected bool ExistsInList(string barcode)
		{
			int i = 0;

			while (items.Length - 9 > i)
			{
				if (items.Substring(i, 9) == barcode)
				{
					MessageBox.Show(this, MessageType.Info,
						"Item already scanned");
					return true;
				}
				i += 10;
			}

			return false;
		}

		protected bool ParseBarcode(string barcode, string prefix, out int ArtistID, out int MerchID)
		{
			ArtistID = 0;
			MerchID = 0;

			if (barcode.Length < 9)
			{
				return false;
			}

			//Catch for format, XX###-###
			if (barcode.Substring(0, 2) != prefix ||
				barcode.Substring(5, 1) != "-")
			{
				MessageBox.Show(this, MessageType.Error, "Invalid barcode");
				return false;
			}

			//Try to parse barcode
			if (!int.TryParse(barcode.Substring(2, 3), out ArtistID) ||
				!int.TryParse(barcode.Substring(6, 3), out MerchID))
			{
				MessageBox.Show(this, MessageType.Error,
					"Invalid barcode format");
				return false;
			}

			return true;
		}

		protected bool CheckPaidAmount(int type, string paidtext, out float paid, out int fourdigits)
		{
			paid = 0;
			fourdigits = 0;

			if (type == 0) //Cash
			{
				if (paidtext == "")
				{
					MessageBox.Show(this, MessageType.Info,
						"Please specify the amount that the customer has paid");
					return false;
				}

				if (!float.TryParse(paidtext, out paid))
				{
					MessageBox.Show(this, MessageType.Info,
						"Please enter a valid number in the paid box");
					return false;
				}

				if (total > paid)
				{
					MessageBox.Show(this, MessageType.Info,
						"Paid amount is too small");
					return false;
				}

				if (paid - total >= 100)
				{
					if (!MessageBox.Ask(this,
						"Paid amount is very large, are you sure this is a cash sale?"))
						return false;
				}
			}
			else //Card
			{
				if (paidtext.Length != 4)
				{
					MessageBox.Show(this, MessageType.Info,
						"Please enter the last 4 digits on the card");
					return false;
				}

				if (!int.TryParse(paidtext, out fourdigits))
				{
					MessageBox.Show(this, MessageType.Info,
						"Please enter a valid set of 4 digits");
					return false;
				}

				if (!MessageBox.Ask(this, "Has the card transaction been approved?"))
					return false;

				paid = total;
			}

			return true;
		}

		protected void FinishSaleMessage(string change, float paid)
		{
			if (paid > total)
			{
				MessageBox.Show(this, MessageType.Info,
					"Sale processed, please give the following change: $"
					+ change +
					"\n\nClick on the button below to generate a receipt.\nThis was transaction ID #"
					+ receiptID);
			}
			else
			{
				MessageBox.Show(this, MessageType.Info,
					"Sale processed!\n\nClick on the button below to generate a receipt.\nThis was transaction ID #"
					+ receiptID);
			}
		}

		protected void PrintReceipt()
		{
			Process.Start("http://" + parent.currentSQLConnection.getHost() + "/momiji/receipt.php?id=" + receiptID);
		}
	}
}

