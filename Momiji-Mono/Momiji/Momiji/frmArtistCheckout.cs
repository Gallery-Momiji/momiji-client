using System;

namespace Momiji
{
	public partial class frmArtistCheckout : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmArtistCheckout (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////
	}
}

