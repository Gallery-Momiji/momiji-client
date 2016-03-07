using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmUserEdit : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int[] userids;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmUserEdit (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			drpUsers.Active = -1;
			drpRank.Active = -1;

			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			SQLConnection.LogAction ("Attempting to query user information", User);
			MySqlCommand query = new MySqlCommand ("SELECT `id`, `username` FROM `users`;", SQLConnection.GetConnection ());
			query.Prepare ();
			SQLConnection.LogAction ("Queried DB for users", User);
			SQLResult results = SQLConnection.Query (query);
			if (results.GetNumberOfRows () > 0) {
				userids = new int[results.GetNumberOfRows ()];
				for (int i = 0; i < results.GetNumberOfRows(); i++) {
					userids [i] = results.getCellInt ("id", i);
					string temp;
					temp = results.getCell ("username", i);
					temp += ", staff ID#" + results.getCell ("id", i);
					drpUsers.AppendText (temp);
				}
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////
	}
}

