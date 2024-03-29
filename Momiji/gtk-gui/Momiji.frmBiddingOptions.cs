
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmBiddingOptions
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.CheckButton chkEnableDigBid;
		
		private global::Gtk.Label lblDigBidInfo;
		
		private global::Gtk.CheckButton chkAuctionOver;
		
		private global::Gtk.Label lblAuctionEndInfo;
		
		private global::Gtk.Label lblAuctionCutoff;
		
		private global::Gtk.Entry txtAuctionCutoff;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmBiddingOptions
			this.Name = "Momiji.frmBiddingOptions";
			this.Title = global::Mono.Unix.Catalog.GetString ("Bidding Options");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Container child Momiji.frmBiddingOptions.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(10));
			// Container child vbox1.Gtk.Box+BoxChild
			this.chkEnableDigBid = new global::Gtk.CheckButton ();
			this.chkEnableDigBid.CanFocus = true;
			this.chkEnableDigBid.Name = "chkEnableDigBid";
			this.chkEnableDigBid.Label = global::Mono.Unix.Catalog.GetString ("Enable Digital Bidding");
			this.chkEnableDigBid.DrawIndicator = true;
			this.chkEnableDigBid.UseUnderline = true;
			this.vbox1.Add (this.chkEnableDigBid);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.chkEnableDigBid]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblDigBidInfo = new global::Gtk.Label ();
			this.lblDigBidInfo.Name = "lblDigBidInfo";
			this.lblDigBidInfo.LabelProp = global::Mono.Unix.Catalog.GetString ("<i>Disabling digital bidding will disable automatic price lookup\nand all auction " +
			"sales will need prices to be entered manually.\nDisabling this also disables the " +
			"digital bidding webpages.\nThis should be disabled if paper bidding is used inste" +
			"ad.</i>");
			this.lblDigBidInfo.UseMarkup = true;
			this.vbox1.Add (this.lblDigBidInfo);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblDigBidInfo]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.chkAuctionOver = new global::Gtk.CheckButton ();
			this.chkAuctionOver.CanFocus = true;
			this.chkAuctionOver.Name = "chkAuctionOver";
			this.chkAuctionOver.Label = global::Mono.Unix.Catalog.GetString ("End Auction/Bidding");
			this.chkAuctionOver.DrawIndicator = true;
			this.chkAuctionOver.UseUnderline = true;
			this.vbox1.Add (this.chkAuctionOver);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.chkAuctionOver]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblAuctionEndInfo = new global::Gtk.Label ();
			this.lblAuctionEndInfo.Name = "lblAuctionEndInfo";
			this.lblAuctionEndInfo.LabelProp = global::Mono.Unix.Catalog.GetString ("<i>This will end the auction and prevent digital bids from\nhappening. This also e" +
			"nables after auction sales, such as\nwinning sales, live auction sales, and minim" +
			"um bid sales.</i>");
			this.lblAuctionEndInfo.UseMarkup = true;
			this.vbox1.Add (this.lblAuctionEndInfo);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblAuctionEndInfo]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblAuctionCutoff = new global::Gtk.Label ();
			this.lblAuctionCutoff.Name = "lblAuctionCutoff";
			this.lblAuctionCutoff.Xalign = 0F;
			this.lblAuctionCutoff.LabelProp = global::Mono.Unix.Catalog.GetString ("Auction Cutoff, number of bids to send pieces to live auction:");
			this.vbox1.Add (this.lblAuctionCutoff);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblAuctionCutoff]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.txtAuctionCutoff = new global::Gtk.Entry ();
			this.txtAuctionCutoff.CanFocus = true;
			this.txtAuctionCutoff.Name = "txtAuctionCutoff";
			this.txtAuctionCutoff.IsEditable = true;
			this.txtAuctionCutoff.InvisibleChar = '●';
			this.vbox1.Add (this.txtAuctionCutoff);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.txtAuctionCutoff]));
			w6.Position = 5;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Save");
			global::Gtk.Image w7 = new global::Gtk.Image ();
			w7.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w7;
			this.hbox1.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonSave]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Cancel");
			global::Gtk.Image w9 = new global::Gtk.Image ();
			w9.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w9;
			this.hbox1.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonCancel]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w11.Position = 6;
			w11.Expand = false;
			w11.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 412;
			this.DefaultHeight = 318;
			this.Show ();
			this.chkEnableDigBid.Toggled += new global::System.EventHandler (this.OnChkEnableDigBidToggled);
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
		}
	}
}
