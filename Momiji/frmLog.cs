using System;

namespace Momiji
{
	public partial class frmLog : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmLog (frmMenu parent) :
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDrpDateChanged (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

