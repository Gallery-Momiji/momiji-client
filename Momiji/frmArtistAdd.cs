using System;

namespace Momiji
{
	public partial class frmArtistAdd : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmArtistAdd (frmMenu parent) :
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnGenerateClicked (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnUpdateClicked (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

