using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmUserAdd : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmUserAdd (frmMenu parent) :
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			drpRank.Active = -1;
			txtUsername.GrabFocus ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnButton1Clicked (object sender, System.EventArgs e)
		{
			string userName, password1, password2, userFnameLname, userClass;
			userName = txtUsername.Text.ToLower ();
			password1 = txtPassword.Text;
			password2 = txtPasswordRetype.Text;
			userFnameLname = txtFirstAndLast.Text;
			SQL SQLConnection = parent.currentSQLConnection;

			if (userName.Length == 0 || password1.Length == 0 ||
				password2.Length == 0 || userFnameLname.Length == 0 ||
				drpRank.Active < 0) {
				MessageBox.Show (this, MessageType.Info, "All fields are required");
				return;
			}

			userClass = drpRank.Active.ToString ();

			if (password1 != password2) {
				MessageBox.Show (this, MessageType.Info, "Password and and retype password fields do not match");
				return;
			}

			// Make sure user doesn't exist already

			MySqlCommand query = new MySqlCommand ("SELECT `id` FROM `users` WHERE `username` = @username;", SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@username", userName);

			SQLResult results = SQLConnection.Query (query);
			if (results.GetNumberOfRows () > 0) {
				MessageBox.Show (this, MessageType.Error, "This username already exists");
				return;
			}

			// Generate passhash then add user

			MD5 passHash = new MD5 (password1);

			query = new MySqlCommand ("INSERT INTO `users` (`username`, `password`, `class`, `name`) VALUES (@username, @password, @class, @name);", SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@username", userName);
			query.Parameters.AddWithValue ("@password", passHash.getShortHash ());
			query.Parameters.AddWithValue ("@class", userClass);
			query.Parameters.AddWithValue ("@name", userFnameLname);
			results = SQLConnection.Query (query);

			if (results.successful ()) {
				MessageBox.Show (this, MessageType.Info, "User added successfully");
				txtFirstAndLast.Text = "";
				txtPassword.Text = "";
				txtPasswordRetype.Text = "";
				txtUsername.Text = "";

				drpRank.Active = -1;
			}
		}

		protected void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			this.Destroy ();
		}

		protected void OnTxtUsernameActivated (object sender, System.EventArgs e)
		{
			txtFirstAndLast.GrabFocus ();
		}

		protected void OnTxtFirstAndLastActivated (object sender, System.EventArgs e)
		{
			txtPassword.GrabFocus ();
		}

		protected void OnTxtPasswordActivated (object sender, System.EventArgs e)
		{
			txtPasswordRetype.GrabFocus ();
		}

		protected void OnTxtPasswordRetypeActivated (object sender, System.EventArgs e)
		{
			drpRank.GrabFocus ();
		}
	}
}

