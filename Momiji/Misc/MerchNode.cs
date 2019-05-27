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

		[TreeNodeValue (Column = 0)]
		public int ArtistID;
		[TreeNodeValue (Column = 1)]
		public int PieceID;
		[TreeNodeValue (Column = 2)]
		public string PieceTitle;
		[TreeNodeValue (Column = 3)]
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

