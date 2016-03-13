using System;

namespace Momiji
{
	public partial class fmLog : Gtk.Window
	{
		public fmLog () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

