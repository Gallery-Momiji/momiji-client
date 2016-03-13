using System;

namespace Momiji
{
	public partial class frmCheckin : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmCheckin (frmMenu parent) :
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnEditArtistClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnReloadClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnCheckInClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

