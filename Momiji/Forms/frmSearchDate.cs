using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Momiji
{
	public partial class frmSearchDate : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private Operations operation;
		private NodeStore dateStore;
		private frmMenu parent;
		private string[] datelist;

		/////////////////////////
		//   Public Attributes //
		/////////////////////////

		public enum Operations
		{
			Refund,
			CheckReceipts,
			CheckUserActivities
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmSearchDate (Operations operation, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.operation = operation;
			this.parent = parent;
			this.Build ();
			DateNode.buildTable (ref lstLog, ref dateStore);

			//Populate the date dropdown
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query;
			if (operation == Operations.CheckUserActivities)
				query = new MySqlCommand ("SELECT DISTINCT(`date`) from `log`;",
					SQLConnection.GetConnection ());
			else
				query = new MySqlCommand ("SELECT DISTINCT(`date`) from `receipts`;",
					SQLConnection.GetConnection ());

			query.Prepare ();
			SQLResult results = SQLConnection.Query (query);

			if (results.GetNumberOfRows () > 0) {
				ListStore ClearList = new ListStore (typeof(string), typeof(string));
				drpDate.Model = ClearList;
				datelist = new string[results.GetNumberOfRows ()];
				for (int i = 0; i < results.GetNumberOfRows (); i++) {
					datelist [i] = Regex.Replace (results.getCell ("date", i), " .*:.*", "");
					drpDate.AppendText (datelist [i]);
				}
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not find any entries.");
				this.Destroy ();
			}

			//Set Window title
			switch (operation) {
			case Operations.Refund:
				this.Title = "Sales available for refund by date";
				break;
			case Operations.CheckReceipts:
				this.Title = "Receipts by date";
				break;
			case Operations.CheckUserActivities:
				this.Title = "User activities by date";
				break;
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object sender, EventArgs e)
		{
			parent.CleanupSearchDate ();
		}

		protected void OnDrpDateChanged (object sender, EventArgs e)
		{
			dateStore.Clear ();

			if (drpDate.Active >= 0) {
				SQL SQLConnection = parent.currentSQLConnection;
				SQLResult User = parent.currentUser;
				string date = datelist [drpDate.Active];

				MySqlCommand query;
				if (operation == Operations.CheckUserActivities) {
					query = new MySqlCommand ("SELECT `log`.`id`,`name`,`action`,`timestamp` FROM `log` LEFT JOIN `users` ON (`log`.`user_id`=`users`.`id`) WHERE `date` = @DATE ORDER BY `timestamp`;",
						SQLConnection.GetConnection ());
					SQLConnection.LogAction ("Queried DB for logs", User);
				} else {
					query = new MySqlCommand ("SELECT `receipts`.`id`,`name`,`price`,`isQuickSale`,`isAuctionSale`,`isGalleryStoreSale`,`timestamp` FROM `receipts` LEFT JOIN `users` ON (`receipts`.`userid`=`users`.`id`) WHERE `date` = @DATE ORDER BY `timestamp`;",
						SQLConnection.GetConnection ());
					SQLConnection.LogAction ("Queried DB for receipts", User);
				}
				query.Prepare ();
				query.Parameters.AddWithValue ("@DATE", date);
				SQLResult results = SQLConnection.Query (query);

				if (results.successful ()) {
					for (int i = 0; i < results.GetNumberOfRows (); i++) {
						string detail;
						if (operation == Operations.CheckUserActivities) {
							detail = results.getCell ("action", i);
						} else {
							detail = "$" + results.getCell ("price", i);
							if (results.getCellInt ("isQuickSale", i) == 1)
								detail = "Quick sale of " + detail;
							else if (results.getCellInt ("isAuctionSale", i) == 1)
								detail = "Auction sale of " + detail;
							else if (results.getCellInt ("isGalleryStoreSale", i) == 1)
								detail = "Gallery Store sale of " + detail;
						}

						dateStore.AddNode (new DateNode (results.getCellInt ("id", i),
							results.getCell ("name", i),
							detail,
							results.getCell ("timestamp", i)));
					}
				} else {
					MessageBox.Show (this, MessageType.Error, "Could not load data for this date.\nPlease contact your administrator.");
					drpDate.Active = -1; //load error
				}
			}
		}

		//TODO//

		protected void OnLstLogRowActivated (object o, Gtk.RowActivatedArgs args)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}
	}
}

