using System;

namespace Momiji
{
	public partial class frmMerchEditor : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int artistID;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmMerchEditor (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.artistID = artistID;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnGenIDClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnUpdateClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnAddClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnClearClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnDeleteClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnCreateSheetClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnGenCSClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

