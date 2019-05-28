using Gtk;

namespace Momiji
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			frmLogin win = new frmLogin ();
			win.Show ();
			Application.Run ();
		}
	}
}
