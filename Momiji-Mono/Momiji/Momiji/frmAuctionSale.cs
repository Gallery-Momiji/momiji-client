using System;

namespace Momiji
{
	public partial class frmAuctionSale : Gtk.Window
	{
		private frmMenu parent;
		
		public frmAuctionSale (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
		}

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			parent.CleanupAuctionSale();
		}
	}
}

