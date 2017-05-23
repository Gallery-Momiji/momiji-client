
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmCheckin
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.Notebook tabControlMerch;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		
		private global::Gtk.NodeView lstMerch;
		
		private global::Gtk.Label lblControlSheet;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.NodeView lstGSMerch;
		
		private global::Gtk.Label lblGalleryStore;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button btnCancel;
		
		private global::Gtk.Button btnEditArtist;
		
		private global::Gtk.Button btnPrintSummary;
		
		private global::Gtk.CheckButton chkService;
		
		private global::Gtk.Button btnCheckIn;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmCheckin
			this.Name = "Momiji.frmCheckin";
			this.Title = global::Mono.Unix.Catalog.GetString ("Artist Check In");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmCheckin.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(8));
			// Container child vbox1.Gtk.Box+BoxChild
			this.tabControlMerch = new global::Gtk.Notebook ();
			this.tabControlMerch.CanFocus = true;
			this.tabControlMerch.Name = "tabControlMerch";
			this.tabControlMerch.CurrentPage = 0;
			// Container child tabControlMerch.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.lstMerch = new global::Gtk.NodeView ();
			this.lstMerch.CanFocus = true;
			this.lstMerch.Name = "lstMerch";
			this.lstMerch.EnableSearch = false;
			this.GtkScrolledWindow1.Add (this.lstMerch);
			this.tabControlMerch.Add (this.GtkScrolledWindow1);
			// Notebook tab
			this.lblControlSheet = new global::Gtk.Label ();
			this.lblControlSheet.Name = "lblControlSheet";
			this.lblControlSheet.LabelProp = global::Mono.Unix.Catalog.GetString ("Control Sheet");
			this.tabControlMerch.SetTabLabel (this.GtkScrolledWindow1, this.lblControlSheet);
			this.lblControlSheet.ShowAll ();
			// Container child tabControlMerch.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.lstGSMerch = new global::Gtk.NodeView ();
			this.lstGSMerch.CanFocus = true;
			this.lstGSMerch.Name = "lstGSMerch";
			this.lstGSMerch.EnableSearch = false;
			this.GtkScrolledWindow.Add (this.lstGSMerch);
			this.tabControlMerch.Add (this.GtkScrolledWindow);
			global::Gtk.Notebook.NotebookChild w4 = ((global::Gtk.Notebook.NotebookChild)(this.tabControlMerch [this.GtkScrolledWindow]));
			w4.Position = 1;
			// Notebook tab
			this.lblGalleryStore = new global::Gtk.Label ();
			this.lblGalleryStore.Name = "lblGalleryStore";
			this.lblGalleryStore.LabelProp = global::Mono.Unix.Catalog.GetString ("Gallery Store");
			this.tabControlMerch.SetTabLabel (this.GtkScrolledWindow, this.lblGalleryStore);
			this.lblGalleryStore.ShowAll ();
			this.vbox1.Add (this.tabControlMerch);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.tabControlMerch]));
			w5.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString ("Cancel");
			global::Gtk.Image w6 = new global::Gtk.Image ();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w6;
			this.hbox1.Add (this.btnCancel);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnCancel]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnEditArtist = new global::Gtk.Button ();
			this.btnEditArtist.CanFocus = true;
			this.btnEditArtist.Name = "btnEditArtist";
			this.btnEditArtist.UseUnderline = true;
			this.btnEditArtist.Label = global::Mono.Unix.Catalog.GetString ("Edit Artist");
			global::Gtk.Image w8 = new global::Gtk.Image ();
			w8.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.btnEditArtist.Image = w8;
			this.hbox1.Add (this.btnEditArtist);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnEditArtist]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnPrintSummary = new global::Gtk.Button ();
			this.btnPrintSummary.CanFocus = true;
			this.btnPrintSummary.Name = "btnPrintSummary";
			this.btnPrintSummary.UseUnderline = true;
			this.btnPrintSummary.Label = global::Mono.Unix.Catalog.GetString ("Print Summary");
			global::Gtk.Image w10 = new global::Gtk.Image ();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-print", global::Gtk.IconSize.Menu);
			this.btnPrintSummary.Image = w10;
			this.hbox1.Add (this.btnPrintSummary);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnPrintSummary]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.chkService = new global::Gtk.CheckButton ();
			this.chkService.CanFocus = true;
			this.chkService.Name = "chkService";
			this.chkService.Label = global::Mono.Unix.Catalog.GetString ("Service Fee ($10)");
			this.chkService.DrawIndicator = true;
			this.chkService.UseUnderline = true;
			this.hbox1.Add (this.chkService);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.chkService]));
			w12.Position = 3;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnCheckIn = new global::Gtk.Button ();
			this.btnCheckIn.CanFocus = true;
			this.btnCheckIn.Name = "btnCheckIn";
			this.btnCheckIn.UseUnderline = true;
			this.btnCheckIn.Label = global::Mono.Unix.Catalog.GetString ("Confirm Check In");
			global::Gtk.Image w13 = new global::Gtk.Image ();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.btnCheckIn.Image = w13;
			this.hbox1.Add (this.btnCheckIn);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.btnCheckIn]));
			w14.Position = 4;
			w14.Expand = false;
			w14.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 687;
			this.DefaultHeight = 300;
			this.Show ();
			this.btnCancel.Clicked += new global::System.EventHandler (this.OnBtnCancelClicked);
			this.btnEditArtist.Clicked += new global::System.EventHandler (this.OnBtnEditArtistClicked);
			this.btnPrintSummary.Clicked += new global::System.EventHandler (this.OnBtnPrintSummaryClicked);
			this.chkService.Toggled += new global::System.EventHandler (this.OnChkServiceToggled);
			this.btnCheckIn.Clicked += new global::System.EventHandler (this.OnBtnCheckInClicked);
		}
	}
}
