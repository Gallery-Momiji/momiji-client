using System;

namespace Momiji
{
	public class MerchNode : Gtk.TreeNode
	{
		public MerchNode (int ArtistID, int PieceID, string PieceTitle, string PiecePrice)
		{
			this.ArtistID = ArtistID;
			this.PieceID = PieceID;
			this.PieceTitle = PieceTitle;
			this.PiecePrice = PiecePrice;
		}

		public MerchNode (int PieceID, string PieceTitle, string PiecePrice,
		                  int PieceInitialStock, int PieceStock, bool PieceSDC)
		{
			this.PieceID = PieceID;
			this.PieceTitle = PieceTitle;
			this.PiecePrice = PiecePrice;
			this.PieceInitialStock = PieceInitialStock;
			this.PieceStock = PieceStock;
			this.PieceSDC = PieceSDC;
		}
 
		[Gtk.TreeNodeValue (Column=0)]
		public int ArtistID;
		[Gtk.TreeNodeValue (Column=1)]
		public int PieceID;
		[Gtk.TreeNodeValue (Column=2)]
		public string PieceTitle;
		[Gtk.TreeNodeValue (Column=3)]
		public string PiecePrice;
		[Gtk.TreeNodeValue (Column=4)]
		public int PieceInitialStock;
		[Gtk.TreeNodeValue (Column=5)]
		public int PieceStock;
		[Gtk.TreeNodeValue (Column=6)]
		public bool PieceSDC;

		/// <summary>
		/// Builds a NodeView based table of MerchNodes.
		/// This one build a item sale table.
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

		/// <summary>
		/// Builds a NodeView based table of MerchNodes.
		/// This one build a artist stock table.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the MerchNodes.
		/// </param>
		public static void buildTableStock (ref Gtk.NodeView view, ref Gtk.NodeStore store)
		{
			store = new Gtk.NodeStore (typeof(MerchNode));
			view.NodeStore = store;
			view.AppendColumn ("Artist ID", new Gtk.CellRendererText (), "text", 0);
			view.AppendColumn ("Piece ID", new Gtk.CellRendererText (), "text", 1);
			view.AppendColumn ("Piece Title", new Gtk.CellRendererText (), "text", 2);
			view.AppendColumn ("Piece Price", new Gtk.CellRendererText (), "text", 3);
		}

		/// <summary>
		/// Clears the NodeView table of MerchNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the MerchNodes.
		/// </param>
		public static void clearTable (ref Gtk.NodeView view, ref Gtk.NodeStore store)
		{
			store = null;
			view.NodeStore = null;
			store = new Gtk.NodeStore (typeof(MerchNode));
			view.NodeStore = store;
		}
	}
}

