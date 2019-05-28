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

	public static bool Entry(Window win, string msg, ref string val)
	{
		Dialog diag = new Dialog(msg, win, DialogFlags.Modal, Gtk.Stock.Ok, ResponseType.Ok, Gtk.Stock.Cancel, ResponseType.Cancel);

		HBox hbox = new HBox(false, 8);
		hbox.BorderWidth = 8;
		diag.VBox.PackStart(hbox, false, false, 0);

		Image stock = new Image(Stock.DialogQuestion, IconSize.Dialog);
		hbox.PackStart(stock, false, false, 0);

		Table table = new Table(2, 2, false) {RowSpacing = 4, ColumnSpacing = 4};
		hbox.PackStart(table, true, true, 0);

		Label label = new Label("Entry: ");
		table.Attach(label, 0, 1, 0, 1);
		Entry localEntry1 = new Entry {Text = val};
		table.Attach(localEntry1, 1, 2, 0, 1);
		label.MnemonicWidget = localEntry1;

		hbox.ShowAll();

		ResponseType result = (ResponseType)diag.Run();

		if (result == ResponseType.Ok)
		{
			val = localEntry1.Text;
		}
		diag.Destroy();
		return (result == ResponseType.Ok);
	}
}