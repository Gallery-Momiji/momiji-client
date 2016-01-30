using System;

namespace Momiji
{
	public partial class AboutBox : Gtk.Window
	{
		public AboutBox () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

