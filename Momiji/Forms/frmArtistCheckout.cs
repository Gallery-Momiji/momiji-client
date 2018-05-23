using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Momiji
{
	public partial class frmArtistCheckout : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private int artistID;
		private float artistOwes;
		private float artistPaid;

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmArtistCheckout(int artistID, frmMenu parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.artistID = artistID;
			this.Build();

			SQL SQLConnection = parent.currentSQLConnection;
			MySqlCommand query = new MySqlCommand("SELECT `ArtistName`,`ArtistcheckOut`,`ArtistDue`,`ArtistPaid` FROM `artists` WHERE `ArtistID` = @ID;",
				SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@ID", this.artistID);

			SQLResult results = SQLConnection.Query(query);
			if (results.successful())
			{
				if (results.getCellInt("ArtistcheckOut", 0) == 1)
				{
					btnMarkCheckout.Sensitive = false;
					chkStep1.Sensitive = false;
					chkStep2.Sensitive = false;
					chkStep3.Sensitive = false;
					chkPaidCash.Sensitive = false;
					MessageBox.Show(this, MessageType.Warning,
						"Artist already marked as Checked Out.");
				}

				lblArtistID.Text = artistID.ToString();
				artistOwes = float.Parse(results.getCell("ArtistDue", 0));
				artistPaid = float.Parse(results.getCell("ArtistPaid", 0));
				lblArtistName.Text = results.getCell("ArtistName", 0);
			}
			else
			{
				MessageBox.Show(this, MessageType.Error,
					"An error occured finding this Artists' details!");
				this.Destroy();
			}
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnGenSaleSumClicked(object sender, EventArgs e)
		{
			Process.Start("http://" + parent.currentSQLConnection.getHost() + "/momiji/checkout.php?id=" + artistID);
		}

		protected void OnBtnMarkCheckoutClicked(object sender, EventArgs e)
		{
			float cash = 0;
			if (chkPaidCash.Active)
			{
				if (!float.TryParse(txtPayout.Text, out cash))
				{
					MessageBox.Show(this, MessageType.Info,
						"Please enter a valid number in the payout box");
					return;
				}

				if (cash <= 0)
				{
					MessageBox.Show(this, MessageType.Info,
						"Please enter a number larger than zero in the payout box");
					return;
				}

				// Payouts are negative
				if (!chkArtistOwes.Active)
				{
					cash *= -1;
				}

			}

			if (chkStep1.Active && chkStep2.Active && chkStep3.Active)
			{
				SQLResult User = parent.currentUser;
				SQL SQLConnection = parent.currentSQLConnection;
				MySqlCommand checkinQuery;
				if (chkPaidCash.Active)
				{
					checkinQuery = new MySqlCommand("UPDATE `artists` SET `ArtistcheckOut`=1 WHERE  `ArtistID`=@ID; INSERT INTO `receipts` ( `userID`, `price`, `paid`, `itemArray`, `priceArray`, `Last4digitsCard`, `timestamp`, `date`) VALUES ( @UID, @PAID, @PAID, @ITEM, @PRICE, 0, CURRENT_TIME, CURRENT_DATE); UPDATE `artists` SET `ArtistPaid`=@ARTISTPAID, `ArtistDue`=0 WHERE `ArtistID` = @ID;",
						SQLConnection.GetConnection());
				}
				else
				{
					checkinQuery = new MySqlCommand("UPDATE `artists` SET `ArtistcheckOut`=1 WHERE  `ArtistID`=@ID; UPDATE `artists` SET `ArtistPaid`=@ARTISTPAID, `ArtistDue`=0 WHERE `ArtistID` = @ID;",
						SQLConnection.GetConnection());
				}
				checkinQuery.Prepare();
				checkinQuery.Parameters.AddWithValue("@ID", this.artistID);
				checkinQuery.Parameters.AddWithValue("@ARTISTPAID", artistOwes + artistPaid);
				if (chkPaidCash.Active)
				{
					checkinQuery.Parameters.AddWithValue("@UID", User.getCell("id", 0));
					checkinQuery.Parameters.AddWithValue("@PAID", cash);
					checkinQuery.Parameters.AddWithValue("@PRICE", cash.ToString() + "#");
					if (cash <= 0)
					{
						checkinQuery.Parameters.AddWithValue("@ITEM", "ARTIST" + this.artistID.ToString().PadLeft(3, '0') + " PAYOUT#");
					}
					else
					{
						checkinQuery.Parameters.AddWithValue("@ITEM", "ARTIST" + this.artistID.ToString().PadLeft(3, '0') + " BALANCE PAID#");
					}
				}
				SQLResult checkinQueryResults = SQLConnection.Query(checkinQuery);

				if (checkinQueryResults.successful())
				{
					MessageBox.Show(this, MessageType.Info, "Artist successfully checked out");
					this.Destroy();
				}
				else
				{
					MessageBox.Show(this, MessageType.Error, "Error Checking Out artist.\nPlease try again, and if this issue persists, please contact your administrator.");
				}
			}
			else
			{
				MessageBox.Show(this, MessageType.Error, "Please make sure you followed all steps and checked each box after completing each action.");
			}
		}

		protected void OnBtnCancelClicked(object sender, EventArgs e)
		{
			this.Destroy();
		}

		protected void OnChkPaidCashToggled(object sender, EventArgs e)
		{
			txtPayout.Sensitive = chkPaidCash.Active;
			chkArtistOwes.Sensitive = chkPaidCash.Active && artistOwes > 0;
			if (!chkPaidCash.Active)
			{
				txtPayout.Text = "";
				chkArtistOwes.Active = false;
			}
		}

		protected void OnChkArtistOwesToggled(object sender, EventArgs e)
		{
			if (chkArtistOwes.Active && artistOwes > 0)
			{
				txtPayout.Text = artistOwes.ToString();
			}
			else
			{
				txtPayout.Text = "";
			}
		}
	}
}

