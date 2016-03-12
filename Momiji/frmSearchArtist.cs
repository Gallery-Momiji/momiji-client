using System;

namespace Momiji
{
	public partial class frmSearchArtist : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmSearchArtist () :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnTxtSearchActivated (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnSearchClicked (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

