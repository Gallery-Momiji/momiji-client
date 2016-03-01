
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
		private global::Gtk.Action PricingAction;
		private global::Gtk.Action UsersPrefAction;
		private global::Gtk.Action addUserAction;
		private global::Gtk.Action editUserAction;
		private global::Gtk.Action removeAction;
		private global::Gtk.Action closeAction;
		private global::Gtk.Action checkInAction;
		private global::Gtk.Action CheckOutAction;
		private global::Gtk.Action GenerateBiddingAction;
		private global::Gtk.Action GenerateBiddingSheetsAction;
		private global::Gtk.Action checkInByIDAction;
		private global::Gtk.Action checkInByNameAction;
		private global::Gtk.Action GenerateBiddingByIDAction;
		private global::Gtk.Action GenerateBiddingByNameAction;
		private global::Gtk.Action GenerateBiddingSheetsAction1;
		private global::Gtk.Action ManageArtistAction;
		private global::Gtk.Action AddArtistAction;
		private global::Gtk.Action EditArtistAction;
		private global::Gtk.Action DeleteArtistAction;
		private global::Gtk.Action EditArtistMerchAction;
		private global::Gtk.Action EditArtistGSMerchAction;
		private global::Gtk.Action ManageArtistBalanceAction;
		private global::Gtk.Action EditArtistByIDAction;
		private global::Gtk.Action EditArtistByNameAction;
		private global::Gtk.Action DeleteArtistByIDAction;
		private global::Gtk.Action DeleteArtistByNameAction1;
		private global::Gtk.Action EditArtistMerchByIDAction;
		private global::Gtk.Action EditArtistMerchByNameAction;
		private global::Gtk.Action EditArtistGSMerchByIDAction;
		private global::Gtk.Action EditArtistGSMerchByNameAction;
		private global::Gtk.Action ManageArtistByIDAction;
		private global::Gtk.Action ManageArtistByNameAction;
		private global::Gtk.Action CheckSalesAction;
		private global::Gtk.Action RefundAction;
		private global::Gtk.Action FAQAction;
		private global::Gtk.Action aboutAction;
		private global::Gtk.Action WhatIsThisAction;
		private global::Gtk.Action WhatDoIDoAction;
		private global::Gtk.Action WhyCantUseFeatureAction;
		private global::Gtk.Action checkUserActivitiesAction;
		private global::Gtk.Action checkLatestReceiptsAction;
		private global::Gtk.Action quitAction;
		private global::Gtk.Action reprintReceiptsAction;
		private global::Gtk.VBox vboxMenu;
		private global::Gtk.MenuBar menubarMenu;
		private global::Gtk.HBox hboxButtons;
		private global::Gtk.Button btnQuickSale;
		private global::Gtk.Button btnAuctionSale;
		private global::Gtk.Button btnGalleryStoreSale;
		private global::Gtk.HBox hboxLogout;
		private global::Gtk.Button btnLogout;
		private global::Gtk.Label lblGreeting;

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
			this.preferencesAction = new global::Gtk.Action ("preferencesAction", global::Mono.Unix.Catalog.GetString ("_Preferences"), null, "gtk-preferences");
			this.preferencesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Preferences");
			w1.Add (this.preferencesAction, null);
			this.PricingAction = new global::Gtk.Action ("PricingAction", global::Mono.Unix.Catalog.GetString ("_Pricing"), null, "gtk-properties");
			this.PricingAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Pricing");
			w1.Add (this.PricingAction, null);
			this.UsersPrefAction = new global::Gtk.Action ("UsersPrefAction", global::Mono.Unix.Catalog.GetString ("_Users"), null, "gtk-index");
			this.UsersPrefAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Users");
			w1.Add (this.UsersPrefAction, null);
			this.addUserAction = new global::Gtk.Action ("addUserAction", global::Mono.Unix.Catalog.GetString ("_Add User"), null, "gtk-add");
			this.addUserAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Add User");
			w1.Add (this.addUserAction, null);
			this.editUserAction = new global::Gtk.Action ("editUserAction", global::Mono.Unix.Catalog.GetString ("_Edit User"), null, "gtk-preferences");
			this.editUserAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit User");
			w1.Add (this.editUserAction, null);
			this.removeAction = new global::Gtk.Action ("removeAction", null, null, "gtk-remove");
			this.removeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Remove User");
			w1.Add (this.removeAction, null);
			this.closeAction = new global::Gtk.Action ("closeAction", global::Mono.Unix.Catalog.GetString ("_Logout"), null, "gtk-close");
			this.closeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Logout");
			w1.Add (this.closeAction, null);
			this.checkInAction = new global::Gtk.Action ("checkInAction", global::Mono.Unix.Catalog.GetString ("Check _In"), null, "gtk-yes");
			this.checkInAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check In");
			w1.Add (this.checkInAction, null);
			this.CheckOutAction = new global::Gtk.Action ("CheckOutAction", global::Mono.Unix.Catalog.GetString ("Check _Out"), null, "gtk-no");
			this.CheckOutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check Out");
			w1.Add (this.CheckOutAction, null);
			this.GenerateBiddingAction = new global::Gtk.Action ("GenerateBiddingAction", global::Mono.Unix.Catalog.GetString ("Generate _Bidding Sheets"), null, "gtk-properties");
			this.GenerateBiddingAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets");
			w1.Add (this.GenerateBiddingAction, null);
			this.GenerateBiddingSheetsAction = new global::Gtk.Action ("GenerateBiddingSheetsAction", global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets"), null, null);
			this.GenerateBiddingSheetsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets");
			w1.Add (this.GenerateBiddingSheetsAction, null);
			this.checkInByIDAction = new global::Gtk.Action ("checkInByIDAction", global::Mono.Unix.Catalog.GetString ("Search Artist by _ID"), null, "gtk-find");
			this.checkInByIDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.checkInByIDAction, null);
			this.checkInByNameAction = new global::Gtk.Action ("checkInByNameAction", global::Mono.Unix.Catalog.GetString ("Search Artist by _Name"), null, "gtk-find-and-replace");
			this.checkInByNameAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.checkInByNameAction, null);
			this.GenerateBiddingByIDAction = new global::Gtk.Action ("GenerateBiddingByIDAction", global::Mono.Unix.Catalog.GetString ("Search Artist by _ID"), null, "gtk-find");
			this.GenerateBiddingByIDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.GenerateBiddingByIDAction, null);
			this.GenerateBiddingByNameAction = new global::Gtk.Action ("GenerateBiddingByNameAction", global::Mono.Unix.Catalog.GetString ("Search Artist by _Name"), null, "gtk-find-and-replace");
			this.GenerateBiddingByNameAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.GenerateBiddingByNameAction, null);
			this.GenerateBiddingSheetsAction1 = new global::Gtk.Action ("GenerateBiddingSheetsAction1", global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets"), null, null);
			this.GenerateBiddingSheetsAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets");
			w1.Add (this.GenerateBiddingSheetsAction1, null);
			this.ManageArtistAction = new global::Gtk.Action ("ManageArtistAction", global::Mono.Unix.Catalog.GetString ("_Manage"), null, "gtk-execute");
			this.ManageArtistAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Manage");
			w1.Add (this.ManageArtistAction, null);
			this.AddArtistAction = new global::Gtk.Action ("AddArtistAction", global::Mono.Unix.Catalog.GetString ("_Add Artist"), null, "gtk-add");
			this.AddArtistAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Add Artist");
			w1.Add (this.AddArtistAction, null);
			this.EditArtistAction = new global::Gtk.Action ("EditArtistAction", global::Mono.Unix.Catalog.GetString ("_Edit Artist"), null, "gtk-preferences");
			this.EditArtistAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Artist");
			w1.Add (this.EditArtistAction, null);
			this.DeleteArtistAction = new global::Gtk.Action ("DeleteArtistAction", global::Mono.Unix.Catalog.GetString ("_Delete Artist"), null, "gtk-remove");
			this.DeleteArtistAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Delete Artist");
			w1.Add (this.DeleteArtistAction, null);
			this.EditArtistMerchAction = new global::Gtk.Action ("EditArtistMerchAction", global::Mono.Unix.Catalog.GetString ("Edit _Merchandise"), null, "gtk-properties");
			this.EditArtistMerchAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Merchandise");
			w1.Add (this.EditArtistMerchAction, null);
			this.EditArtistGSMerchAction = new global::Gtk.Action ("EditArtistGSMerchAction", global::Mono.Unix.Catalog.GetString ("Edit _Gallery Store Merchandise"), null, "gtk-revert-to-saved");
			this.EditArtistGSMerchAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Gallery Store Merchandise");
			w1.Add (this.EditArtistGSMerchAction, null);
			this.ManageArtistBalanceAction = new global::Gtk.Action ("ManageArtistBalanceAction", global::Mono.Unix.Catalog.GetString ("Manage Artist _Balance"), null, "gtk-convert");
			this.ManageArtistBalanceAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Manage Artist Balance");
			w1.Add (this.ManageArtistBalanceAction, null);
			this.EditArtistByIDAction = new global::Gtk.Action ("EditArtistByIDAction", global::Mono.Unix.Catalog.GetString ("Search Artist by _ID"), null, "gtk-find");
			this.EditArtistByIDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.EditArtistByIDAction, null);
			this.EditArtistByNameAction = new global::Gtk.Action ("EditArtistByNameAction", global::Mono.Unix.Catalog.GetString ("Search Artist by _Name"), null, "gtk-find-and-replace");
			this.EditArtistByNameAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.EditArtistByNameAction, null);
			this.DeleteArtistByIDAction = new global::Gtk.Action ("DeleteArtistByIDAction", global::Mono.Unix.Catalog.GetString ("Search Artist by _ID"), null, "gtk-find");
			this.DeleteArtistByIDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.DeleteArtistByIDAction, null);
			this.DeleteArtistByNameAction1 = new global::Gtk.Action ("DeleteArtistByNameAction1", global::Mono.Unix.Catalog.GetString ("Search Artist by _Name"), null, "gtk-find-and-replace");
			this.DeleteArtistByNameAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.DeleteArtistByNameAction1, null);
			this.EditArtistMerchByIDAction = new global::Gtk.Action ("EditArtistMerchByIDAction", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.EditArtistMerchByIDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.EditArtistMerchByIDAction, null);
			this.EditArtistMerchByNameAction = new global::Gtk.Action ("EditArtistMerchByNameAction", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.EditArtistMerchByNameAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.EditArtistMerchByNameAction, null);
			this.EditArtistGSMerchByIDAction = new global::Gtk.Action ("EditArtistGSMerchByIDAction", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.EditArtistGSMerchByIDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.EditArtistGSMerchByIDAction, null);
			this.EditArtistGSMerchByNameAction = new global::Gtk.Action ("EditArtistGSMerchByNameAction", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.EditArtistGSMerchByNameAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.EditArtistGSMerchByNameAction, null);
			this.ManageArtistByIDAction = new global::Gtk.Action ("ManageArtistByIDAction", global::Mono.Unix.Catalog.GetString ("Search Artist by ID"), null, "gtk-find");
			this.ManageArtistByIDAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by ID");
			w1.Add (this.ManageArtistByIDAction, null);
			this.ManageArtistByNameAction = new global::Gtk.Action ("ManageArtistByNameAction", global::Mono.Unix.Catalog.GetString ("Search Artist by Name"), null, "gtk-find-and-replace");
			this.ManageArtistByNameAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Search Artist by Name");
			w1.Add (this.ManageArtistByNameAction, null);
			this.CheckSalesAction = new global::Gtk.Action ("CheckSalesAction", global::Mono.Unix.Catalog.GetString ("_Check Sales Records"), null, "gtk-revert-to-saved");
			this.CheckSalesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check Sales Records");
			w1.Add (this.CheckSalesAction, null);
			this.RefundAction = new global::Gtk.Action ("RefundAction", global::Mono.Unix.Catalog.GetString ("_Refunds"), null, "gtk-undo");
			this.RefundAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Refunds");
			w1.Add (this.RefundAction, null);
			this.FAQAction = new global::Gtk.Action ("FAQAction", global::Mono.Unix.Catalog.GetString ("_FAQ"), null, "gtk-dialog-warning");
			this.FAQAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Panic");
			w1.Add (this.FAQAction, null);
			this.aboutAction = new global::Gtk.Action ("aboutAction", global::Mono.Unix.Catalog.GetString ("_About"), null, "gtk-about");
			this.aboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("About");
			w1.Add (this.aboutAction, null);
			this.WhatIsThisAction = new global::Gtk.Action ("WhatIsThisAction", global::Mono.Unix.Catalog.GetString ("What is this?"), null, "gtk-dialog-question");
			this.WhatIsThisAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("What is this?");
			w1.Add (this.WhatIsThisAction, null);
			this.WhatDoIDoAction = new global::Gtk.Action ("WhatDoIDoAction", global::Mono.Unix.Catalog.GetString ("What do I do?"), null, "gtk-dialog-question");
			this.WhatDoIDoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("What do I do?");
			w1.Add (this.WhatDoIDoAction, null);
			this.WhyCantUseFeatureAction = new global::Gtk.Action ("WhyCantUseFeatureAction", global::Mono.Unix.Catalog.GetString ("Why can\'t I use certain features?"), null, "gtk-dialog-question");
			this.WhyCantUseFeatureAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Why can\'t I use certain features?");
			w1.Add (this.WhyCantUseFeatureAction, null);
			this.checkUserActivitiesAction = new global::Gtk.Action ("checkUserActivitiesAction", global::Mono.Unix.Catalog.GetString ("Check _user activities"), null, "gtk-properties");
			this.checkUserActivitiesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check user activities");
			w1.Add (this.checkUserActivitiesAction, null);
			this.checkLatestReceiptsAction = new global::Gtk.Action ("checkLatestReceiptsAction", global::Mono.Unix.Catalog.GetString ("Check latest _receipts"), null, "gtk-print-preview");
			this.checkLatestReceiptsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check latest receipts");
			w1.Add (this.checkLatestReceiptsAction, null);
			this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("_Quit"), null, "gtk-quit");
			this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Quit");
			w1.Add (this.quitAction, null);
			this.reprintReceiptsAction = new global::Gtk.Action ("reprintReceiptsAction", global::Mono.Unix.Catalog.GetString ("Re-_Print Receipt"), null, "gtk-print");
			this.reprintReceiptsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Re-_Print Receipt");
			w1.Add (this.reprintReceiptsAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "Momiji.frmMenu";
			this.Title = global::Mono.Unix.Catalog.GetString ("Gallery Momiji Point-Of-Sale");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmMenu.Gtk.Container+ContainerChild
			this.vboxMenu = new global::Gtk.VBox ();
			this.vboxMenu.Name = "vboxMenu";
			this.vboxMenu.Spacing = 8;
			// Container child vboxMenu.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name=\'menubarMenu\'><menu name=\'FileAction\' action=\'FileAction\'><menu" +
			" name=\'preferencesAction\' action=\'preferencesAction\'><menuitem name=\'PricingActi" +
			"on\' action=\'PricingAction\'/><menu name=\'UsersPrefAction\' action=\'UsersPrefAction" +
			"\'><menuitem name=\'addUserAction\' action=\'addUserAction\'/><menuitem name=\'editUse" +
			"rAction\' action=\'editUserAction\'/></menu><menuitem/></menu><menuitem name=\'close" +
			"Action\' action=\'closeAction\'/><menuitem name=\'quitAction\' action=\'quitAction\'/><" +
			"/menu><menu name=\'ArtistsAction\' action=\'ArtistsAction\'><menu name=\'checkInActio" +
			"n\' action=\'checkInAction\'><menuitem name=\'checkInByIDAction\' action=\'checkInByID" +
			"Action\'/><menuitem name=\'checkInByNameAction\' action=\'checkInByNameAction\'/></me" +
			"nu><menuitem name=\'CheckOutAction\' action=\'CheckOutAction\'/><menuitem/><menu nam" +
			"e=\'ManageArtistAction\' action=\'ManageArtistAction\'><menuitem name=\'AddArtistActi" +
			"on\' action=\'AddArtistAction\'/><menu name=\'EditArtistAction\' action=\'EditArtistAc" +
			"tion\'><menuitem name=\'EditArtistByIDAction\' action=\'EditArtistByIDAction\'/><menu" +
			"item name=\'EditArtistByNameAction\' action=\'EditArtistByNameAction\'/></menu><menu" +
			" name=\'DeleteArtistAction\' action=\'DeleteArtistAction\'><menuitem name=\'DeleteArt" +
			"istByIDAction\' action=\'DeleteArtistByIDAction\'/><menuitem name=\'DeleteArtistByNa" +
			"meAction1\' action=\'DeleteArtistByNameAction1\'/></menu><menu name=\'EditArtistMerc" +
			"hAction\' action=\'EditArtistMerchAction\'><menuitem name=\'EditArtistMerchByIDActio" +
			"n\' action=\'EditArtistMerchByIDAction\'/><menuitem name=\'EditArtistMerchByNameActi" +
			"on\' action=\'EditArtistMerchByNameAction\'/></menu><menu name=\'EditArtistGSMerchAc" +
			"tion\' action=\'EditArtistGSMerchAction\'><menuitem name=\'EditArtistGSMerchByIDActi" +
			"on\' action=\'EditArtistGSMerchByIDAction\'/><menuitem name=\'EditArtistGSMerchByNam" +
			"eAction\' action=\'EditArtistGSMerchByNameAction\'/></menu><menu name=\'ManageArtist" +
			"BalanceAction\' action=\'ManageArtistBalanceAction\'><menuitem name=\'ManageArtistBy" +
			"IDAction\' action=\'ManageArtistByIDAction\'/><menuitem name=\'ManageArtistByNameAct" +
			"ion\' action=\'ManageArtistByNameAction\'/></menu></menu><menu name=\'GenerateBiddin" +
			"gAction\' action=\'GenerateBiddingAction\'><menuitem name=\'GenerateBiddingByIDActio" +
			"n\' action=\'GenerateBiddingByIDAction\'/><menuitem name=\'GenerateBiddingByNameActi" +
			"on\' action=\'GenerateBiddingByNameAction\'/></menu></menu><menu name=\'TreasuryActi" +
			"on\' action=\'TreasuryAction\'><menuitem name=\'CheckSalesAction\' action=\'CheckSales" +
			"Action\'/><menuitem name=\'RefundAction\' action=\'RefundAction\'/><menuitem name=\'re" +
			"printReceiptsAction\' action=\'reprintReceiptsAction\'/></menu><menu name=\'LogActio" +
			"n\' action=\'LogAction\'><menuitem name=\'checkUserActivitiesAction\' action=\'checkUs" +
			"erActivitiesAction\'/><menuitem name=\'checkLatestReceiptsAction\' action=\'checkLat" +
			"estReceiptsAction\'/></menu><menu name=\'HelpAction\' action=\'HelpAction\'><menu nam" +
			"e=\'FAQAction\' action=\'FAQAction\'><menuitem name=\'WhatIsThisAction\' action=\'WhatI" +
			"sThisAction\'/><menuitem name=\'WhatDoIDoAction\' action=\'WhatDoIDoAction\'/><menuit" +
			"em name=\'WhyCantUseFeatureAction\' action=\'WhyCantUseFeatureAction\'/></menu><menu" +
			"item name=\'aboutAction\' action=\'aboutAction\'/></menu></menubar></ui>");
			this.menubarMenu = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubarMenu")));
			this.menubarMenu.Name = "menubarMenu";
			this.vboxMenu.Add (this.menubarMenu);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vboxMenu [this.menubarMenu]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vboxMenu.Gtk.Box+BoxChild
			this.hboxButtons = new global::Gtk.HBox ();
			this.hboxButtons.Name = "hboxButtons";
			this.hboxButtons.Spacing = 8;
			this.hboxButtons.BorderWidth = ((uint)(16));
			// Container child hboxButtons.Gtk.Box+BoxChild
			this.btnQuickSale = new global::Gtk.Button ();
			this.btnQuickSale.WidthRequest = 130;
			this.btnQuickSale.HeightRequest = 130;
			this.btnQuickSale.CanFocus = true;
			this.btnQuickSale.Name = "btnQuickSale";
			this.btnQuickSale.Label = "Quick\r\nSale";
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.tag-sale-icon.png");
			this.btnQuickSale.Image = w3;
			this.hboxButtons.Add (this.btnQuickSale);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxButtons [this.btnQuickSale]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hboxButtons.Gtk.Box+BoxChild
			this.btnAuctionSale = new global::Gtk.Button ();
			this.btnAuctionSale.WidthRequest = 130;
			this.btnAuctionSale.HeightRequest = 130;
			this.btnAuctionSale.CanFocus = true;
			this.btnAuctionSale.Name = "btnAuctionSale";
			this.btnAuctionSale.UseUnderline = true;
			this.btnAuctionSale.Label = global::Mono.Unix.Catalog.GetString ("Auction\r\nSale");
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.shopping-bag-icon.png");
			this.btnAuctionSale.Image = w5;
			this.hboxButtons.Add (this.btnAuctionSale);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hboxButtons [this.btnAuctionSale]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hboxButtons.Gtk.Box+BoxChild
			this.btnGalleryStoreSale = new global::Gtk.Button ();
			this.btnGalleryStoreSale.WidthRequest = 130;
			this.btnGalleryStoreSale.HeightRequest = 130;
			this.btnGalleryStoreSale.CanFocus = true;
			this.btnGalleryStoreSale.Name = "btnGalleryStoreSale";
			this.btnGalleryStoreSale.UseUnderline = true;
			this.btnGalleryStoreSale.Label = "Gallery\r\nStore\r\nSale";
			global::Gtk.Image w7 = new global::Gtk.Image ();
			w7.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.shopping-basket-icon.png");
			this.btnGalleryStoreSale.Image = w7;
			this.hboxButtons.Add (this.btnGalleryStoreSale);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hboxButtons [this.btnGalleryStoreSale]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			this.vboxMenu.Add (this.hboxButtons);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vboxMenu [this.hboxButtons]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vboxMenu.Gtk.Box+BoxChild
			this.hboxLogout = new global::Gtk.HBox ();
			this.hboxLogout.Name = "hboxLogout";
			this.hboxLogout.Spacing = 8;
			this.hboxLogout.BorderWidth = ((uint)(16));
			// Container child hboxLogout.Gtk.Box+BoxChild
			this.btnLogout = new global::Gtk.Button ();
			this.btnLogout.WidthRequest = 394;
			this.btnLogout.CanFocus = true;
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.UseUnderline = true;
			this.btnLogout.Label = global::Mono.Unix.Catalog.GetString ("Logout");
			this.hboxLogout.Add (this.btnLogout);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hboxLogout [this.btnLogout]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			this.vboxMenu.Add (this.hboxLogout);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vboxMenu [this.hboxLogout]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vboxMenu.Gtk.Box+BoxChild
			this.lblGreeting = new global::Gtk.Label ();
			this.lblGreeting.Name = "lblGreeting";
			this.lblGreeting.Xpad = 8;
			this.lblGreeting.Xalign = 0F;
			this.lblGreeting.LabelProp = global::Mono.Unix.Catalog.GetString ("lblGreeting");
			this.vboxMenu.Add (this.lblGreeting);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vboxMenu [this.lblGreeting]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			w12.Padding = ((uint)(8));
			this.Add (this.vboxMenu);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 438;
			this.DefaultHeight = 307;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.addUserAction.Activated += new global::System.EventHandler (this.OnAddUserActionActivated);
			this.closeAction.Activated += new global::System.EventHandler (this.OnExitActionActivated);
			this.quitAction.Activated += new global::System.EventHandler (this.OnQuitActionActivated);
			this.reprintReceiptsAction.Activated += new global::System.EventHandler (this.OnReprintReceiptsActionActivated);
			this.btnQuickSale.Clicked += new global::System.EventHandler (this.OnBtnQuickSaleClicked);
			this.btnAuctionSale.Clicked += new global::System.EventHandler (this.OnBtnAuctionSaleClicked);
			this.btnGalleryStoreSale.Clicked += new global::System.EventHandler (this.OnBtnGalleryStoreSaleClicked);
			this.btnLogout.Clicked += new global::System.EventHandler (this.OnBtnLogoutClicked);
		}
	}
}
