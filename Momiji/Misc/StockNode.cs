using Gtk;

namespace Momiji
{
	public class StockNode : TreeNode
	{
		public StockNode (int merchID, string merchTitle, string merchMinBid,
			string quicksale, int AAMB)
		{
			this.PieceID = merchID;
			this.PieceTitle = merchTitle;
			this.PieceMinPrice = "$"+merchMinBid;
			this.PieceOther = (quicksale=="0")?"N/A":"$"+quicksale;
			this.PieceBool = (AAMB==1)?"Yes":"No";
		}

		public StockNode (int gsmerchID, string gsmerchTitle, string gsmerchPrice,
			int gsmerchStock, int SDC)
		{
			this.PieceID = gsmerchID;
			this.PieceTitle = gsmerchTitle;
			this.PieceMinPrice = "$"+gsmerchPrice;
			this.PieceOther = gsmerchStock.ToString();
			this.PieceBool = (SDC==1)?"Yes":"No";
		}

		[TreeNodeValue (Column = 0)]
		public int PieceID;
		[TreeNodeValue (Column = 1)]
		public string PieceTitle;
		[TreeNodeValue (Column = 2)]
		public string PieceMinPrice;
		[TreeNodeValue (Column = 3)]
		public string PieceOther;//QS price or Stock
		[TreeNodeValue (Column = 4)]
		public string PieceBool; //AAMB or SDC

		/// <summary>
		/// Builds a NodeView based table of StockNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the StockNodes.
		/// </param>
		public static void buildTableMerch (ref NodeView view, ref NodeStore store)
		{
			store = new NodeStore (typeof(StockNode));
			view.NodeStore = store;
			view.AppendColumn ("ID", new CellRendererText (), "text", 0);
			view.AppendColumn ("Title", new CellRendererText (), "text", 1);
			view.AppendColumn ("Min Bid", new CellRendererText (), "text", 2);
			view.AppendColumn ("Quick Sale", new CellRendererText (), "text", 3);
			view.AppendColumn ("After Auction", new CellRendererText (), "text", 4);
		}

		/// <summary>
		/// Builds a NodeView based table of StockNodes.
		/// </summary>
		/// <param name='view'>
		/// NodeView to hold the table.
		/// </param>
		/// <param name='store'>
		/// NodeStore for holding the StockNodes.
		/// </param>
		public static void buildTableGSMerch (ref NodeView view, ref NodeStore store)
		{
			store = new NodeStore (typeof(StockNode));
			view.NodeStore = store;
			view.AppendColumn ("ID", new CellRendererText (), "text", 0);
			view.AppendColumn ("Title", new CellRendererText (), "text", 1);
			view.AppendColumn ("Price", new CellRendererText (), "text", 2);
			view.AppendColumn ("Stock", new CellRendererText (), "text", 3);
			view.AppendColumn ("Sell Display Copy", new CellRendererText (), "text", 4);
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

