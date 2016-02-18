using System;

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
			//TODO change widget names
			/*txtBarcode.Sensitive = true;
			btnCancel.Sensitive = false;
			btnPay.Sensitive = false;
			txtPaid.Sensitive = false;
			btnAddToList.Sensitive = false;
			btnClear.Sensitive = false;
			txtBarcode.Text = "";
			txtPrice.Text = "";
			txtTotal.Text = "";
			txtChange.Text = "";
			txtPaid.Text = "";*/
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
	}
}

