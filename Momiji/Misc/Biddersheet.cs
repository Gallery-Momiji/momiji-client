using System;
using System.IO;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public class Biddersheet
	{
		private string filename;
		private string sheetbody;

		public Biddersheet (string filename)
		{
			this.filename = filename;
			//write the header info
			string output = "";
			using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly ().GetManifestResourceStream ("Momiji.Resources.bid_sheetheader"))
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
			using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly ().GetManifestResourceStream ("Momiji.Resources.bid_sheetbody"))
			using (StreamReader reader = new StreamReader (stream)) {
				while (!reader.EndOfStream) {
					sheetbody = reader.ReadToEnd ();
				}
			}
		}

		public void AddSheet (string aid, string mid, string artist, string title,
		                      string med, string mbid, string qs, bool aamb)
		{
			string output = sheetbody;
			//write the body info
			output = output.Replace ("PIECE_ID", String.Format ("AN" + aid.PadLeft (3, '0') + "-" + mid.PadLeft (3, '0')));
			output = output.Replace ("ARTIST_ID", artist);
			output = output.Replace ("PIECE_TITLE", title);
			output = output.Replace ("PIECE_MEDIUM", med);
			output = output.Replace ("PIECE_MINBID", "$" + mbid);
			output = output.Replace ("PIECE_QS", (qs == "0" || qs == "") ? "N/A" : "$" + qs);
			output = output.Replace ("PIECE_MS", aamb ? "YES" : "NO");

			try {
				File.AppendAllText (filename, output);
			} catch (Exception d) {
				MessageBox.Show (null, MessageType.Error,
					"Unable to save file:\n" + d.Message.ToString ());
			}
		}

		public void AddSheet (string pid, string artist, string title,
		                      string med, string mbid, string qs, bool aamb)
		{
			string output = sheetbody;
			//write the body info
			output = output.Replace ("PIECE_ID", pid);
			output = output.Replace ("ARTIST_ID", artist);
			output = output.Replace ("PIECE_TITLE", title);
			output = output.Replace ("PIECE_MEDIUM", med);
			output = output.Replace ("PIECE_MINBID", "$" + mbid);
			output = output.Replace ("PIECE_QS", (qs == "0" || qs == "") ? "N/A" : "$" + qs);
			output = output.Replace ("PIECE_MS", aamb ? "YES" : "NO");

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

