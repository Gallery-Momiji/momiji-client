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
		private int[,] series;

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

		public frmSearchDate(Operations operation, frmMenu parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.operation = operation;
			this.parent = parent;
			this.Build();
			DateNode.buildTable(ref lstLog, ref dateStore);

			//Populate the date dropdown
			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;
			MySqlCommand query;
			string table;
			if (operation == Operations.CheckUserActivities)
			{
				table = "`log`";
				SQLConnection.LogAction("Queried DB for logs", User);
			}
			else
			{
				table = "`receipts`";
				SQLConnection.LogAction("Queried DB for receipts", User);
			}
			query = new MySqlCommand("SELECT `date`,TRUNCATE(`id`,-2) as `series`,MIN(`id`) as `min`,MAX(`id`) as `max`,MAX(`timestamp`) as `upto` from " + table + " group by `date`,`series`;",
				SQLConnection.GetConnection());

			query.Prepare();
			SQLResult results = SQLConnection.Query(query);

			if (results.GetNumberOfRows() > 0)
			{
				ListStore ClearList = new ListStore(typeof(string), typeof(string));
				drpDate.Model = ClearList;
				datelist = new string[results.GetNumberOfRows()];
				series = new int[results.GetNumberOfRows(),2];
				for (int i = 0; i < results.GetNumberOfRows(); i++)
				{
					datelist[i] = Regex.Replace(results.getCell("date", i), " .*:.*", "");
					series[i,0] = results.getCellInt("min", i);
					series[i,1] = results.getCellInt("max", i);
					drpDate.AppendText(datelist[i] + " - Up to " + results.getCell("upto", i));
				}
			}
			else
			{
				MessageBox.Show(this, MessageType.Error, "Could not find any entries.");
				this.Destroy();
			}

			//Set Window title
			switch (operation)
			{
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

		protected void OnDeleteEvent(object sender, EventArgs e)
		{
			parent.CleanupSearchDate();
		}

		protected void OnDrpDateChanged(object sender, EventArgs e)
		{
			dateStore.Clear();

			if (drpDate.Active >= 0)
			{
				SQL SQLConnection = parent.currentSQLConnection;

				MySqlCommand query;
				if (operation == Operations.CheckUserActivities)
					query = new MySqlCommand("SELECT `log`.`id`,`name`,`action`,`timestamp` FROM `log` LEFT JOIN `users` ON (`log`.`user_id`=`users`.`id`) WHERE `log`.`id` BETWEEN @START AND @END ORDER BY `log`.`id` DESC;",
						SQLConnection.GetConnection());
				else
					query = new MySqlCommand("SELECT `itemArray`,`receipts`.`id`,`name`,`price`,`isQuickSale`,`isAuctionSale`,`isGalleryStoreSale`,`timestamp` FROM `receipts` LEFT JOIN `users` ON (`receipts`.`userid`=`users`.`id`) WHERE `receipts`.`id` BETWEEN @START AND @END ORDER BY `receipts`.`id` DESC;",
						SQLConnection.GetConnection());
				query.Prepare();
				query.Parameters.AddWithValue("@START", series[drpDate.Active,0]);
				query.Parameters.AddWithValue("@END", series[drpDate.Active, 1]);
				SQLResult results = SQLConnection.Query(query);

				if (results.successful())
				{
					for (int i = 0; i < results.GetNumberOfRows(); i++)
					{
						string detail;
						if (operation == Operations.CheckUserActivities)
						{
							detail = results.getCell("action", i);
						}
						else
						{
							detail = results.getCell("itemArray", i).Replace("#", "\n")
							+ "Total $" + results.getCell("price", i);
							if (results.getCellInt("isQuickSale", i) == 1)
								detail = "Quick sale\n" + detail;
							else if (results.getCellInt("isAuctionSale", i) == 1)
								detail = "Auction sale\n" + detail;
							else if (results.getCellInt("isGalleryStoreSale", i) == 1)
								detail = "Gallery Store\n" + detail;
						}

						dateStore.AddNode(new DateNode(results.getCellInt("id", i),
							results.getCell("name", i),
							detail,
							results.getCell("timestamp", i)));
					}
				}
				else
				{
					MessageBox.Show(this, MessageType.Error, "Could not load data for this date.\nPlease contact your administrator.");
					drpDate.Active = -1; //load error
				}
			}
		}

		protected void OnLstLogRowActivated(object o, Gtk.RowActivatedArgs args)
		{
			DateNode selectednode = (DateNode)dateStore.GetNode((TreePath)args.Path);
			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;
			SQLResult results;
			MySqlCommand query;

			switch (operation)
			{
				case Operations.Refund:
					string message = "Receipt #" + selectednode.uniqueID.ToString()
									 + "\nMade by: " + selectednode.User
									 + "\nAt: " + datelist[drpDate.Active] + ", " + selectednode.Time
									 + "\n\nDetails:\n" + selectednode.Details;
					if (MessageBox.Ask(this, "Are you absolutely sure you want to refund the following?\n\n"
						+ message))
					{
						if (MessageBox.Ask(this, "ARE YOU 100% SURE? THIS CAN BE UNDONE!\n\n"
							+ message))
						{

							query = new MySqlCommand("DELETE FROM `receipts` WHERE `id`=@ID;",
								SQLConnection.GetConnection());
							query.Prepare();
							query.Parameters.AddWithValue("@ID", selectednode.uniqueID.ToString());
							results = SQLConnection.Query(query);

							if (results.successful())
							{
								SQLConnection.LogAction("Refunded Receipt#" + selectednode.uniqueID.ToString(), User);
								MessageBox.Show(this, MessageType.Info, "The following has been refunded and removed from the system.\n\n"
								+ message);
								this.Destroy();
							}
							else
							{
								MessageBox.Show(this, MessageType.Error, "Could not process refund.\nPlease contact your administrator.");
							}
						}
					}
					break;
				case Operations.CheckReceipts:
					query = new MySqlCommand("SELECT `itemArray` FROM `receipts` WHERE `id`=@ID;",
						SQLConnection.GetConnection());
					query.Prepare();
					query.Parameters.AddWithValue("@ID", selectednode.uniqueID.ToString());
					results = SQLConnection.Query(query);

					if (results.successful())
						MessageBox.Show(this, MessageType.Info, "Sales:\n" + results.getCell("itemArray", 0).Replace("#", "\n"));
					break;
			}
		}
	}
}

