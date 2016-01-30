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
			txtPassword.Text = "";
            txtUsername.Text = "";
            txtUsername.GrabFocus();
            //Log in user
            frmMenu menuInstance = new frmMenu(this);
            this.Hide();
            menuInstance.Show();
		}
	}
}

