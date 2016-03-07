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
		//  Private Functions  //
		/////////////////////////

		private void loadUserData()
		{
			//TODO
			//if drpUsers.Active == -1, clear form
			//else load info
		}

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
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not find any registered users.\nTry again or please contact your administrator.");
				this.Destroy ();
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		//TODO these are not tied to gtk EventHandler's yet

		//TODO on drpUsers change, automatically call loadUserData()

		protected void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			this.Destroy ();
		}

		protected void OnBtnLoadInfoClicked (object sender, System.EventArgs e)
		{
			loadUserData();
		}

		//TODO these buttons should be disabled if a user is not selected
		protected void OnBtnDeleteClicked (object sender, System.EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			string userID = userids [drpUsers.Active].ToString ();

            MySqlCommand query = new MySqlCommand("DELETE FROM `users` WHERE `id`=@ID;", SQLConnection.GetConnection());
            query.Prepare();
			query.Parameters.AddWithValue("@ID", userID);
            SQLResult results = SQLConnection.Query(query);

			if (results.successful()) {
				SQLConnection.LogAction("Deleted user " + userID, parent.currentUser);
				MessageBox.Show (this, MessageType.Info, "User deleted successfully");
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not update user.\nPlease contact your administrator.");
			}

			drpUsers.Active = -1;
			loadUserData();
		}

		protected void OnBtnUpdateClicked (object sender, System.EventArgs e)
		{
			string userID, userName, password1, password2, userFnameLname, userClass;
			userName = txtUsername.Text.ToLower ();
			password1 = txtPass.Text;
			password2 = txtPassRepeat.Text;
			userFnameLname = txtName.Text;
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query;
			userID = userids [drpUsers.Active].ToString ();

			if (userName.Length == 0 || userFnameLname.Length == 0 ||
				drpRank.Active < 0) {
				MessageBox.Show (this, MessageType.Info, "All fields, except password, are required");
				return;
			}

			userClass = drpRank.Active.ToString ();

			if (password1.Length != 0 || password2.Length != 0)	{
				if (txtPass.Text == txtPassRepeat.Text) {
					MD5 passHash = new MD5 (password1);
					query = new MySqlCommand("UPDATE `users` SET `username`=@USER, `password`=@PASS, `class`=@RANK, `name`=@NAME WHERE `id`=@ID;", SQLConnection.GetConnection());
					query.Parameters.AddWithValue("@PASS", passHash.getShortHash ());
				} else {
					MessageBox.Show (this, MessageType.Info, "Password and and retype password fields do not match");
					return;
				}
			} else {
				query = new MySqlCommand("UPDATE `users` SET `username`=@USER, `class`=@RANK, `name`=@NAME WHERE `id`=@ID;", SQLConnection.GetConnection());
			}

			query.Prepare();
			query.Parameters.AddWithValue("@USER", userName);
			query.Parameters.AddWithValue("@RANK", userClass);
			query.Parameters.AddWithValue("@NAME", userFnameLname);
			query.Parameters.AddWithValue("@ID", userID);
			SQLResult results = SQLConnection.Query(query);

			if (results.successful()) {
				SQLConnection.LogAction("Updated info on user #" + userID, parent.currentUser);
				MessageBox.Show (this, MessageType.Info, "User updated successfully");
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not update user.\nPlease contact your administrator.");
			}

			loadUserData();
		}
	}
}

