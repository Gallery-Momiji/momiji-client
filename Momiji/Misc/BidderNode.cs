using System;
using Gtk;

namespace Momiji
{
	public class BidderNode : TreeNode
	{
		public BidderNode (int bidderno, string name, string phoneno, string eaddress, string due, string maddress)
		{
			this.bidderno = bidderno;
			this.name = name;
			this.phoneno = phoneno;
			this.eaddress = eaddress;
			this.due = due;
			this.maddress = maddress;
		}

		[TreeNodeValue (Column = 0)]
		public int bidderno;
		[TreeNodeValue (Column = 1)]
		public string name;
		[TreeNodeValue (Column = 2)]
		public string phoneno;
		[TreeNodeValue (Column = 3)]
		public string eaddress;
		[TreeNodeValue (Column = 4)]
		public string due;
		[TreeNodeValue (Column = 5)]
		public string maddress;

		/// <summary>
		/// Builds a NodeView based table of BidderNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the BidderNodes.
		/// </param>
		public static void buildTable (ref NodeView view, ref NodeStore store)
		{
			store = new NodeStore (typeof(BidderNode));
			view.NodeStore = store;
			view.AppendColumn ("Bidder No", new CellRendererText (), "text", 0);
			view.AppendColumn ("Name", new CellRendererText (), "text", 1);
			view.AppendColumn ("Phone", new CellRendererText (), "text", 2);
			view.AppendColumn ("Email", new CellRendererText (), "text", 3);
			view.AppendColumn ("Due", new CellRendererText (), "text", 4);
			view.AppendColumn ("Address", new CellRendererText (), "text", 5);
		}

		/// <summary>
		/// Clears the NodeView table of BidderNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the BidderNodes.
		/// </param>
		public static void clearTable (ref NodeView view, ref NodeStore store)
		{
			store = null;
			view.NodeStore = null;
			store = new NodeStore (typeof(BidderNode));
			view.NodeStore = store;
		}
	}
}

