using System;

namespace Momiji
{
	public partial class frmCheckin : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int artistID;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmCheckin (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.artistID = artistID;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		//TODO//

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnBtnEditArtistClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnBtnReloadClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnBtnCheckInClicked (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}
	}
}

