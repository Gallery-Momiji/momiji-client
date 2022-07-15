using System;
using System.IO;
using Gtk;

namespace Momiji
{
	public class Biddersheet
	{
		private string filename;
		private string sheetbody;

		public Biddersheet (string filename, bool digital)
		{
			this.filename = filename;
			//write the header info
			string output = "";
			if(digital) {
				using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly ().GetManifestResourceStream ("Momiji.Resources.bid_sheetheader_digital"))
				using (StreamReader reader = new StreamReader (stream)) {
					while (!reader.EndOfStream) {
						output = reader.ReadToEnd ();
					}
				}
			} else {
				using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly ().GetManifestResourceStream ("Momiji.Resources.bid_sheetheader"))
				using (StreamReader reader = new StreamReader (stream)) {
					while (!reader.EndOfStream) {
						output = reader.ReadToEnd ();
					}
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
			if(digital) {
				using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly ().GetManifestResourceStream ("Momiji.Resources.bid_sheetbody_digital"))
				using (StreamReader reader = new StreamReader (stream)) {
					while (!reader.EndOfStream) {
						sheetbody = reader.ReadToEnd ();
					}
				}
			} else {
				using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly ().GetManifestResourceStream ("Momiji.Resources.bid_sheetbody"))
				using (StreamReader reader = new StreamReader (stream)) {
					while (!reader.EndOfStream) {
						sheetbody = reader.ReadToEnd ();
					}
				}
			}
		}

		public void AddSheet (string aid, string mid, string artist, string title,
		                      string med, string mbid, string qs, bool aamb)
		{
			AddSheet(String.Format("AN" + aid.PadLeft(3, '0') + "-" +
									mid.PadLeft(3, '0')), artist, title, med,
									mbid, qs, aamb);
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
			output = output.Replace ("PIECE_MINBID", (float.Parse(mbid) > 0) ? "$" + mbid : "N/A");
			output = output.Replace ("PIECE_QS", (float.Parse(qs) > 0) ? "$" + qs : "N/A");
			output = output.Replace ("PIECE_MS", aamb ? "YES" : "NO");
			if ((float.Parse(mbid) > 0) || (float.Parse(qs) > 0))
			{
				output = output.Replace("NOT FOR SALE", "");
			}

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

