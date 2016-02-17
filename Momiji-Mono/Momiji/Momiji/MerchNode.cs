using System;

namespace Momiji
{
	public class MerchNode : Gtk.TreeNode
	{
		public MerchNode (string ArtistID, string PieceID, string PieceTitle, string PiecePrice)
		{
			this.ArtistID = ArtistID;
			this.PieceID = PieceID;
			this.PieceTitle = PieceTitle;
			this.PiecePrice = PiecePrice;
		}
 
		[Gtk.TreeNodeValue (Column=0)]
		public string ArtistID;
		[Gtk.TreeNodeValue (Column=1)]
		public string PieceID;
		[Gtk.TreeNodeValue (Column=2)]
		public string PieceTitle;
		[Gtk.TreeNodeValue (Column=3)]
		public string PiecePrice;
		
		/// <summary>
		/// Builds a NodeView based table of MerchNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the MerchNodes.
		/// </param>
		public static void buildTable (ref Gtk.NodeView view, ref Gtk.NodeStore store)
		{
			store = new Gtk.NodeStore (typeof(MerchNode));
			view.NodeStore = store;
			view.AppendColumn ("Artist ID", new Gtk.CellRendererText (), "text", 0);
			view.AppendColumn ("Piece ID", new Gtk.CellRendererText (), "text", 1);
			view.AppendColumn ("Piece Title", new Gtk.CellRendererText (), "text", 2);
			view.AppendColumn ("Piece Price", new Gtk.CellRendererText (), "text", 3);
		}
	}
}

