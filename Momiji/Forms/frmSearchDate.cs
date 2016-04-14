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

			//Set Window title
			switch (operation) {
			case Operations.CheckSales:
				this.Title = "Sales by date";
				break;
			case Operations.Refund:
				this.Title = "Sales available for refund by date";
				break;
			case Operations.CheckReceipts:
				this.Title = "Receipts by date";
				break;
			case Operations.CheckUserActivities:
				this.Title = "User activities by date";
				break;
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object sender, EventArgs e)
		{
			parent.CleanupSearchDate ();
		}

		//TODO//

		protected void OnDrpDateChanged (object sender, EventArgs e)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}

		protected void OnLstLogRowActivated (object o, Gtk.RowActivatedArgs args)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}
	}
}

