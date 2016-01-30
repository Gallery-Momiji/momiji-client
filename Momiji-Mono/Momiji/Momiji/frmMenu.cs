using System;

namespace Momiji
{
	public partial class frmMenu : Gtk.Window
	{
        public frmLogin LoginForm;
		
		public frmMenu (frmLogin parent) : 
				base(Gtk.WindowType.Toplevel)
		{
            this.LoginForm = parent;
			this.Build ();
		}
		
		private void CloseForm() {
			//This restores frmlogin and destroys the menu
			LoginForm.Show();
            LoginForm.GrabFocus();
			this.Destroy();
		}

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			CloseForm();
		}

		protected void OnBtnLogoutClicked (object sender, System.EventArgs e)
		{
			CloseForm();
		}

		protected void OnExitActionActivated (object sender, System.EventArgs e)
		{
			CloseForm();
		}
	}
}

