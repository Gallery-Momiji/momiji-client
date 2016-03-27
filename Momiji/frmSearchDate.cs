using System;

namespace Momiji
{
	public partial class frmSearchDate : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private Operations operation;
		private frmMenu parent;

		/////////////////////////
		//   Public Attributes //
		/////////////////////////

		public enum Operations
		{
			CheckSales,
			Refund,
			CheckReceipts,
			CheckUserActivities
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmSearchDate (Operations operation, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.operation = operation;
			this.parent = parent;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDrpDateChanged (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected void OnLstLogRowActivated (object o, Gtk.RowActivatedArgs args)
		{
			throw new NotImplementedException ();
		}
	}
}

