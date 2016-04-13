using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmLogin : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private SQL SQLConnection;
		private string db_pass, db_user, db_name, db_host, db_port;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void TestConnect ()
		{
			lblConnStatus.Text = "Connecting...";

			SQLConnection = new SQL (db_user, db_pass, db_host, db_name, db_port);

			if (SQLConnection.GetState () != 1) {
				lblConnStatus.ModifyFg (StateType.Normal, new Gdk.Color (255, 0, 0));
				lblConnStatus.Text = SQLConnection.GetErrorMessage ();
				btnRetry.Sensitive = true;
				btnLogin.Sensitive = false;
			} else {
				lblConnStatus.ModifyFg (StateType.Normal, new Gdk.Color (0, 255, 0));
				lblConnStatus.Text = "OK";
				btnRetry.Sensitive = false;
				btnLogin.Sensitive = true;
			}

			SQLConnection.Close ();
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmLogin () :
				base(Gtk.WindowType.Toplevel)
		{
			IniParser config;
			try {
				config = new IniParser ("config.ini");
			} catch (Exception ex) {
				MessageBox.Show (this, MessageType.Error,
										ex.Message);

				this.Destroy ();
				return;
			}
			db_pass = config.GetSetting ("ROOT", "db_pass");
			db_user = config.GetSetting ("ROOT", "db_user");
			db_name = config.GetSetting ("ROOT", "db_name");
			db_host = config.GetSetting ("ROOT", "db_host");
			db_port = config.GetSetting ("ROOT", "db_port");

			this.Build ();

			TestConnect ();

			//Set focus on username box
			txtUsername.GrabFocus ();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			Application.Quit ();
		}

		protected void OnBtnLoginClicked (object sender, EventArgs e)
		{
			string pass = txtPassword.Text;
			string user = txtUsername.Text.ToLower();

			//Check for 0 length entry
			if (user.Length == 0) {
				MessageBox.Show (this, MessageType.Error,
											"Please enter a username");

				txtUsername.GrabFocus ();
				return;
			} else if (pass.Length == 0) {
				MessageBox.Show (this, MessageType.Error,
											"Please enter a password");

				txtPassword.GrabFocus ();
				return;
			}

			//MD5Sum for passwords
			MD5 passhash = new MD5 (pass);
			pass = passhash.getShortHash ();

			//Use a fresh connection for login

			SQLConnection = new SQL (db_user, db_pass, db_host, db_name, db_port);

			if (SQLConnection.GetState () != 1) {
				//if a new connection fails
				lblConnStatus.ModifyFg (StateType.Normal, new Gdk.Color (255, 0, 0));
				lblConnStatus.Text = SQLConnection.GetErrorMessage ();
				btnRetry.Sensitive = true;
				btnLogin.Sensitive = false;
				return;
			}

			MySqlCommand query = new MySqlCommand ("SELECT * FROM `users` WHERE `username` = @username AND `password` = @password;", SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@username", user);
			query.Parameters.AddWithValue ("@password", pass);

			SQLResult results = this.SQLConnection.Query (query);
			if (results.GetNumberOfRows () == 1) {
				//Clear the form
				txtPassword.Text = "";
				txtUsername.Text = "";
				txtUsername.GrabFocus ();
				//Log in user
				SQLConnection.LogAction ("Logged In!", results);
				frmMenu menuInstance = new frmMenu (SQLConnection, results, this);
				this.Hide ();
				menuInstance.Show ();
			} else {
				MessageBox.Show (this, MessageType.Error,
										"Incorrect password or username. Please try again.");

				txtPassword.Text = "";
				txtPassword.GrabFocus ();
			}
		}

		protected void OnTxtPasswordActivated (object sender, EventArgs e)
		{
			if (btnLogin.Sensitive)
				OnBtnLoginClicked (sender, e);
		}

		protected void OnTxtUsernameActivated (object sender, EventArgs e)
		{
			if (btnLogin.Sensitive)
				OnBtnLoginClicked (sender, e);
		}

		protected void OnBtnRetryClicked (object sender, EventArgs e)
		{
			TestConnect ();
		}
	}
}


