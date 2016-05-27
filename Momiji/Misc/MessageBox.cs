using System;
using Gtk;

//This is to clean things up

public class MessageBox
{
	public static void Show (Window win, MessageType type, string msg)
	{
		MessageDialog diag = new MessageDialog (win, DialogFlags.Modal, type, ButtonsType.Ok, msg);
		diag.Run ();
		diag.Destroy ();
		win.Present ();
	}

	public static bool Ask (Window win, string msg)
	{
		MessageDialog diag = new MessageDialog (win, DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo, msg);
		ResponseType result = (ResponseType)diag.Run ();
		diag.Destroy ();
		win.Present ();
		return (result == ResponseType.Yes);
	}
}