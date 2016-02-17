using System;
using Gtk;

namespace Momiji
{
	public partial class frmGSSale : Gtk.Window
	{
		/////////////////////////
		//  Private Attributes //
		/////////////////////////

		private frmMenu parent;
		private Gtk.NodeStore merchStore;
		private float total = 0;

		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private void ResetForm()
		{
			this.txtBarcode.Sensitive = true;
			this.btnCancel.Sensitive = true;
			this.btnPay.Sensitive = false;
			this.txtPaid.Sensitive = true;
			this.txtTotal.Text = "";
			this.txtChange.Text = "";
			this.txtPaid.Text = "";
			this.total = 0;
			this.ActiveControl.GrabFocus ();
			//TODO remove all nodes from lstMerch
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public frmGSSale (frmMenu parent) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.parent = parent;
			this.Build ();
			MerchNode.buildTable (ref lstMerch, ref merchStore);

			ResetForm();
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			parent.CleanupGSSale ();
		}

		protected void txtBarcodeActivated (object sender, System.EventArgs e)
		{
			if (txtBarcode.Text.Length < 9)
			{
				txtBarcode.Text = "";
				return;
			}

			txtBarcode.Text = txtBarcode.Text.ToUpper();

			if (txtBarcode.Text.Substring(0, 2) != "PN")
			{
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Info, ButtonsType.Ok,
										"Invalid Gallery Store Piece");
				md.Run ();
				md.Destroy ();
				txtBarcode.Text = "";
				return;
			}

			try
			{
				int ArtistID = Int32.Parse(txtBarcode.Text.Substring(2, 3) );
				int PieceID = Int32.Parse( txtBarcode.Text.Substring(6, 3) );
				SQL SQLConnection = parent.currentSQLConnection;

				MySqlCommand query = new MySqlCommand("SELECT * FROM `gsmerchandise` WHERE `ArtistID` = @AID AND `PieceID` = @PID;", SQLConnection.GetConnection());
				query.Prepare();
				query.Parameters.AddWithValue("@AID", ArtistID);
				query.Parameters.AddWithValue("@PID", PieceID);
				SQLResult results = this.SQLConnection.Query(query);

				if (results.successful())
				{
					merchStore.AddNode (new MerchNode (ArtistID.ToString(),
										PieceID.ToString(),
										results.getCell("PieceTitle", 0),
										"$" + String.Format("{0:0.00}",
											results.getCell("PiecePrice", 0))
										));

					total = total + float.Parse(results.getCell("PiecePrice", 0));
					txtTotal.Text = String.Format("{0:0.00}", total.ToString());

					txtBarcode.Text = "";
					btnPay.Sensitive = true;

				}
				else
				{
					MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
											MessageType.Error, ButtonsType.Ok,
											"Could not find piece in the database");
					md.Run ();
					md.Destroy ();
					txtBarcode.Text = "";
				}
			}
			catch (Exception d)
			{
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal,
										MessageType.Error, ButtonsType.Ok,
										"Error, please show this to your administrator:\n"
										+ d.ToString());
				md.Run ();
				md.Destroy ();
				txtBarcode.Text = "";
				return;
			}
		}
	}
}

