using System;
using System.IO;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public class Barcodes
	{
		private string filename;
		private string sheetbody;

		public Barcodes (string filename)
		{
			this.filename = filename;
			//write the header info
			string output = "";
			using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly ().GetManifestResourceStream ("Momiji.Resources.barcodeheader"))
			using (StreamReader reader = new StreamReader (stream)) {
				while (!reader.EndOfStream) {
					output = reader.ReadToEnd ();
				}
			}

			try {
				File.WriteAllText (filename, output);
			} catch (Exception d) {
				MessageBox.Show (null, MessageType.Error,
					"Unable to save file:\n" + d.Message.ToString ());
			}

			//Cache the body info
			sheetbody = "";
			using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly ().GetManifestResourceStream ("Momiji.Resources.barcodebody"))
			using (StreamReader reader = new StreamReader (stream)) {
				while (!reader.EndOfStream) {
					sheetbody = reader.ReadToEnd ();
				}
			}
		}

		public void AddCode (string aid, string pid1, float price1,
		                      string pid2, float price2)
		{
			string output = sheetbody;
			//write the body info
			output = output.Replace ("PIECE_ID1", String.Format ("AN" + aid.PadLeft (3, '0') + "-" + pid1.PadLeft (3, '0')));
			output = output.Replace ("PIECE_ID2", String.Format ("AN" + aid.PadLeft (3, '0') + "-" + pid2.PadLeft (3, '0')));
			output = output.Replace ("PRICE1", String.Format ("${0:0.00}", price1));
			output = output.Replace ("PRICE2", String.Format ("${0:0.00}", price2));

			try {
				File.AppendAllText (filename, output);
			} catch (Exception d) {
				MessageBox.Show (null, MessageType.Error,
					"Unable to save file:\n" + d.Message.ToString ());
			}
		}

		public void AddCode (string pid, float price)
		{
			string output = sheetbody;
			//write the body info
			output = output.Replace ("PIECE_ID1", pid);
			output = output.Replace ("PIECE_ID2", "");
			output = output.Replace ("PRICE1", String.Format ("${0:0.00}", price));
			output = output.Replace ("PRICE2", "");

			try {
				File.AppendAllText (filename, output);
			} catch (Exception d) {
				MessageBox.Show (null, MessageType.Error,
					"Unable to save file:\n" + d.Message.ToString ());
			}
		}

		public void Finish ()
		{
			//write the ending bracket
			try {
				File.AppendAllText (filename, "}");
			} catch (Exception d) {
				MessageBox.Show (null, MessageType.Error,
					"Unable to save file:\n" + d.Message.ToString ());
			}
		}
	}
}

