using System;
using Gtk;

namespace Momiji
{
	public partial class frmLogin : Gtk.Window
	{
		public frmLogin () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			Application.Quit ();
		}

		protected void OnBtnLoginClicked (object sender, System.EventArgs e)
		{
			string pass = txtPassword.Text;
			string user = txtUsername.Text;

			if (pass.Length == 0 || user.Length == 0)
			{
				MessageDialog md = new MessageDialog(this,DialogFlags.Modal,MessageType.Error,ButtonsType.Ok,
									"Please enter a username and password");
				md.Run ();
				md.Destroy ();
				return;
			}
			
			MD5 passhash = new MD5(pass);
			
			txtPassword.Text = "";
			txtUsername.Text = "";
			txtUsername.GrabFocus();
			//TODO Log in user
			frmMenu menuInstance = new frmMenu(this);
			this.Hide();
			menuInstance.Show();
		}

		protected void OnTxtPasswordActivated (object sender, System.EventArgs e)
		{
			OnBtnLoginClicked(sender,e);
		}

		protected void OnTxtUsernameActivated (object sender, System.EventArgs e)
		{
			OnBtnLoginClicked(sender,e);
		}
	}
}

	
