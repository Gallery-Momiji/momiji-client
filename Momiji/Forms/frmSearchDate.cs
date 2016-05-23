using System;
using Gtk;
using MySql.Data.MySqlClient;

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
					datelist [i] = results.getCell ("date", i);
					drpDate.AppendText (results.getCell ("date", i));
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

		//TODO//

		protected void OnDrpDateChanged (object sender, EventArgs e)
		{
			if (drpDate.Active >= 0) {
				SQL SQLConnection = parent.currentSQLConnection;
				SQLResult User = parent.currentUser;
				string date = datelist [drpDate.Active];

				MySqlCommand query;
				if (operation == Operations.CheckUserActivities) {
					query = new MySqlCommand ("SELECT `id`,`user_id` AS `userid`,`action`,`timestamp` FROM `log` WHERE `date` = @DATE;",
						SQLConnection.GetConnection ());
					SQLConnection.LogAction ("Queried DB for logs", User);
				} else {
					query = new MySqlCommand ("SELECT `id`,`userid`,`price`,`timestamp` FROM `receipts` WHERE `date` = @DATE;",
						SQLConnection.GetConnection ());
					SQLConnection.LogAction ("Queried DB for receipts", User);
				}
				query.Prepare ();
				query.Parameters.AddWithValue ("@DATE", date);
				SQLResult results = SQLConnection.Query (query);

				if (results.successful ()) {
					for (int i = 0; i < results.GetNumberOfRows (); i++) {
						dateStore.AddNode (new DateNode (results.getCellInt ("id", i),
							results.getCellInt ("userid", i),
							"",
							results.getCell ("timestamp", i)));
					}
				} else {
					MessageBox.Show (this, MessageType.Error, "Could not load data for this date.\nPlease contact your administrator.");
					drpDate.Active = -1; //load error
				}
			}
			//If no date is selected or on load error, reset form
			if (drpDate.Active < 0) {
				dateStore.Clear ();
			}
		}

		protected void OnLstLogRowActivated (object o, Gtk.RowActivatedArgs args)
		{
#if DEBUG
			throw new System.NotImplementedException ();
#endif
		}
	}
}

