using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Momiji
{
	public partial class frmBidders : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private NodeStore bidderStore;
		private frmMenu parent;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private string getSearchID()
		{
			//If numeric, return it, elsewise just return -1
			int number;
			if (int.TryParse(txtSearch.Text, out number))
				return txtSearch.Text;
			else
				return "-1";
		}

		private void SearchForBidder()
		{
			txtSearch.Text = txtSearch.Text.Trim();
			if (txtSearch.Text.Length == 0)
			{
				MessageBox.Show(this, MessageType.Error,
					"Nothing entered into the search field");
				return;
			}

			BidderNode.clearTable(ref lstBidders, ref bidderStore);
			SQL SQLConnection = parent.currentSQLConnection;
			SQLResult User = parent.currentUser;

			SQLConnection.LogAction("Searched for bidders", User);
			MySqlCommand query = new MySqlCommand("SELECT * FROM `bidders` WHERE `bidderno` = @ID OR `name` LIKE @term OR REPLACE(`phoneno`, '-', '') LIKE @term OR `eaddress` LIKE @term;",
				SQLConnection.GetConnection());
			query.Prepare();
			query.Parameters.AddWithValue("@term", '%' + txtSearch.Text.Replace('-', '%') + '%');
			query.Parameters.AddWithValue("@ID", getSearchID());

			SQLResult results = SQLConnection.Query(query);

			if (results.GetNumberOfRows() >= 1)
			{
				for (int i = 0; i < results.GetNumberOfRows(); i++)
				{
					bidderStore.AddNode(new BidderNode(results.getCellInt("bidderno", i),
						results.getCell("name", i),
						results.getCell("phoneno", i),
						results.getCell("eaddress", i),
						"$" + results.getCell("due", i),
						results.getCell("maddress", i)));
				}
			}
			else
			{
				MessageBox.Show(this, MessageType.Info,
					"Could not find any bidders");
			}
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmBidders(frmMenu parent) :
			base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build();
			BidderNode.buildTable(ref lstBidders, ref bidderStore);
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnSearchClicked(object sender, EventArgs e)
		{
			SearchForBidder();
		}

		protected void OnTxtSearchActivated(object sender, EventArgs e)
		{
			SearchForBidder();
		}
	}
}
