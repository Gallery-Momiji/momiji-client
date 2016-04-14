using System;
using Gtk;

namespace Momiji
{
	public class ArtistNode : TreeNode
	{
		public ArtistNode (int ArtistID, string ArtistName, string ArtistShowName)
		{
			this.ArtistID = ArtistID;
			this.ArtistName = ArtistName;
			this.ArtistShowName = ArtistShowName;
		}

		[TreeNodeValue (Column = 0)]
		public int ArtistID;
		[TreeNodeValue (Column = 1)]
		public string ArtistName;
		[TreeNodeValue (Column = 2)]
		public string ArtistShowName;

		/// <summary>
		/// Builds a NodeView based table of ArtistNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the ArtistNodes.
		/// </param>
		public static void buildTable (ref NodeView view, ref NodeStore store)
		{
			store = new NodeStore (typeof(ArtistNode));
			view.NodeStore = store;
			view.AppendColumn ("Artist ID", new CellRendererText (), "text", 0);
			view.AppendColumn ("Artist Name", new CellRendererText (), "text", 1);
			view.AppendColumn ("Show Name", new CellRendererText (), "text", 2);
		}

		/// <summary>
		/// Clears the NodeView table of ArtistNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the ArtistNodes.
		/// </param>
		public static void clearTable (ref NodeView view, ref NodeStore store)
		{
			store = null;
			view.NodeStore = null;
			store = new NodeStore (typeof(ArtistNode));
			view.NodeStore = store;
		}
	}
}

