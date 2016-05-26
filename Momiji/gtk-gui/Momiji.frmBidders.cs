
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmBidders
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.VBox vbox4;
		
		private global::Gtk.Label lblSearch;
		
		private global::Gtk.Entry txtSearch;
		
		private global::Gtk.Button btnSearch;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.NodeView lstBidders;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmBidders
			this.Name = "Momiji.frmBidders";
			this.Title = global::Mono.Unix.Catalog.GetString ("frmBidders");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmBidders.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(8));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.lblSearch = new global::Gtk.Label ();
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.LabelProp = global::Mono.Unix.Catalog.GetString ("Enter part of the bidder's name, email, phone number or the bidder number :");
			this.vbox4.Add (this.lblSearch);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.lblSearch]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.txtSearch = new global::Gtk.Entry ();
			this.txtSearch.CanFocus = true;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.IsEditable = true;
			this.txtSearch.InvisibleChar = '●';
			this.vbox4.Add (this.txtSearch);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.txtSearch]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.hbox1.Add (this.vbox4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox4]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnSearch = new global::Gtk.Button ();
			this.btnSearch.CanFocus = true;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.UseUnderline = true;
			this.btnSearch.Label = "Search";
			global::Gtk.Image w4 = new global::Gtk.Image ();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-find", global::Gtk.IconSize.Menu);
			this.btnSearch.Image = w4;
			this.hbox1.Add (this.btnSearch);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnSearch]));
			w5.Position = 1;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.lstBidders = new global::Gtk.NodeView ();
			this.lstBidders.CanFocus = true;
			this.lstBidders.Name = "lstBidders";
			this.lstBidders.EnableSearch = false;
			this.GtkScrolledWindow.Add (this.lstBidders);
			this.vbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w8.Position = 1;
			w8.Padding = ((uint)(6));
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 588;
			this.DefaultHeight = 339;
			this.Show ();
			this.txtSearch.Activated += new global::System.EventHandler (this.OnTxtSearchActivated);
			this.btnSearch.Clicked += new global::System.EventHandler (this.OnBtnSearchClicked);
		}
	}
}
