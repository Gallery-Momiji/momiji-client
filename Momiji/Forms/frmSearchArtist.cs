using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmSearchArtist : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private Operations operation;
		private NodeStore artistStore;
		private frmMenu parent;

		/////////////////////////
		//   Public Attributes //
		/////////////////////////

		public enum Operations
		{
			ArtistCheckin,
			ArtistCheckout,
			GenerateBiddingSheets,
			EditArtist,
			EditMerchandise,
			EditGalleryStore,
			ManageArtistBalance
		}

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private string getSearchID ()
		{
			//If numeric, return it, elsewise just return -1
			int number;
			if (int.TryParse (txtSearch.Text, out number))
				return txtSearch.Text;
			else
				return "-1";
		}

		private void SearchForArtist ()
		{
			txtSearch.Text = txtSearch.Text.Trim ();
			if (txtSearch.Text.Length == 0) {
				MessageBox.Show (this, MessageType.Error,
					"Nothing entered into the search field");
				return;
			}

			ArtistNode.clearTable (ref lstArtists, ref artistStore);
			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			SQLConnection.LogAction ("Searched for artist", User);
			MySqlCommand query = new MySqlCommand ("SELECT ArtistID, ArtistName, ArtistShowName FROM `artists` WHERE `ArtistID` = @ID OR `ArtistName` LIKE @name OR `ArtistShowName` LIKE @name;",
				SQLConnection.GetConnection ());
			query.Prepare ();
			query.Parameters.AddWithValue ("@name", '%' + txtSearch.Text + '%');
			query.Parameters.AddWithValue ("@ID", getSearchID ());

			SQLResult results = SQLConnection.Query (query);

			if (results.GetNumberOfRows () >= 1) {
				for (int i = 0; i < results.GetNumberOfRows (); i++) {
					artistStore.AddNode (new ArtistNode (results.getCellInt ("ArtistID", i),
						results.getCell ("ArtistName", i),
						results.getCell ("ArtistShowName", i)));
				}
			} else {
				MessageBox.Show (this, MessageType.Info,
					"Could not find any artists");
			}
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmSearchArtist (Operations operation, frmMenu parent) :
			base (Gtk.WindowType.Toplevel)
		{
			this.operation = operation;
			this.parent = parent;
			this.Build ();
			ArtistNode.buildTable (ref lstArtists, ref artistStore);

			//Set Window title
			switch (operation) {
			case Operations.ArtistCheckin:
				this.Title = "Search for Artist Check In";
				break;
			case Operations.ArtistCheckout:
				this.Title = "Search for Artist Check Out";
				break;
			case Operations.GenerateBiddingSheets:
				this.Title = "Search for Generating Bidding Sheets";
				break;
			case Operations.EditArtist:
				this.Title = "Search for Editing an Artist";
				break;
			case Operations.EditMerchandise:
				this.Title = "Search for Editing Merchandise";
				break;
			case Operations.EditGalleryStore:
				this.Title = "Search for Editing GS Merchandise";
				break;
			case Operations.ManageArtistBalance:
				this.Title = "Search for Managing Artist Balance";
				break;
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object sender, EventArgs e)
		{
			parent.CleanupSearchArtist ();
		}

		protected void OnTxtSearchActivated (object sender, EventArgs e)
		{
			SearchForArtist ();
		}

		protected void OnBtnSearchClicked (object sender, EventArgs e)
		{
			SearchForArtist ();
		}

		protected void OnLstArtistsRowActivated (object o, RowActivatedArgs args)
		{
			ArtistNode selectednode = (ArtistNode)lstArtists.NodeSelection.SelectedNode;
			switch (operation) {
			case Operations.ArtistCheckin:
				new frmCheckin (selectednode.ArtistID, parent);
				break;
			case Operations.ArtistCheckout:
				new frmArtistCheckout (selectednode.ArtistID, parent);
				break;
#if DEBUG
			case Operations.GenerateBiddingSheets:
				//TODO//
				throw new System.NotImplementedException ();
				//break;
#endif
			case Operations.EditArtist:
				new frmArtistAdd (selectednode.ArtistID, parent);
				break;
			case Operations.EditMerchandise:
				new frmMerchEditor (selectednode.ArtistID, parent);
				break;
			case Operations.EditGalleryStore:
				new frmGSManager (selectednode.ArtistID, parent);
				break;
#if DEBUG
			case Operations.ManageArtistBalance:
				//TODO//
				throw new System.NotImplementedException ();
				//break;
#endif
			}
		}
	}
}

