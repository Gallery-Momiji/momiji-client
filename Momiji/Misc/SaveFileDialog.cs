using Gtk;

//This is to clean things up

namespace Momiji
{
	public class SaveFileDialog
	{
		public static string rtf (Window parent, string title, string defautname)
		{
			FileChooserDialog dialog = 
				new FileChooserDialog (title,
					parent,
					FileChooserAction.Save,
					Stock.Cancel, ResponseType.Cancel,
					Stock.Save, ResponseType.Accept);
			FileFilter filter = new FileFilter ();
			filter.Name = "RTF Files (*.rtf)";
			filter.AddMimeType ("text/rtf");
			filter.AddPattern ("*.rtf");
			dialog.AddFilter (filter);
			dialog.CurrentName = defautname;
			string ret;
			if (dialog.Run () == (int)ResponseType.Accept)
				ret = dialog.Filename;
			else
				ret = "";
			dialog.Destroy ();
			return ret;
		}
	}
}

