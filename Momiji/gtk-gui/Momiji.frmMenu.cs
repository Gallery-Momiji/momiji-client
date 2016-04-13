
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmMenu
	{
		private global::Gtk.UIManager UIManager;
		
		private global::Gtk.Action FileAction;
		
		private global::Gtk.Action ArtistsAction;
		
		private global::Gtk.Action ToolsAction;
		
		private global::Gtk.Action PreferencesAction;
		
		private global::Gtk.Action HelpAction;
		
		private global::Gtk.Action aboutAction;
		
		private global::Gtk.Action closeAction;
		
		private global::Gtk.Action quitAction;
		
		private global::Gtk.Action checkInAction;
		
		private global::Gtk.Action checkOutAction;
		
		private global::Gtk.Action manageArtistAction;
		
		private global::Gtk.Action addArtistAction;
		
		private global::Gtk.Action editArtistAction;
		
		private global::Gtk.Action editMerchandiseAction;
		
		private global::Gtk.Action editGalleryStoreMerchandiseAction;
		
		private global::Gtk.Action manageArtistBalanceAction;
		
		private global::Gtk.Action checkSalesAction;
		
		private global::Gtk.Action refundAction;
		
		private global::Gtk.Action reprintReceiptAction;
		
		private global::Gtk.Action checkReceiptsAction;
		
		private global::Gtk.Action checkUserActivitiesAction;
		
		private global::Gtk.Action generateBiddingSheetsAction;
		
		private global::Gtk.Action userPreferencesAction;
		
		private global::Gtk.Action pricingAction;
		
		private global::Gtk.Action biddersAction;
		
		private global::Gtk.Action usersPrefAction;
		
		private global::Gtk.Action addUserAction;
		
		private global::Gtk.Action editUserAction;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.MenuBar mainMenubar;
		
		private global::Gtk.HBox hbox8;
		
		private global::Gtk.Fixed fixedQuickSale;
		
		private global::Gtk.Button btnQuickSale;
		
		private global::Gtk.Image imgQuickSale;
		
		private global::Gtk.Fixed fixedAuctionSale;
		
		private global::Gtk.Button btnAuctionSale;
		
		private global::Gtk.Image imgAuctionSale;
		
		private global::Gtk.Fixed fixedGalleryStoreSale;
		
		private global::Gtk.Button btnGalleryStoreSale;
		
		private global::Gtk.Image imgGalleryStoreSale;
		
		private global::Gtk.HBox hbox9;
		
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
			this.ToolsAction = new global::Gtk.Action ("ToolsAction", global::Mono.Unix.Catalog.GetString ("Tools"), null, null);
			this.ToolsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Tools");
			w1.Add (this.ToolsAction, null);
			this.PreferencesAction = new global::Gtk.Action ("PreferencesAction", global::Mono.Unix.Catalog.GetString ("Preferences"), null, null);
			this.PreferencesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Preferences");
			w1.Add (this.PreferencesAction, null);
			this.HelpAction = new global::Gtk.Action ("HelpAction", global::Mono.Unix.Catalog.GetString ("Help"), null, null);
			this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Help");
			w1.Add (this.HelpAction, null);
			this.aboutAction = new global::Gtk.Action ("aboutAction", global::Mono.Unix.Catalog.GetString ("About"), null, "gtk-about");
			this.aboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("About");
			w1.Add (this.aboutAction, null);
			this.closeAction = new global::Gtk.Action ("closeAction", global::Mono.Unix.Catalog.GetString ("Logout"), null, "gtk-close");
			this.closeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Logout");
			w1.Add (this.closeAction, null);
			this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("Quit"), null, "gtk-quit");
			this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Quit");
			w1.Add (this.quitAction, null);
			this.checkInAction = new global::Gtk.Action ("checkInAction", global::Mono.Unix.Catalog.GetString ("Check In"), null, "gtk-yes");
			this.checkInAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check In");
			w1.Add (this.checkInAction, null);
			this.checkOutAction = new global::Gtk.Action ("checkOutAction", global::Mono.Unix.Catalog.GetString ("Check Out"), null, "gtk-no");
			this.checkOutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check Out");
			w1.Add (this.checkOutAction, null);
			this.manageArtistAction = new global::Gtk.Action ("manageArtistAction", global::Mono.Unix.Catalog.GetString ("Manage"), null, "gtk-execute");
			this.manageArtistAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Manage");
			w1.Add (this.manageArtistAction, null);
			this.addArtistAction = new global::Gtk.Action ("addArtistAction", global::Mono.Unix.Catalog.GetString ("Add Artist"), null, "gtk-add");
			this.addArtistAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Add Artist");
			w1.Add (this.addArtistAction, null);
			this.editArtistAction = new global::Gtk.Action ("editArtistAction", global::Mono.Unix.Catalog.GetString ("Edit Artist"), null, "gtk-preferences");
			this.editArtistAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Artist");
			w1.Add (this.editArtistAction, null);
			this.editMerchandiseAction = new global::Gtk.Action ("editMerchandiseAction", global::Mono.Unix.Catalog.GetString ("Edit Merchandise"), null, "gtk-dnd");
			this.editMerchandiseAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Merchandise");
			w1.Add (this.editMerchandiseAction, null);
			this.editGalleryStoreMerchandiseAction = new global::Gtk.Action ("editGalleryStoreMerchandiseAction", global::Mono.Unix.Catalog.GetString ("Edit Gallery Store Merchandise"), null, "gtk-dnd-multiple");
			this.editGalleryStoreMerchandiseAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit Gallery Store Merchandise");
			w1.Add (this.editGalleryStoreMerchandiseAction, null);
			this.manageArtistBalanceAction = new global::Gtk.Action ("manageArtistBalanceAction", global::Mono.Unix.Catalog.GetString ("Manage Artist Balance"), null, "gtk-convert");
			this.manageArtistBalanceAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Manage Artist Balance");
			w1.Add (this.manageArtistBalanceAction, null);
			this.checkSalesAction = new global::Gtk.Action ("checkSalesAction", global::Mono.Unix.Catalog.GetString ("Check Sales"), null, "gtk-file");
			this.checkSalesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check Sales");
			w1.Add (this.checkSalesAction, null);
			this.refundAction = new global::Gtk.Action ("refundAction", global::Mono.Unix.Catalog.GetString ("Refund"), null, "gtk-undo");
			this.refundAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Refund");
			w1.Add (this.refundAction, null);
			this.reprintReceiptAction = new global::Gtk.Action ("reprintReceiptAction", global::Mono.Unix.Catalog.GetString ("Reprint Receipt"), null, "gtk-print");
			this.reprintReceiptAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Reprint Receipt");
			w1.Add (this.reprintReceiptAction, null);
			this.checkReceiptsAction = new global::Gtk.Action ("checkReceiptsAction", global::Mono.Unix.Catalog.GetString ("Check Receipts"), null, "gtk-print-preview");
			this.checkReceiptsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check Receipts");
			w1.Add (this.checkReceiptsAction, null);
			this.checkUserActivitiesAction = new global::Gtk.Action ("checkUserActivitiesAction", global::Mono.Unix.Catalog.GetString ("Check User Activities"), null, "gtk-revert-to-saved");
			this.checkUserActivitiesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Check User Activities");
			w1.Add (this.checkUserActivitiesAction, null);
			this.generateBiddingSheetsAction = new global::Gtk.Action ("generateBiddingSheetsAction", global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets"), null, "gtk-properties");
			this.generateBiddingSheetsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Generate Bidding Sheets");
			w1.Add (this.generateBiddingSheetsAction, null);
			this.userPreferencesAction = new global::Gtk.Action ("userPreferencesAction", global::Mono.Unix.Catalog.GetString ("User Preferences"), null, "gtk-preferences");
			this.userPreferencesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("User Preferences");
			w1.Add (this.userPreferencesAction, null);
			this.pricingAction = new global::Gtk.Action ("pricingAction", global::Mono.Unix.Catalog.GetString ("Pricing"), null, "gtk-properties");
			this.pricingAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Pricing");
			w1.Add (this.pricingAction, null);
			this.biddersAction = new global::Gtk.Action ("biddersAction", global::Mono.Unix.Catalog.GetString ("Bidders"), null, "gtk-select-color");
			this.biddersAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Bidders");
			w1.Add (this.biddersAction, null);
			this.usersPrefAction = new global::Gtk.Action ("usersPrefAction", global::Mono.Unix.Catalog.GetString ("Users"), null, "gtk-index");
			this.usersPrefAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Users");
			w1.Add (this.usersPrefAction, null);
			this.addUserAction = new global::Gtk.Action ("addUserAction", global::Mono.Unix.Catalog.GetString ("Add User"), null, "gtk-add");
			this.addUserAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Add User");
			w1.Add (this.addUserAction, null);
			this.editUserAction = new global::Gtk.Action ("editUserAction", global::Mono.Unix.Catalog.GetString ("Edit User"), null, "gtk-preferences");
			this.editUserAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit User");
			w1.Add (this.editUserAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "Momiji.frmMenu";
			this.Title = global::Mono.Unix.Catalog.GetString ("Gallery Momiji Point-Of-Sale");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.Crystal-Star-256.ico");
			this.WindowPosition = ((global::Gtk.WindowPosition)(3));
			this.Resizable = false;
			this.AllowGrow = false;
			// Container child Momiji.frmMenu.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 8;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name=\'mainMenubar\'><menu name=\'FileAction\' action=\'FileAction\'><menu" +
			"item name=\'closeAction\' action=\'closeAction\'/><menuitem name=\'quitAction\' action" +
			"=\'quitAction\'/></menu><menu name=\'ArtistsAction\' action=\'ArtistsAction\'><menuite" +
			"m name=\'checkInAction\' action=\'checkInAction\'/><menuitem name=\'checkOutAction\' a" +
			"ction=\'checkOutAction\'/><menu name=\'manageArtistAction\' action=\'manageArtistActi" +
			"on\'><menuitem name=\'addArtistAction\' action=\'addArtistAction\'/><menuitem name=\'e" +
			"ditArtistAction\' action=\'editArtistAction\'/><menuitem name=\'editMerchandiseActio" +
			"n\' action=\'editMerchandiseAction\'/><menuitem name=\'editGalleryStoreMerchandiseAc" +
			"tion\' action=\'editGalleryStoreMerchandiseAction\'/><menuitem name=\'manageArtistBa" +
			"lanceAction\' action=\'manageArtistBalanceAction\'/></menu></menu><menu name=\'Tools" +
			"Action\' action=\'ToolsAction\'><menuitem name=\'checkSalesAction\' action=\'checkSale" +
			"sAction\'/><menuitem name=\'refundAction\' action=\'refundAction\'/><menuitem name=\'r" +
			"eprintReceiptAction\' action=\'reprintReceiptAction\'/><menuitem name=\'checkReceipt" +
			"sAction\' action=\'checkReceiptsAction\'/><menuitem name=\'checkUserActivitiesAction" +
			"\' action=\'checkUserActivitiesAction\'/><menuitem name=\'generateBiddingSheetsActio" +
			"n\' action=\'generateBiddingSheetsAction\'/></menu><menu name=\'PreferencesAction\' a" +
			"ction=\'PreferencesAction\'><menuitem name=\'userPreferencesAction\' action=\'userPre" +
			"ferencesAction\'/><menuitem name=\'pricingAction\' action=\'pricingAction\'/><menuite" +
			"m name=\'biddersAction\' action=\'biddersAction\'/><menu name=\'usersPrefAction\' acti" +
			"on=\'usersPrefAction\'><menuitem name=\'addUserAction\' action=\'addUserAction\'/><men" +
			"uitem name=\'editUserAction\' action=\'editUserAction\'/></menu></menu><menu name=\'H" +
			"elpAction\' action=\'HelpAction\'><menuitem name=\'aboutAction\' action=\'aboutAction\'" +
			"/></menu></menubar></ui>");
			this.mainMenubar = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/mainMenubar")));
			this.mainMenubar.Name = "mainMenubar";
			this.vbox2.Add (this.mainMenubar);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.mainMenubar]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 8;
			this.hbox8.BorderWidth = ((uint)(16));
			// Container child hbox8.Gtk.Box+BoxChild
			this.fixedQuickSale = new global::Gtk.Fixed ();
			this.fixedQuickSale.Name = "fixedQuickSale";
			this.fixedQuickSale.HasWindow = false;
			// Container child fixedQuickSale.Gtk.Fixed+FixedChild
			this.btnQuickSale = new global::Gtk.Button ();
			this.btnQuickSale.WidthRequest = 130;
			this.btnQuickSale.HeightRequest = 130;
			this.btnQuickSale.CanFocus = true;
			this.btnQuickSale.Name = "btnQuickSale";
			this.btnQuickSale.UseUnderline = true;
			this.btnQuickSale.Yalign = 1F;
			this.btnQuickSale.Label = global::Mono.Unix.Catalog.GetString ("Quick Sale");
			this.fixedQuickSale.Add (this.btnQuickSale);
			// Container child fixedQuickSale.Gtk.Fixed+FixedChild
			this.imgQuickSale = new global::Gtk.Image ();
			this.imgQuickSale.Name = "imgQuickSale";
			this.imgQuickSale.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.tag-sale-icon.png");
			this.fixedQuickSale.Add (this.imgQuickSale);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixedQuickSale [this.imgQuickSale]));
			w4.X = 33;
			w4.Y = 24;
			this.hbox8.Add (this.fixedQuickSale);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.fixedQuickSale]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.fixedAuctionSale = new global::Gtk.Fixed ();
			this.fixedAuctionSale.Name = "fixedAuctionSale";
			this.fixedAuctionSale.HasWindow = false;
			// Container child fixedAuctionSale.Gtk.Fixed+FixedChild
			this.btnAuctionSale = new global::Gtk.Button ();
			this.btnAuctionSale.WidthRequest = 130;
			this.btnAuctionSale.HeightRequest = 130;
			this.btnAuctionSale.CanFocus = true;
			this.btnAuctionSale.Name = "btnAuctionSale";
			this.btnAuctionSale.UseUnderline = true;
			this.btnAuctionSale.Yalign = 1F;
			this.btnAuctionSale.Label = global::Mono.Unix.Catalog.GetString ("AuctionSale");
			this.fixedAuctionSale.Add (this.btnAuctionSale);
			// Container child fixedAuctionSale.Gtk.Fixed+FixedChild
			this.imgAuctionSale = new global::Gtk.Image ();
			this.imgAuctionSale.Name = "imgAuctionSale";
			this.imgAuctionSale.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.shopping-bag-icon.png");
			this.fixedAuctionSale.Add (this.imgAuctionSale);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixedAuctionSale [this.imgAuctionSale]));
			w7.X = 33;
			w7.Y = 24;
			this.hbox8.Add (this.fixedAuctionSale);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.fixedAuctionSale]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.fixedGalleryStoreSale = new global::Gtk.Fixed ();
			this.fixedGalleryStoreSale.Name = "fixedGalleryStoreSale";
			this.fixedGalleryStoreSale.HasWindow = false;
			// Container child fixedGalleryStoreSale.Gtk.Fixed+FixedChild
			this.btnGalleryStoreSale = new global::Gtk.Button ();
			this.btnGalleryStoreSale.WidthRequest = 130;
			this.btnGalleryStoreSale.HeightRequest = 130;
			this.btnGalleryStoreSale.CanFocus = true;
			this.btnGalleryStoreSale.Name = "btnGalleryStoreSale";
			this.btnGalleryStoreSale.UseUnderline = true;
			this.btnGalleryStoreSale.Yalign = 1F;
			this.btnGalleryStoreSale.Label = global::Mono.Unix.Catalog.GetString ("Gallery Store Sale");
			this.fixedGalleryStoreSale.Add (this.btnGalleryStoreSale);
			// Container child fixedGalleryStoreSale.Gtk.Fixed+FixedChild
			this.imgGalleryStoreSale = new global::Gtk.Image ();
			this.imgGalleryStoreSale.Name = "imgGalleryStoreSale";
			this.imgGalleryStoreSale.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.shopping-basket-icon.png");
			this.fixedGalleryStoreSale.Add (this.imgGalleryStoreSale);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixedGalleryStoreSale [this.imgGalleryStoreSale]));
			w10.X = 33;
			w10.Y = 24;
			this.hbox8.Add (this.fixedGalleryStoreSale);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.fixedGalleryStoreSale]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.vbox2.Add (this.hbox8);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox8]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
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
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox9 [this.btnLogout]));
			w13.Position = 0;
			this.vbox2.Add (this.hbox9);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox9]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.lblGreeting = new global::Gtk.Label ();
			this.lblGreeting.Name = "lblGreeting";
			this.lblGreeting.Xpad = 8;
			this.lblGreeting.Xalign = 0F;
			this.lblGreeting.LabelProp = global::Mono.Unix.Catalog.GetString ("lblGreeting");
			this.vbox2.Add (this.lblGreeting);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.lblGreeting]));
			w15.Position = 3;
			w15.Expand = false;
			w15.Fill = false;
			w15.Padding = ((uint)(8));
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 438;
			this.DefaultHeight = 312;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.aboutAction.Activated += new global::System.EventHandler (this.OnAboutActionActivated);
			this.closeAction.Activated += new global::System.EventHandler (this.OnCloseActionActivated);
			this.quitAction.Activated += new global::System.EventHandler (this.OnQuitActionActivated);
			this.checkInAction.Activated += new global::System.EventHandler (this.OnCheckInActionActivated);
			this.checkOutAction.Activated += new global::System.EventHandler (this.OnCheckOutActionActivated);
			this.addArtistAction.Activated += new global::System.EventHandler (this.OnAddArtistActionActivated);
			this.editArtistAction.Activated += new global::System.EventHandler (this.OnEditArtistActionActivated);
			this.editMerchandiseAction.Activated += new global::System.EventHandler (this.OnEditMerchandiseActionActivated);
			this.editGalleryStoreMerchandiseAction.Activated += new global::System.EventHandler (this.OnEditGalleryStoreMerchandiseActionActivated);
			this.manageArtistBalanceAction.Activated += new global::System.EventHandler (this.OnManageArtistBalanceActionActivated);
			this.checkSalesAction.Activated += new global::System.EventHandler (this.OnCheckSalesActionActivated);
			this.refundAction.Activated += new global::System.EventHandler (this.OnRefundActionActivated);
			this.reprintReceiptAction.Activated += new global::System.EventHandler (this.OnReprintReceiptActionActivated);
			this.checkReceiptsAction.Activated += new global::System.EventHandler (this.OnCheckReceiptsActionActivated);
			this.checkUserActivitiesAction.Activated += new global::System.EventHandler (this.OnCheckUserActivitiesActionActivated);
			this.generateBiddingSheetsAction.Activated += new global::System.EventHandler (this.OnGenerateBiddingSheetsActionActivated);
			this.userPreferencesAction.Activated += new global::System.EventHandler (this.OnUserPreferencesActionActivated);
			this.pricingAction.Activated += new global::System.EventHandler (this.OnPricingActionActivated);
			this.biddersAction.Activated += new global::System.EventHandler (this.OnBiddersActionActivated);
			this.addUserAction.Activated += new global::System.EventHandler (this.OnAddUserActionActivated);
			this.editUserAction.Activated += new global::System.EventHandler (this.OnEditUserActionActivated);
			this.btnQuickSale.Clicked += new global::System.EventHandler (this.OnBtnQuickSaleClicked);
			this.btnAuctionSale.Clicked += new global::System.EventHandler (this.OnBtnAuctionSaleClicked);
			this.btnGalleryStoreSale.Clicked += new global::System.EventHandler (this.OnBtnGalleryStoreSaleClicked);
			this.btnLogout.Clicked += new global::System.EventHandler (this.OnBtnLogoutClicked);
		}
	}
}
