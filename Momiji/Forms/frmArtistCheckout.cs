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
					chkPaidCheque.Sensitive = false;
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
			Process.Start("http://" + parent.currentSQLConnection.getHost() + "/checkout.php?id=" + artistID);
		}

		protected void OnBtnMarkCheckoutClicked(object sender, EventArgs e)
		{
			float cash = 0;
			if (!float.TryParse(txtPayout.Text, out cash))
			{
				MessageBox.Show(this, MessageType.Info,
					"Please enter a valid number in the payout box");
				return;
			}

			if (cash < 0)
			{
				MessageBox.Show(this, MessageType.Info,
					"Please enter a non-negative number in the payout box");
				return;
			}

			if (chkArtistOwes.Active && (cash > 0) == false)
			{
				MessageBox.Show(this, MessageType.Info,
					"Artist owing must be larger than zero. If the artist owes nothing, please uncheck the checkbox.");
				return;
			}

			// Payouts are negative
			if (!chkArtistOwes.Active)
			{
				cash *= -1;
			}

			if (chkStep1.Active && chkStep2.Active && chkStep3.Active)
			{
				string Last4Digits = "0";
				if (chkPaidCheque.Active)
				{
					Last4Digits = "9999";
				}
				SQLResult User = parent.currentUser;
				SQL SQLConnection = parent.currentSQLConnection;
				MySqlCommand checkinQuery;
				checkinQuery = new MySqlCommand("UPDATE `artists` SET `ArtistcheckOut`=1 WHERE `ArtistID`=@ID; INSERT INTO `receipts` ( `userID`, `price`, `paid`, `itemArray`, `priceArray`, `Last4digitsCard`, `timestamp`, `date`) VALUES ( @UID, @PAID, @PAID, @ITEM, @PRICE, @LAST4DIGIT, CURRENT_TIME, CURRENT_DATE); UPDATE `artists` SET `ArtistPaid`=@ARTISTPAID, `ArtistDue`=0 WHERE `ArtistID` = @ID;",
					SQLConnection.GetConnection());
				checkinQuery.Prepare();
				checkinQuery.Parameters.AddWithValue("@ID", this.artistID);
				checkinQuery.Parameters.AddWithValue("@ARTISTPAID", artistOwes + artistPaid);
				checkinQuery.Parameters.AddWithValue("@UID", User.getCell("id", 0));
				checkinQuery.Parameters.AddWithValue("@PAID", cash);
				checkinQuery.Parameters.AddWithValue("@LAST4DIGIT", Last4Digits);
				checkinQuery.Parameters.AddWithValue("@PRICE", cash.ToString() + "#");
				if (cash < 0)
				{
					checkinQuery.Parameters.AddWithValue("@ITEM", "ARTIST" + this.artistID.ToString().PadLeft(3, '0') + " PAYOUT#");
				}
				else
				{
					checkinQuery.Parameters.AddWithValue("@ITEM", "ARTIST" + this.artistID.ToString().PadLeft(3, '0') + " BALANCE PAID#");
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

