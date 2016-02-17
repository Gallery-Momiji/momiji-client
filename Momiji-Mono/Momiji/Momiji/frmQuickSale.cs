using System;

namespace Momiji
{
	public partial class frmQuickSale : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private Gtk.NodeStore merchStore;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmQuickSale (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			MerchNode.buildTable (ref lstMerch, ref merchStore);
			//Example node
			merchStore.AddNode (new MerchNode ("6", "23", "QSART", "$100"));
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			parent.CleanupQuickSale ();
		}
	}
}

