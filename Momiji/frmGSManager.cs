using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmGSManager : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int artistID;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmGSManager (int artistID, frmMenu parent) :
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

		protected void OnBtnGenBarcodeClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnBtnGenCSClicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnButton6Clicked (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

