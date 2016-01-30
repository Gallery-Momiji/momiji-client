using System;

namespace Momiji
{
	public partial class frmMenu : Gtk.Window
	{
		private frmLogin LoginForm;
		private frmGSSale GSSaleForm;
		private frmAuctionSale AuctionSaleForm;
		private frmQuickSale QuickSaleForm;
		
		public frmMenu (frmLogin parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.LoginForm = parent;
			this.Build ();
		}
		
		private void CloseForm() {
			//This restores frmlogin and destroys the menu
			
			if(QuickSaleForm != null)
				QuickSaleForm.Destroy ();
			if(AuctionSaleForm != null)
				AuctionSaleForm.Destroy ();
			if(GSSaleForm != null)
				GSSaleForm.Destroy ();
			LoginForm.Show();
			LoginForm.GrabFocus();
			this.Destroy();
		}

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			CloseForm();
		}

		protected void OnBtnLogoutClicked (object sender, System.EventArgs e)
		{
			CloseForm();
		}

		protected void OnExitActionActivated (object sender, System.EventArgs e)
		{
			CloseForm();
		}

		protected void OnBtnQuickSaleClicked (object sender, System.EventArgs e)
		{
			if(QuickSaleForm != null)
				QuickSaleForm.Destroy();
	   		QuickSaleForm = new frmQuickSale();
		}

		protected void OnBtnAuctionSaleClicked (object sender, System.EventArgs e)
		{
			if(AuctionSaleForm != null)
				AuctionSaleForm.Destroy();
			AuctionSaleForm = new frmAuctionSale();
		}

		protected void OnBtnGalleryStoreSaleClicked (object sender, System.EventArgs e)
		{
			if(GSSaleForm != null)
				GSSaleForm.Destroy();
			GSSaleForm = new frmGSSale();
		}
	}
}

