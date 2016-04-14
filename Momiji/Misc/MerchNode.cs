using System;
using Gtk;

namespace Momiji
{
	public class MerchNode : TreeNode
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

		[TreeNodeValue (Column = 0)]
		public int ArtistID;
		[TreeNodeValue (Column = 1)]
		public int PieceID;
		[TreeNodeValue (Column = 2)]
		public string PieceTitle;
		[TreeNodeValue (Column = 3)]
		public string PiecePrice;
		[TreeNodeValue (Column = 4)]
		public int PieceInitialStock;
		[TreeNodeValue (Column = 5)]
		public int PieceStock;
		[TreeNodeValue (Column = 6)]
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
		public static void buildTable (ref NodeView view, ref NodeStore store)
		{
			store = new NodeStore (typeof(MerchNode));
			view.NodeStore = store;
			view.AppendColumn ("Artist ID", new CellRendererText (), "text", 0);
			view.AppendColumn ("Piece ID", new CellRendererText (), "text", 1);
			view.AppendColumn ("Piece Title", new CellRendererText (), "text", 2);
			view.AppendColumn ("Piece Price", new CellRendererText (), "text", 3);
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
		public static void buildTableStock (ref NodeView view, ref NodeStore store)
		{
			store = new NodeStore (typeof(MerchNode));
			view.NodeStore = store;
			view.AppendColumn ("Artist ID", new CellRendererText (), "text", 0);
			view.AppendColumn ("Piece ID", new CellRendererText (), "text", 1);
			view.AppendColumn ("Piece Title", new CellRendererText (), "text", 2);
			view.AppendColumn ("Piece Price", new CellRendererText (), "text", 3);
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
		public static void clearTable (ref NodeView view, ref NodeStore store)
		{
			store = null;
			view.NodeStore = null;
			store = new NodeStore (typeof(MerchNode));
			view.NodeStore = store;
		}
	}
}

