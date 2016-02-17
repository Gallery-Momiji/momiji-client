using System;

namespace Momiji
{
	public partial class frmAuctionSale : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private Gtk.NodeStore merchStore;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmAuctionSale (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			MerchNode.buildTable (ref lstMerch, ref merchStore);
			//Example node
			merchStore.AddNode (new MerchNode ("2", "3", "AUCTART", "$125"));
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			parent.CleanupAuctionSale ();
		}
	}
}

