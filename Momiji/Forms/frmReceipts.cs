using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmReceipts : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int[] idnumbers;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmReceipts (frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			drpTransaction.Active = -1;

			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			SQLConnection.LogAction ("Attempting to query recent receipts", User);
			MySqlCommand query = new MySqlCommand ("SELECT `id`, `userid`, `price` FROM `receipts` ORDER BY id DESC LIMIT 50;",
				SQLConnection.GetConnection ());
			query.Prepare ();
			SQLConnection.LogAction ("Queried DB for receipts", User);
			SQLResult results = SQLConnection.Query (query);
			if (results.GetNumberOfRows () > 0) {
				idnumbers = new int[results.GetNumberOfRows ()];
				for (int i = 0; i < results.GetNumberOfRows (); i++) {
					idnumbers [i] = results.getCellInt ("id", i);
					string temp;
					temp = "Receipt ID " + results.getCell ("id", i);
					temp += " processed by staff id #" + results.getCell ("userid", i);
					temp += " for $" + results.getCell ("price", i);
					drpTransaction.AppendText (temp);
				}
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnPrintClicked (object sender, EventArgs e)
		{
			if (drpTransaction.Active < 0) {
				MessageBox.Show (this, MessageType.Info, "Please select a transaction");
				return;
			}

			Process.Start ("http://" + parent.currentSQLConnection.getHost () + "/momiji/receipt.php?id=" + idnumbers [drpTransaction.Active]);
		}
	}
}

