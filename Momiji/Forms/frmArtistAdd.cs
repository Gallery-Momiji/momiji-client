using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmArtistAdd : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private bool newartist;

		/////////////////////////
		//     Contructors     //
		/////////////////////////

		public frmArtistAdd (frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();

			//No ID, thus make a new artist
			newartist = true;
			btnDelete.Sensitive = false;
			btnGenerate.Sensitive = true;
			txtArtistID.Sensitive = true;
		}

		public frmArtistAdd (int artistID, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();

			//Artist ID specified, thus edit an existing artist
			newartist = false;
			btnDelete.Sensitive = true;
			btnGenerate.Sensitive = false;
			txtArtistID.Sensitive = false;
			//Load existing data
			SQL SQLConnection = parent.currentSQLConnection;

			MySqlCommand query = new MySqlCommand ("SELECT `ArtistName`,`ArtistEmail`,`ArtistAddress`,`ArtistUrl`,`ArtistAgentName`,`ArtistAgentPhone`,`ArtistPhone`,`ArtistAgentAddress`,`ArtistAgentEmail`,`ArtistShowName` FROM `artists` WHERE `ArtistID` = @AID;",
				SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@AID", artistID);
			SQLResult results = SQLConnection.Query (query);

			if (results.GetNumberOfRows () == 1) {
				txtArtistID.Text = artistID.ToString ();
				txtArtistName.Text = results.getCell ("ArtistName", 0);
				txtArtistPhone.Text = results.getCell ("ArtistPhone", 0);
				txtArtistWebsite.Text = results.getCell ("ArtistUrl", 0);
				txtEmail.Text = results.getCell ("ArtistEmail", 0);
				txtArtistAddress.Buffer.Text = results.getCell ("ArtistAddress", 0);
				txtAgentAddress.Buffer.Text = results.getCell ("ArtistAgentAddress", 0);
				txtAgentEmail.Text = results.getCell ("ArtistAgentEmail", 0);
				txtAgentName.Text = results.getCell ("ArtistAgentName", 0);
				txtAgentPhone.Text = results.getCell ("ArtistAgentPhone", 0);
				txtArtistShowName.Text = results.getCell ("ArtistShowName", 0);
			} else {
				MessageBox.Show (this, MessageType.Error,
					"Unable to load artist information.\nPlease try again, and if this issue persists, please contact your administrator.");
				this.Destroy ();
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnGenerateClicked (object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand ("SELECT MAX(`ArtistID`)+1 as `next_id` FROM `artists` limit 0,1;",
				SQLConnection.GetConnection ());
			query.Prepare ();

			SQLResult results = SQLConnection.Query (query);

			txtArtistID.Text = results.getCell ("next_id", 0);
		}

		protected void OnBtnCancelClicked (object sender, EventArgs e)
		{
			this.Destroy ();
		}

		protected void OnBtnUpdateClicked (object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult results;
			MySqlCommand query;

			if (newartist) {
				query = new MySqlCommand ("SELECT `ArtistID` FROM `artists` WHERE `ArtistID` = @AID;",
					SQLConnection.GetConnection ());
				results = SQLConnection.Query (query);
				query.Parameters.AddWithValue ("@ID", txtArtistID.Text);
				if (results.GetNumberOfRows () > 0) {
					MessageBox.Show (this, MessageType.Error,
						"This artistID already in use.\nPlease select another one or generate a new ID.");
					return;
				}

				query = new MySqlCommand ("INSERT INTO `artists` (`ArtistID`, `ArtistName`, `ArtistEmail`, `ArtistAddress`, `ArtistUrl`, `ArtistAgentName`, `ArtistAgentPhone`, `ArtistPhone`, `ArtistAgentAddress`, `ArtistAgentEmail`, `ArtistShowName`) VALUES (@ID, @NAME, @EMAIL, @ADDRESS, @URL, @AGENTNAME, @AGENTPHONE, @PHONE, @AGENTADDRESS, @AGENTEMAIL, @ARTISTSHOWNAME);",
					SQLConnection.GetConnection ());
			} else {
				query = new MySqlCommand ("UPDATE `artists` SET `ArtistID`=@ID, `ArtistName`=@NAME, `ArtistEmail`=@EMAIL, `ArtistAddress`=@ADDRESS, `ArtistUrl`=@URL, `ArtistAgentName`=@AGENTNAME, `ArtistAgentPhone`=@AGENTPHONE, `ArtistPhone`=@PHONE, `ArtistAgentAddress`=@AGENTADDRESS, `ArtistAgentEmail`=@AGENTEMAIL, `ArtistShowName`=@ARTISTSHOWNAME;",
					SQLConnection.GetConnection ());
			}
			query.Prepare ();
			query.Parameters.AddWithValue ("@ID", txtArtistID.Text);
			query.Parameters.AddWithValue ("@NAME", txtArtistName.Text);
			query.Parameters.AddWithValue ("@EMAIL", txtEmail.Text);
			query.Parameters.AddWithValue ("@ADDRESS", txtArtistAddress.Buffer.Text);
			query.Parameters.AddWithValue ("@URL", txtArtistWebsite.Text);
			query.Parameters.AddWithValue ("@AGENTNAME", txtAgentName.Text);
			query.Parameters.AddWithValue ("@AGENTPHONE", txtAgentPhone.Text);
			query.Parameters.AddWithValue ("@PHONE", txtArtistPhone.Text);
			query.Parameters.AddWithValue ("@AGENTADDRESS", txtAgentAddress.Buffer.Text);
			query.Parameters.AddWithValue ("@AGENTEMAIL", txtAgentEmail.Text);
			query.Parameters.AddWithValue ("@ARTISTSHOWNAME", txtArtistShowName.Text);

			results = SQLConnection.Query (query);

			if (results.successful ()) {
				if (newartist)
					SQLConnection.LogAction ("Added artist: " + txtArtistID.Text, parent.currentUser);
				else
					SQLConnection.LogAction ("Updated artist: " + txtArtistID.Text, parent.currentUser);

				MessageBox.Show (this, MessageType.Info, "Update successful!");
				this.Destroy ();
			} else {
				MessageBox.Show (this, MessageType.Error,
					"Could not update Artist information.\nPlease try again or contact your administrator.");
			}
		}

		protected void OnBtnDeleteClicked (object sender, EventArgs e)
		{
			SQL SQLConnection = parent.currentSQLConnection;

			MySqlCommand query = new MySqlCommand ("DELETE FROM `artists` WHERE `id`=@ID;",
				SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@ID", txtArtistID.Text);
			SQLResult results = SQLConnection.Query (query);

			if (results.successful ()) {
				SQLConnection.LogAction ("Deleted artist: " + txtArtistID.Text, parent.currentUser);
				MessageBox.Show (this, MessageType.Info, "Artist deleted successfully");
				this.Destroy ();
			} else {
				MessageBox.Show (this, MessageType.Error, "Could not delete user.\nPlease contact your administrator.");
			}
		}
	}
}

