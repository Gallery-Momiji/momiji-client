
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmUserAdd
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.Label lblUsername;
		private global::Gtk.Entry txtUsername;
		private global::Gtk.Label lblFirstAndLast;
		private global::Gtk.Entry txtFirstAndLast;
		private global::Gtk.Label lblPassword;
		private global::Gtk.Entry txtPassword;
		private global::Gtk.Label lblPasswordRetype;
		private global::Gtk.Entry txtPasswordRetype;
		private global::Gtk.Label lblRank;
		private global::Gtk.ComboBox drpRank;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Button button1;
		private global::Gtk.Button btnCancel;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmUserAdd
			this.Name = "Momiji.frmUserAdd";
			this.Title = global::Mono.Unix.Catalog.GetString ("frmUserAdd");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Container child Momiji.frmUserAdd.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(16));
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblUsername = new global::Gtk.Label ();
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.LabelProp = global::Mono.Unix.Catalog.GetString ("Username:");
			this.vbox1.Add (this.lblUsername);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblUsername]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.txtUsername = new global::Gtk.Entry ();
			this.txtUsername.CanFocus = true;
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.IsEditable = true;
			this.txtUsername.InvisibleChar = '●';
			this.vbox1.Add (this.txtUsername);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.txtUsername]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblFirstAndLast = new global::Gtk.Label ();
			this.lblFirstAndLast.Name = "lblFirstAndLast";
			this.lblFirstAndLast.LabelProp = global::Mono.Unix.Catalog.GetString ("First and Last name:");
			this.vbox1.Add (this.lblFirstAndLast);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblFirstAndLast]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.txtFirstAndLast = new global::Gtk.Entry ();
			this.txtFirstAndLast.CanFocus = true;
			this.txtFirstAndLast.Name = "txtFirstAndLast";
			this.txtFirstAndLast.IsEditable = true;
			this.txtFirstAndLast.InvisibleChar = '●';
			this.vbox1.Add (this.txtFirstAndLast);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.txtFirstAndLast]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblPassword = new global::Gtk.Label ();
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.LabelProp = global::Mono.Unix.Catalog.GetString ("Password");
			this.vbox1.Add (this.lblPassword);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblPassword]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.txtPassword = new global::Gtk.Entry ();
			this.txtPassword.CanFocus = true;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.IsEditable = true;
			this.txtPassword.Visibility = false;
			this.txtPassword.InvisibleChar = '●';
			this.vbox1.Add (this.txtPassword);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.txtPassword]));
			w6.Position = 5;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblPasswordRetype = new global::Gtk.Label ();
			this.lblPasswordRetype.Name = "lblPasswordRetype";
			this.lblPasswordRetype.LabelProp = global::Mono.Unix.Catalog.GetString ("Retype Password:");
			this.vbox1.Add (this.lblPasswordRetype);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblPasswordRetype]));
			w7.Position = 6;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.txtPasswordRetype = new global::Gtk.Entry ();
			this.txtPasswordRetype.CanFocus = true;
			this.txtPasswordRetype.Name = "txtPasswordRetype";
			this.txtPasswordRetype.IsEditable = true;
			this.txtPasswordRetype.Visibility = false;
			this.txtPasswordRetype.InvisibleChar = '●';
			this.vbox1.Add (this.txtPasswordRetype);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.txtPasswordRetype]));
			w8.Position = 7;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblRank = new global::Gtk.Label ();
			this.lblRank.Name = "lblRank";
			this.lblRank.LabelProp = global::Mono.Unix.Catalog.GetString ("Rank:");
			this.vbox1.Add (this.lblRank);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblRank]));
			w9.Position = 8;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.drpRank = global::Gtk.ComboBox.NewText ();
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("0 - Login"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("1 - Gallery Store Sales"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("2 - Quick Sales"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("3 - Auction Sales"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("4 - Re-Print Receipts"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("5 - Check-in Artists"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("6 - Bidding sheets, Check-out, Bidders"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("7 - Manage artist stock"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("8 - View Activity logs"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("9 - View Monetary activity logs"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("10 - Manage Treasury/refunds"));
			this.drpRank.AppendText (global::Mono.Unix.Catalog.GetString ("11 - Administrator"));
			this.drpRank.Name = "drpRank";
			this.vbox1.Add (this.drpRank);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.drpRank]));
			w10.Position = 9;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(6));
			// Container child hbox1.Gtk.Box+BoxChild
			this.button1 = new global::Gtk.Button ();
			this.button1.CanFocus = true;
			this.button1.Name = "button1";
			this.button1.UseUnderline = true;
			// Container child button1.Gtk.Container+ContainerChild
			global::Gtk.Alignment w11 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w12 = new global::Gtk.HBox ();
			w12.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w13 = new global::Gtk.Image ();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			w12.Add (w13);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w15 = new global::Gtk.Label ();
			w15.LabelProp = global::Mono.Unix.Catalog.GetString ("Create");
			w15.UseUnderline = true;
			w12.Add (w15);
			w11.Add (w12);
			this.button1.Add (w11);
			this.hbox1.Add (this.button1);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button1]));
			w19.Position = 0;
			w19.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			// Container child btnCancel.Gtk.Container+ContainerChild
			global::Gtk.Alignment w20 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w21 = new global::Gtk.HBox ();
			w21.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w22 = new global::Gtk.Image ();
			w22.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			w21.Add (w22);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w24 = new global::Gtk.Label ();
			w24.LabelProp = global::Mono.Unix.Catalog.GetString ("Cancel");
			w24.UseUnderline = true;
			w21.Add (w24);
			w20.Add (w21);
			this.btnCancel.Add (w20);
			this.hbox1.Add (this.btnCancel);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnCancel]));
			w28.Position = 1;
			w28.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w29.Position = 10;
			w29.Expand = false;
			w29.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 320;
			this.DefaultHeight = 407;
			this.Show ();
			this.txtUsername.Activated += new global::System.EventHandler (this.OnTxtUsernameActivated);
			this.txtFirstAndLast.Activated += new global::System.EventHandler (this.OnTxtFirstAndLastActivated);
			this.txtPassword.Activated += new global::System.EventHandler (this.OnTxtPasswordActivated);
			this.txtPasswordRetype.Activated += new global::System.EventHandler (this.OnTxtPasswordRetypeActivated);
			this.button1.Clicked += new global::System.EventHandler (this.OnButton1Clicked);
			this.btnCancel.Clicked += new global::System.EventHandler (this.OnBtnCancelClicked);
		}
	}
}
