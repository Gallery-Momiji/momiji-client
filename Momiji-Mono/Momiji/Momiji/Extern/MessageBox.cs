using System;
using Gtk;

//This is to clean things up

public class MessageBox
{
	public static void Show(object win, MessageType type, string msg)
	{
		MessageDialog diag = new MessageDialog (win, DialogFlags.Modal, type, ButtonsType.Ok, Msg);
		diag.Run ();
		diag.Destroy();
	}
}