using System;

namespace Momiji
{
	public partial class frmGSSale : Gtk.Window
	{
		private frmMenu parent;
		
		public frmGSSale (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
		}

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			parent.CleanupGSSale();
		}
	}
}

