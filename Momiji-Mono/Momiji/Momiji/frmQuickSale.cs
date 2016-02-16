using System;

namespace Momiji
{
	public partial class frmQuickSale : Gtk.Window
	{
		private frmMenu parent;
		
		public frmQuickSale (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
		}

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			parent.QuickSaleForm = null;
		}
	}
}

