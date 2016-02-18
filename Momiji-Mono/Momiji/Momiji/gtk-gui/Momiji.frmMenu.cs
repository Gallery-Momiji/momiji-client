
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmMenu
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action FileAction;
		private global::Gtk.Action ArtistsAction;
		private global::Gtk.Action TreasuryAction;
		private global::Gtk.Action HelpAction;
		private global::Gtk.Action LogAction;
		private global::Gtk.Action preferencesAction;
		private global::Gtk.Action propertiesAction;
		private global::Gtk.Action indexAction;
		private global::Gtk.Action addAction;
		private global::Gtk.Action preferencesAction1;
		private global::Gtk.Action removeAction;
		private global::Gtk.Action closeAction;
		private global::Gtk.Action yesAction;
		private global::Gtk.Action noAction;
		private global::Gtk.Action propertiesAction1;
		private global::Gtk.Action GenerateBiddingSheetsAction;
		private global::Gtk.Action findAction1;
		private global::Gtk.Action findAndReplaceAction1;
		private global::Gtk.Action findAction;
		private global::Gtk.Action findAndReplaceAction;
		private global::Gtk.Action GenerateBiddingSheetsAction1;
		private global::Gtk.Action executeAction;
		private global::Gtk.Action addAction1;
		private global::Gtk.Action preferencesAction2;
		private global::Gtk.Action removeAction1;
		private global::Gtk.Action propertiesAction2;
		private global::Gtk.Action revertToSavedAction;
		private global::Gtk.Action convertAction;
		private global::Gtk.Action findAction2;
		private global::Gtk.Action findAndReplaceAction2;
		private global::Gtk.Action findAction3;
		private global::Gtk.Action findAndReplaceAction3;
		private global::Gtk.Action findAction4;
		private global::Gtk.Action findAndReplaceAction4;
		private global::Gtk.Action findAction5;
		private global::Gtk.Action findAndReplaceAction5;
		private global::Gtk.Action findAction6;
		private global::Gtk.Action findAndReplaceAction6;
		private global::Gtk.Action revertToSavedAction1;
		private global::Gtk.Action undoAction;
		private global::Gtk.Action dialogWarningAction;
		private global::Gtk.Action aboutAction;
		private global::Gtk.Action dialogQuestionAction;
		private global::Gtk.Action dialogQuestionAction1;
		private global::Gtk.Action dialogQuestionAction2;
		private global::Gtk.Action propertiesAction3;
		private global::Gtk.Action revertToSavedAction3;
		private global::Gtk.Action quitAction;
		private global::Gtk.VBox vbox2;
		private global::Gtk.MenuBar menubar3;
		private global::Gtk.HBox hbox8;
		private global::Gtk.Button btnQuickSale;
		private global::Gtk.Button btnAuctionSale;
		private global::Gtk.Button btnGalleryStoreSale;
		private global::Gtk.HBox hbox9;
		private global::Gtk.Button btnLogout;
		private global::Gtk.Label lblGreeting;
		private global::Gtk.Fixed fixed1;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmMenu
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
			this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
			w1.Add (this.FileAction, null);
			this.ArtistsAction = new global::Gtk.Action ("ArtistsAction", global::Mono.Unix.Catalog.GetString ("Artists"), null, null);
			this.ArtistsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Artists");
			w1.Add (this.ArtistsAction, null);
			this.TreasuryAction = new global::Gtk.Action ("TreasuryAction", global::Mono.Unix.Catalog.GetString ("Treasury"), null, null);
			this.TreasuryAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Treasury");
			w1.Add (this.TreasuryAction, null);
			this.HelpAction = new global::Gtk.Action ("HelpAction", global::Mono.Unix.Catalog.GetString ("Help"), null, null);
			this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Help");
			w1.Add (this.HelpAction, null);
			this.LogAction = new global::Gtk.Action ("LogAction", global::Mono.Unix.Catalog.GetString ("Log"), null, null);
			this.LogAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Log");
			w1.Add (this.LogAction, null);
			this.preferencesAction = new global::Gtk.Action ("preferencesAction", global::Mono.Unix.Catalog.GetString ("Preferences"), null, "gtk-preferences");
			this.preferencesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Preferences");
			w1.Add (this.preferencesAction, null);
			this.propertiesAction = new global::Gtk.Action ("propertiesAction", global::Mono.Unix.Catalog.GetString ("Pricing"), null, "gtk-properties");
			this.propertiesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Pricing");
			w1.Add (this.propertiesAction, null);
			this.indexAction = new global::Gtk.Action ("indexAction", global::Mono.Unix.Catalog.GetString ("Users"), null, "gtk-index");
			this.indexAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Users");
			w1.Add (this.indexAction, null);
			this.addAction = new global::Gtk.Action ("addAction", global::Mono.Unix.Catalog.GetString ("Add User"), null, "gtk-add");
			this.addAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Add User");
			w1.Add (this.addAction, null);
			this.preferencesAction1 = new global::Gtk.Action ("preferencesAction1", global::Mono.Unix.Catalog.GetString ("Edit User"), null, "gtk-preferences");
			this.preferencesAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit User");
			w1.Add (this.preferencesAction1, null);
			this.removeAction = new global::Gtk.Action ("removeAction", global::Mono.Unix.Catalog.GetString ("Remove User"), null, "gtk-remove");
			this.removeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Remove User");
			w1.Add (this.removeAction, null);
			this.closeAction = new global::Gtk.Action ("closeAction", global::Mono.Unix.Catalog.GetString ("Logout"), null, "gtk-close");
			this.closeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Exit");
			w1.Add (this.closeAction, null);
			this.yesAction = new global::Gtk.Action ("yesAction", global::Mono.Unix.Catalog.GetString ("Check In"), null, "gtk-yes");
			this.yesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check In");
			w1.Add (this.yesAction, null);
			this.noAction = new global::Gtk.Action ("noAction", global::Mono.Unix.Catalog.GetString ("Check Out"), null, "gtk-no");
			this.noAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check Out");
			w1.Add (this.noAction, null);
			this.propertiesAction1 = new global::Gtk.Action ("propertiesAction1", global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets"), null, "gtk-properties");
			this.propertiesAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets");
			w1.Add (this.propertiesAction1, null);
			this.GenerateBiddingSheetsAction = new global::Gtk.Action ("GenerateBiddingSheetsAction", global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets"), null, null);
			this.GenerateBiddingSheetsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets");
			w1.Add (this.GenerateBiddingSheetsAction, null);
			this.findAction1 = new global::Gtk.Action ("findAction1", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.findAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.findAction1, null);
			this.findAndReplaceAction1 = new global::Gtk.Action ("findAndReplaceAction1", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.findAndReplaceAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.findAndReplaceAction1, null);
			this.findAction = new global::Gtk.Action ("findAction", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.findAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.findAction, null);
			this.findAndReplaceAction = new global::Gtk.Action ("findAndReplaceAction", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.findAndReplaceAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.findAndReplaceAction, null);
			this.GenerateBiddingSheetsAction1 = new global::Gtk.Action ("GenerateBiddingSheetsAction1", global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets"), null, null);
			this.GenerateBiddingSheetsAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets");
			w1.Add (this.GenerateBiddingSheetsAction1, null);
			this.executeAction = new global::Gtk.Action ("executeAction", global::Mono.Unix.Catalog.GetString ("Manage"), null, "gtk-execute");
			this.executeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Manage");
			w1.Add (this.executeAction, null);
			this.addAction1 = new global::Gtk.Action ("addAction1", global::Mono.Unix.Catalog.GetString ("Add Artist"), null, "gtk-add");
			this.addAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Add Artist");
			w1.Add (this.addAction1, null);
			this.preferencesAction2 = new global::Gtk.Action ("preferencesAction2", global::Mono.Unix.Catalog.GetString ("Edit Artist"), null, "gtk-preferences");
			this.preferencesAction2.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Artist");
			w1.Add (this.preferencesAction2, null);
			this.removeAction1 = new global::Gtk.Action ("removeAction1", global::Mono.Unix.Catalog.GetString ("Delete Artist"), null, "gtk-remove");
			this.removeAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Delete Artist");
			w1.Add (this.removeAction1, null);
			this.propertiesAction2 = new global::Gtk.Action ("propertiesAction2", global::Mono.Unix.Catalog.GetString ("Edit Merchandise"), null, "gtk-properties");
			this.propertiesAction2.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Merchandise");
			w1.Add (this.propertiesAction2, null);
			this.revertToSavedAction = new global::Gtk.Action ("revertToSavedAction", global::Mono.Unix.Catalog.GetString ("Edit Gallery Store Merchandise"), null, "gtk-revert-to-saved");
			this.revertToSavedAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Gallery Store Merchandise");
			w1.Add (this.revertToSavedAction, null);
			this.convertAction = new global::Gtk.Action ("convertAction", global::Mono.Unix.Catalog.GetString ("Manage Artist Balance"), null, "gtk-convert");
			this.convertAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Manage Artist Balance");
			w1.Add (this.convertAction, null);
			this.findAction2 = new global::Gtk.Action ("findAction2", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.findAction2.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.findAction2, null);
			this.findAndReplaceAction2 = new global::Gtk.Action ("findAndReplaceAction2", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.findAndReplaceAction2.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.findAndReplaceAction2, null);
			this.findAction3 = new global::Gtk.Action ("findAction3", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.findAction3.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.findAction3, null);
			this.findAndReplaceAction3 = new global::Gtk.Action ("findAndReplaceAction3", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.findAndReplaceAction3.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.findAndReplaceAction3, null);
			this.findAction4 = new global::Gtk.Action ("findAction4", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.findAction4.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.findAction4, null);
			this.findAndReplaceAction4 = new global::Gtk.Action ("findAndReplaceAction4", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.findAndReplaceAction4.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.findAndReplaceAction4, null);
			this.findAction5 = new global::Gtk.Action ("findAction5", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.findAction5.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.findAction5, null);
			this.findAndReplaceAction5 = new global::Gtk.Action ("findAndReplaceAction5", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.findAndReplaceAction5.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.findAndReplaceAction5, null);
			this.findAction6 = new global::Gtk.Action ("findAction6", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.findAction6.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.findAction6, null);
			this.findAndReplaceAction6 = new global::Gtk.Action ("findAndReplaceAction6", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.findAndReplaceAction6.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.findAndReplaceAction6, null);
			this.revertToSavedAction1 = new global::Gtk.Action ("revertToSavedAction1", global::Mono.Unix.Catalog.GetString ("Check Sales Records"), null, "gtk-revert-to-saved");
			this.revertToSavedAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check Sales Records");
			w1.Add (this.revertToSavedAction1, null);
			this.undoAction = new global::Gtk.Action ("undoAction", global::Mono.Unix.Catalog.GetString ("Refunds"), null, "gtk-undo");
			this.undoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Refunds");
			w1.Add (this.undoAction, null);
			this.dialogWarningAction = new global::Gtk.Action ("dialogWarningAction", global::Mono.Unix.Catalog.GetString ("FAQ"), null, "gtk-dialog-warning");
			this.dialogWarningAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Panic");
			w1.Add (this.dialogWarningAction, null);
			this.aboutAction = new global::Gtk.Action ("aboutAction", global::Mono.Unix.Catalog.GetString ("About"), null, "gtk-about");
			this.aboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("About");
			w1.Add (this.aboutAction, null);
			this.dialogQuestionAction = new global::Gtk.Action ("dialogQuestionAction", global::Mono.Unix.Catalog.GetString ("What is this?"), null, "gtk-dialog-question");
			this.dialogQuestionAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("What is this?");
			w1.Add (this.dialogQuestionAction, null);
			this.dialogQuestionAction1 = new global::Gtk.Action ("dialogQuestionAction1", global::Mono.Unix.Catalog.GetString ("What do I do?"), null, "gtk-dialog-question");
			this.dialogQuestionAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("What do I do?");
			w1.Add (this.dialogQuestionAction1, null);
			this.dialogQuestionAction2 = new global::Gtk.Action ("dialogQuestionAction2", global::Mono.Unix.Catalog.GetString ("Why can't I use certain features?"), null, "gtk-dialog-question");
			this.dialogQuestionAction2.ShortLabel = global::Mono.Unix.Catalog.GetString ("Why can't I use certain features?");
			w1.Add (this.dialogQuestionAction2, null);
			this.propertiesAction3 = new global::Gtk.Action ("propertiesAction3", global::Mono.Unix.Catalog.GetString ("Check user activities"), null, "gtk-properties");
			this.propertiesAction3.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check user activities");
			w1.Add (this.propertiesAction3, null);
			this.revertToSavedAction3 = new global::Gtk.Action ("revertToSavedAction3", global::Mono.Unix.Catalog.GetString ("Check latest receipts"), null, "gtk-revert-to-saved");
			this.revertToSavedAction3.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check latest receipts");
			w1.Add (this.revertToSavedAction3, null);
			this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("_Quit"), null, "gtk-quit");
			this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Quit");
			w1.Add (this.quitAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "Momiji.frmMenu";
			this.Title = global::Mono.Unix.Catalog.GetString ("Gallery Momiji Point-Of-Sale");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmMenu.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 8;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar3'><menu name='FileAction' action='FileAction'><menu name='preferencesAction' action='preferencesAction'><menuitem name='propertiesAction' action='propertiesAction'/><menu name='indexAction' action='indexAction'><menuitem name='addAction' action='addAction'/><menuitem name='preferencesAction1' action='preferencesAction1'/><menuitem name='removeAction' action='removeAction'/></menu><menuitem/></menu><menuitem name='closeAction' action='closeAction'/><menuitem name='quitAction' action='quitAction'/></menu><menu name='ArtistsAction' action='ArtistsAction'><menu name='yesAction' action='yesAction'><menuitem name='findAction1' action='findAction1'/><menuitem name='findAndReplaceAction1' action='findAndReplaceAction1'/></menu><menuitem name='noAction' action='noAction'/><menuitem/><menu name='executeAction' action='executeAction'><menuitem name='addAction1' action='addAction1'/><menu name='preferencesAction2' action='preferencesAction2'><menuitem name='findAction2' action='findAction2'/><menuitem name='findAndReplaceAction2' action='findAndReplaceAction2'/></menu><menu name='removeAction1' action='removeAction1'><menuitem name='findAction3' action='findAction3'/><menuitem name='findAndReplaceAction3' action='findAndReplaceAction3'/></menu><menu name='propertiesAction2' action='propertiesAction2'><menuitem name='findAction4' action='findAction4'/><menuitem name='findAndReplaceAction4' action='findAndReplaceAction4'/></menu><menu name='revertToSavedAction' action='revertToSavedAction'><menuitem name='findAction5' action='findAction5'/><menuitem name='findAndReplaceAction5' action='findAndReplaceAction5'/></menu><menu name='convertAction' action='convertAction'><menuitem name='findAction6' action='findAction6'/><menuitem name='findAndReplaceAction6' action='findAndReplaceAction6'/></menu></menu><menu name='propertiesAction1' action='propertiesAction1'><menuitem name='findAction' action='findAction'/><menuitem name='findAndReplaceAction' action='findAndReplaceAction'/></menu></menu><menu name='TreasuryAction' action='TreasuryAction'><menuitem name='revertToSavedAction1' action='revertToSavedAction1'/><menuitem name='undoAction' action='undoAction'/></menu><menu name='HelpAction' action='HelpAction'><menu name='dialogWarningAction' action='dialogWarningAction'><menuitem name='dialogQuestionAction' action='dialogQuestionAction'/><menuitem name='dialogQuestionAction1' action='dialogQuestionAction1'/><menuitem name='dialogQuestionAction2' action='dialogQuestionAction2'/></menu><menuitem name='aboutAction' action='aboutAction'/></menu><menu name='LogAction' action='LogAction'><menuitem name='propertiesAction3' action='propertiesAction3'/><menuitem name='revertToSavedAction3' action='revertToSavedAction3'/></menu></menubar></ui>");
			this.menubar3 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar3")));
			this.menubar3.Name = "menubar3";
			this.vbox2.Add (this.menubar3);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.menubar3]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 8;
			this.hbox8.BorderWidth = ((uint)(16));
			// Container child hbox8.Gtk.Box+BoxChild
			this.btnQuickSale = new global::Gtk.Button ();
			this.btnQuickSale.WidthRequest = 130;
			this.btnQuickSale.HeightRequest = 130;
			this.btnQuickSale.CanFocus = true;
			this.btnQuickSale.Name = "btnQuickSale";
			// Container child btnQuickSale.Gtk.Container+ContainerChild
			global::Gtk.Alignment w3 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w4 = new global::Gtk.HBox ();
			w4.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.tag-sale-icon.png");
			w4.Add (w5);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w7 = new global::Gtk.Label ();
			w7.LabelProp = global::Mono.Unix.Catalog.GetString ("Quick\nSale");
			w4.Add (w7);
			w3.Add (w4);
			this.btnQuickSale.Add (w3);
			this.hbox8.Add (this.btnQuickSale);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.btnQuickSale]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.btnAuctionSale = new global::Gtk.Button ();
			this.btnAuctionSale.WidthRequest = 130;
			this.btnAuctionSale.HeightRequest = 130;
			this.btnAuctionSale.CanFocus = true;
			this.btnAuctionSale.Name = "btnAuctionSale";
			this.btnAuctionSale.UseUnderline = true;
			// Container child btnAuctionSale.Gtk.Container+ContainerChild
			global::Gtk.Alignment w12 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w13 = new global::Gtk.HBox ();
			w13.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w14 = new global::Gtk.Image ();
			w14.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.shopping-bag-icon.png");
			w13.Add (w14);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w16 = new global::Gtk.Label ();
			w16.LabelProp = global::Mono.Unix.Catalog.GetString ("Auction\nSale");
			w16.UseUnderline = true;
			w13.Add (w16);
			w12.Add (w13);
			this.btnAuctionSale.Add (w12);
			this.hbox8.Add (this.btnAuctionSale);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.btnAuctionSale]));
			w20.Position = 1;
			w20.Expand = false;
			w20.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.btnGalleryStoreSale = new global::Gtk.Button ();
			this.btnGalleryStoreSale.WidthRequest = 130;
			this.btnGalleryStoreSale.HeightRequest = 130;
			this.btnGalleryStoreSale.CanFocus = true;
			this.btnGalleryStoreSale.Name = "btnGalleryStoreSale";
			this.btnGalleryStoreSale.UseUnderline = true;
			// Container child btnGalleryStoreSale.Gtk.Container+ContainerChild
			global::Gtk.Alignment w21 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w22 = new global::Gtk.HBox ();
			w22.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w23 = new global::Gtk.Image ();
			w23.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.shopping-basket-icon.png");
			w22.Add (w23);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w25 = new global::Gtk.Label ();
			w25.LabelProp = global::Mono.Unix.Catalog.GetString ("Gallery\nStore\nSale");
			w25.UseUnderline = true;
			w22.Add (w25);
			w21.Add (w22);
			this.btnGalleryStoreSale.Add (w21);
			this.hbox8.Add (this.btnGalleryStoreSale);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.btnGalleryStoreSale]));
			w29.Position = 2;
			w29.Expand = false;
			w29.Fill = false;
			this.vbox2.Add (this.hbox8);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox8]));
			w30.Position = 1;
			w30.Expand = false;
			w30.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox ();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 8;
			this.hbox9.BorderWidth = ((uint)(16));
			// Container child hbox9.Gtk.Box+BoxChild
			this.btnLogout = new global::Gtk.Button ();
			this.btnLogout.WidthRequest = 394;
			this.btnLogout.CanFocus = true;
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.UseUnderline = true;
			this.btnLogout.Label = global::Mono.Unix.Catalog.GetString ("Logout");
			this.hbox9.Add (this.btnLogout);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.btnLogout]));
			w31.Position = 0;
			w31.Expand = false;
			w31.Fill = false;
			this.vbox2.Add (this.hbox9);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox9]));
			w32.Position = 2;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.lblGreeting = new global::Gtk.Label ();
			this.lblGreeting.Name = "lblGreeting";
			this.lblGreeting.Xpad = 8;
			this.lblGreeting.Xalign = 0F;
			this.lblGreeting.LabelProp = global::Mono.Unix.Catalog.GetString ("lblGreeting");
			this.vbox2.Add (this.lblGreeting);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.lblGreeting]));
			w33.Position = 3;
			w33.Expand = false;
			w33.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			this.vbox2.Add (this.fixed1);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.fixed1]));
			w34.Position = 4;
			w34.Expand = false;
			w34.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 438;
			this.DefaultHeight = 314;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.closeAction.Activated += new global::System.EventHandler (this.OnExitActionActivated);
			this.quitAction.Activated += new global::System.EventHandler (this.OnQuitActionActivated);
			this.btnQuickSale.Clicked += new global::System.EventHandler (this.OnBtnQuickSaleClicked);
			this.btnAuctionSale.Clicked += new global::System.EventHandler (this.OnBtnAuctionSaleClicked);
			this.btnGalleryStoreSale.Clicked += new global::System.EventHandler (this.OnBtnGalleryStoreSaleClicked);
			this.btnLogout.Clicked += new global::System.EventHandler (this.OnBtnLogoutClicked);
		}
	}
}