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

		private void loadUserData ()
		{

			if (drpUsers.Active >= 0) {
				SQL SQLConnection = parent.currentSQLConnection;
				SQLResult User = parent.currentUser;
				string userID = userids [drpUsers.Active].ToString ();

				MySqlCommand query = new MySqlCommand ("SELECT * FROM `users` WHERE `id` = @ID;", SQLConnection.GetConnection ());
				query.Prepare ();
				query.Parameters.AddWithValue ("@ID", userID);
				SQLConnection.LogAction ("Queried DB for users", User);
				SQLResult results = SQLConnection.Query (query);

				if (results.successful ()) {
					SQLConnection.LogAction ("Loaded info from user #" + userID, User);
					txtName.Text = results.getCell ("name", 0);
					txtUsername.Text = results.getCell ("username", 0);
					drpRank.Active = results.getCellInt ("class", 0);
					bool isadmin = (parent.currentUser.getCellInt ("class", 0) >= 11);
					drpUsers.Sensitive = isadmin;
					drpRank.Sensitive = isadmin;
					lblChooseUser.Sensitive = isadmin;
					btnCancel.Sensitive = isadmin;
					btnDelete.Sensitive = isadmin;
					txtUsername.Sensitive = true;
					txtName.Sensitive = true;
					txtPass.Sensitive = true;
					btnUpdate.Sensitive = true;
					txtPassRepeat.Sensitive = true;
				} else {
					MessageBox.Show (this, MessageType.Error, "Could not load user.\nPlease contact your administrator.");
					drpUsers.Active = -1; //load error
				}
			}
			//If no user selected or on load error, reset form
			if (drpUsers.Active < 0) {
				txtUsername.Text = "";
				txtName.Text = "";
				drpRank.Active = -1;
				txtUsername.Sensitive = false;
				txtName.Sensitive = false;
				drpRank.Sensitive = false;
				txtPass.Sensitive = false;
				txtPassRepeat.Sensitive = false;
				btnDelete.Sensitive = false;
				btnUpdate.Sensitive = false;
				btnCancel.Sensitive = false;
			}

			//Always clear password fields
			txtPass.Text = "";
			txtPassRepeat.Text = "";
		}

		private void loadUserList ()
		{
			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			SQLConnection.LogAction ("Attempting to query user information", User);
			MySqlCommand query = new MySqlCommand ("SELECT `id`, `username` FROM `users`;", SQLConnection.GetConnection ());
			query.Prepare ();
			SQLConnection.LogAction ("Queried DB for users", User);
			SQLResult results = SQLConnection.Query (query);
			if (results.GetNumberOfRows () > 0) {
				ListStore ClearList = new ListStore (typeof(string), typeof(string));
				drpUsers.Model = ClearList;
				userids = new int[results.GetNumberOfRows ()];
				for (int i = 0; i < results.GetNumberOfRows (); i++) {
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
		//     Contructor      //
		/////////////////////////

		public frmUserEdit (frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			drpUsers.Active = -1;
			loadUserData ();
			loadUserList ();
		}

		public frmUserEdit (int id, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			drpUsers.Active = -1;
			loadUserData ();
			loadUserList ();
			int i;
			for (i = 0; i < userids.Length; i++)
				if (userids [i] == id)
					break;
			if (i < userids.Length) {
				drpUsers.Active = i;
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not find user data.\nTry again or please contact your administrator.");
				this.Destroy ();
			} 
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnCloseClicked (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void OnDrpUsersChanged (object sender, EventArgs e)
		{
			loadUserData ();
		}

		protected void OnBtnDeleteClicked (object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			string userID = userids [drpUsers.Active].ToString ();

			MySqlCommand query = new MySqlCommand ("DELETE FROM `users` WHERE `id`=@ID;", SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@ID", userID);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				SQLConnection.LogAction ("Deleted user " + userID, parent.currentUser);
				MessageBox.Show (this, MessageType.Info, "User deleted successfully");
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not delete user.\nPlease contact your administrator.");
			}

			drpUsers.Active = -1;
			loadUserData ();
			loadUserList ();
		}

		protected void OnBtnUpdateClicked (object sender, EventArgs e)
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

			if (password1.Length != 0 || password2.Length != 0) {
				if (txtPass.Text == txtPassRepeat.Text) {
					MD5 passHash = new MD5 (password1);
					query = new MySqlCommand ("UPDATE `users` SET `username`=@USER, `password`=@PASS, `class`=@RANK, `name`=@NAME WHERE `id`=@ID;", SQLConnection.GetConnection ());
					query.Parameters.AddWithValue ("@PASS", passHash.getShortHash ());
				} else {
					MessageBox.Show (this, MessageType.Info, "Password and and retype password fields do not match");
					return;
				}
			} else {
				query = new MySqlCommand ("UPDATE `users` SET `username`=@USER, `class`=@RANK, `name`=@NAME WHERE `id`=@ID;", SQLConnection.GetConnection ());
			}

			query.Prepare ();
			query.Parameters.AddWithValue ("@USER", userName);
			query.Parameters.AddWithValue ("@RANK", userClass);
			query.Parameters.AddWithValue ("@NAME", userFnameLname);
			query.Parameters.AddWithValue ("@ID", userID);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				SQLConnection.LogAction ("Updated info on user #" + userID, parent.currentUser);
				MessageBox.Show (this, MessageType.Info, "User updated successfully");
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not update user.\nPlease contact your administrator.");
			}

			loadUserData ();
		}

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
			drpUsers.Active = -1;
			loadUserData ();
		}
	}
}

