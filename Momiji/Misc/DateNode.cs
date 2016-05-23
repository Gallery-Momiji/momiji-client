using System;
using Gtk;

namespace Momiji
{
	public class DateNode : TreeNode
	{
		public DateNode (int uniqueID, int UserId, string Details, string Time)
		{
			this.uniqueID = uniqueID;
			this.UserId = UserId;
			this.Details = Details;
			this.Time = Time;
		}

		[TreeNodeValue (Column = 0)]
		public int uniqueID;
		[TreeNodeValue (Column = 1)]
		public int UserId;
		[TreeNodeValue (Column = 2)]
		public string Details;
		[TreeNodeValue (Column = 3)]
		public string Time;

		/// <summary>
		/// Builds a NodeView based table of DateNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the DateNodes.
		/// </param>
		public static void buildTable (ref NodeView view, ref NodeStore store)
		{
			store = new NodeStore (typeof(DateNode));
			view.NodeStore = store;
			view.AppendColumn ("Unique ID", new CellRendererText (), "text", 0);
			view.AppendColumn ("User ID", new CellRendererText (), "text", 1);
			view.AppendColumn ("Details", new CellRendererText (), "text", 2);
			view.AppendColumn ("Time", new CellRendererText (), "text", 3);
		}

		/// <summary>
		/// Clears the NodeView table of DateNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the DateNodes.
		/// </param>
		public static void clearTable (ref NodeView view, ref NodeStore store)
		{
			store = null;
			view.NodeStore = null;
			store = new NodeStore (typeof(DateNode));
			view.NodeStore = store;
		}
	}
}

