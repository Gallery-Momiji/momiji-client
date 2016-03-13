using System;

namespace Momiji
{
	public class ArtistNode : Gtk.TreeNode
	{
		public ArtistNode (int ArtistID, string ArtistName, string ArtistShowName)
		{
			this.ArtistID = ArtistID;
			this.ArtistName = ArtistName;
			this.ArtistShowName = ArtistShowName;
		}

		[Gtk.TreeNodeValue (Column=0)]
		public int ArtistID;
		[Gtk.TreeNodeValue (Column=1)]
		public string ArtistName;
		[Gtk.TreeNodeValue (Column=2)]
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
		public static void buildTable (ref Gtk.NodeView view, ref Gtk.NodeStore store)
		{
			store = new Gtk.NodeStore (typeof(ArtistNode));
			view.NodeStore = store;
			view.AppendColumn ("Artist ID", new Gtk.CellRendererText (), "text", 0);
			view.AppendColumn ("Artist Name", new Gtk.CellRendererText (), "text", 1);
			view.AppendColumn ("Show Name", new Gtk.CellRendererText (), "text", 2);
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
		public static void clearTable (ref Gtk.NodeView view, ref Gtk.NodeStore store)
		{
			store = null;
			view.NodeStore = null;
			store = new Gtk.NodeStore (typeof(ArtistNode));
			view.NodeStore = store;
		}
	}
}

