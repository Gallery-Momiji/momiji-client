using System;

namespace Momiji
{	
	public partial class frmGSSale : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private Gtk.NodeStore merchStore;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmGSSale (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			MerchNode.buildTable (ref lstMerch, ref merchStore);
			//Example node
			merchStore.AddNode (new MerchNode ("1", "5", "GSART", "$10"));
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			parent.CleanupGSSale ();
		}
	}
}

