using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmArtistCheckout : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int artistID;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmArtistCheckout (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.artistID = artistID;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnGenSaleSumClicked (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected void OnButton6Clicked (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected void OnButtonCancelClicked (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}
	}
}

