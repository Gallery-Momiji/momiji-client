using System;
using Gtk;

namespace Momiji
{
	public class StockNode : TreeNode
	{
		public StockNode (int PieceID, string PieceTitle, string PiecePrice,
			int PieceInitialStock, string PieceSDC)
		{
			this.PieceID = PieceID;
			this.PieceTitle = PieceTitle;
			this.PiecePrice = PiecePrice;
			this.PieceInitialStock = PieceInitialStock;
			this.PieceSDC = PieceSDC;
		}

		[TreeNodeValue (Column = 0)]
		public int PieceID;
		[TreeNodeValue (Column = 1)]
		public string PieceTitle;
		[TreeNodeValue (Column = 2)]
		public string PiecePrice;
		[TreeNodeValue (Column = 3)]
		public int PieceInitialStock;
		[TreeNodeValue (Column = 4)]
		public string PieceSDC;

		/// <summary>
		/// Builds a NodeView based table of StockNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the StockNodes.
		/// </param>
		public static void buildTable (ref NodeView view, ref NodeStore store)
		{
			store = new NodeStore (typeof(StockNode));
			view.NodeStore = store;
			view.AppendColumn ("Piece ID", new CellRendererText (), "text", 0);
			view.AppendColumn ("Piece Title", new CellRendererText (), "text", 1);
			view.AppendColumn ("Piece Price", new CellRendererText (), "text", 2);
			view.AppendColumn ("Stock", new CellRendererText (), "text", 3);
			view.AppendColumn ("SDC", new CellRendererText (), "text", 4);
		}

		/// <summary>
		/// Clears the NodeView table of StockNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the StockNodes.
		/// </param>
		public static void clearTable (ref NodeView view, ref NodeStore store)
		{
			store = null;
			view.NodeStore = null;
			store = new NodeStore (typeof(StockNode));
			view.NodeStore = store;
		}
	}
}

