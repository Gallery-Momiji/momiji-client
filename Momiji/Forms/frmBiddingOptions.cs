using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmBiddingOptions : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;

		/////////////////////////
		//     Contructors     //
		/////////////////////////

		//This pulls fresh data
		public frmBiddingOptions(frmMenu parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build();
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("SELECT `EnableDigitalBid`,`AuctionEnd`,`AuctionCutoff` FROM `options`;",
									 SQLConnection.GetConnection());
			query.Prepare();

			SQLResult results = SQLConnection.Query(query);

			if (results.successful())
			{
				chkEnableDigBid.Active = (results.getCell("EnableDigitalBid", 0) == "1");
				chkAuctionOver.Active = (results.getCell("AuctionEnd", 0) == "1");
				chkAuctionOver.Sensitive = chkEnableDigBid.Active;
				txtAuctionCutoff.Text = results.getCell("AuctionCutoff", 0);
			}
			else
			{
				MessageBox.Show(this, MessageType.Error,
					"Failed to load form.\nPlease log out and try again.");
				this.Destroy();
			}
		}

		protected void OnButtonSaveClicked(object sender, EventArgs e)
		{
			int AuctionCutoff;
			if (!int.TryParse(txtAuctionCutoff.Text, out AuctionCutoff) ||
				AuctionCutoff < 1)
			{
				MessageBox.Show(this, MessageType.Error,
					"Invalid Auction Cutoff. This must be a whole number greater than zero");
				return;
			}
			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("UPDATE `options` SET `EnableDigitalBid`=@EDB, `AuctionEnd`=@AEND,`AuctionCutoff`=@ACUTOFF;",
									 SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@EDB", chkEnableDigBid.Active ? 1 : 0);
			query.Parameters.AddWithValue("@AEND", chkAuctionOver.Active ? 1 : 0);
			query.Parameters.AddWithValue("@ACUTOFF", AuctionCutoff);

			SQLResult results = SQLConnection.Query(query);

			if (results.successful())
			{
				MessageBox.Show(this, MessageType.Info,
					"Updated successfully.");
				OnButtonCancelClicked(sender, e);
			}
			else
			{
				MessageBox.Show(this, MessageType.Error,
					"Could not update options.\nPlease log out and try again.");
			}
		}

		protected void OnButtonCancelClicked(object sender, EventArgs e)
		{
			this.Destroy();
		}

		protected void OnChkEnableDigBidToggled(object sender, EventArgs e)
		{
			chkAuctionOver.Sensitive = chkEnableDigBid.Active;
		}
	}
}

