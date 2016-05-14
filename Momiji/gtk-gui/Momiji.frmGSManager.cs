
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmGSManager
	{
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.NodeView lstMerch;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Table table1;
		
		private global::Gtk.Label lblArtistID;
		
		private global::Gtk.Label lblArtistName;
		
		private global::Gtk.Label lblLabelArtistID;
		
		private global::Gtk.Label lblLabelArtistName;
		
		private global::Gtk.CheckButton chkAPP;
		
		private global::Gtk.Frame frame1;
		
		private global::Gtk.Alignment GtkAlignment;
		
		private global::Gtk.VBox vbox4;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Label lblPieceID;
		
		private global::Gtk.Entry txtPieceID;
		
		private global::Gtk.Button btnGenID;
		
		private global::Gtk.HBox hbox4;
		
		private global::Gtk.Label lblPieceTitle;
		
		private global::Gtk.Entry txtPieceTitle;
		
		private global::Gtk.HBox hbox5;
		
		private global::Gtk.Label lblPricePerUnit;
		
		private global::Gtk.Entry txtPricePerUnit;
		
		private global::Gtk.HBox hbox6;
		
		private global::Gtk.Label lblGivenStock;
		
		private global::Gtk.Entry txtGivenStock;
		
		private global::Gtk.CheckButton chkSDC;
		
		private global::Gtk.Table table2;
		
		private global::Gtk.Button btnAdd;
		
		private global::Gtk.Button btnClear;
		
		private global::Gtk.Button btnDelete;
		
		private global::Gtk.Button btnUpdate;
		
		private global::Gtk.Button btnGenBarcode;
		
		private global::Gtk.Label lblPieceInfo;
		
		private global::Gtk.Button btnGenCS;
		
		private global::Gtk.Button btnCancel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmGSManager
			this.WidthRequest = 800;
			this.Name = "Momiji.frmGSManager";
			this.Title = global::Mono.Unix.Catalog.GetString ("GS Manager");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Container child Momiji.frmGSManager.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			this.hbox2.BorderWidth = ((uint)(8));
			// Container child hbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.lstMerch = new global::Gtk.NodeView ();
			this.lstMerch.CanFocus = true;
			this.lstMerch.Name = "lstMerch";
			this.lstMerch.EnableSearch = false;
			this.GtkScrolledWindow.Add (this.lstMerch);
			this.hbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.lblArtistID = new global::Gtk.Label ();
			this.lblArtistID.Name = "lblArtistID";
			this.lblArtistID.LabelProp = global::Mono.Unix.Catalog.GetString ("lblArtistID");
			this.table1.Add (this.lblArtistID);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblArtistID]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblArtistName = new global::Gtk.Label ();
			this.lblArtistName.Name = "lblArtistName";
			this.lblArtistName.LabelProp = global::Mono.Unix.Catalog.GetString ("lblArtistName");
			this.table1.Add (this.lblArtistName);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblArtistName]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblLabelArtistID = new global::Gtk.Label ();
			this.lblLabelArtistID.Name = "lblLabelArtistID";
			this.lblLabelArtistID.Xalign = 1F;
			this.lblLabelArtistID.LabelProp = global::Mono.Unix.Catalog.GetString ("Artist ID :");
			this.table1.Add (this.lblLabelArtistID);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblLabelArtistID]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblLabelArtistName = new global::Gtk.Label ();
			this.lblLabelArtistName.Name = "lblLabelArtistName";
			this.lblLabelArtistName.Xalign = 1F;
			this.lblLabelArtistName.LabelProp = global::Mono.Unix.Catalog.GetString ("Artist Name :");
			this.table1.Add (this.lblLabelArtistName);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblLabelArtistName]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox3.Add (this.table1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.table1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.chkAPP = new global::Gtk.CheckButton ();
			this.chkAPP.CanFocus = true;
			this.chkAPP.Name = "chkAPP";
			this.chkAPP.Label = global::Mono.Unix.Catalog.GetString ("Accredited Press Photography");
			this.chkAPP.DrawIndicator = true;
			this.chkAPP.UseUnderline = true;
			this.vbox3.Add (this.chkAPP);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.chkAPP]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(1));
			this.frame1.BorderWidth = ((uint)(8));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			this.vbox4.BorderWidth = ((uint)(8));
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.lblPieceID = new global::Gtk.Label ();
			this.lblPieceID.Name = "lblPieceID";
			this.lblPieceID.LabelProp = global::Mono.Unix.Catalog.GetString ("Piece ID:");
			this.hbox3.Add (this.lblPieceID);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.lblPieceID]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.txtPieceID = new global::Gtk.Entry ();
			this.txtPieceID.CanFocus = true;
			this.txtPieceID.Name = "txtPieceID";
			this.txtPieceID.IsEditable = true;
			this.txtPieceID.WidthChars = 3;
			this.txtPieceID.MaxLength = 3;
			this.txtPieceID.InvisibleChar = '●';
			this.hbox3.Add (this.txtPieceID);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.txtPieceID]));
			w10.Position = 1;
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnGenID = new global::Gtk.Button ();
			this.btnGenID.CanFocus = true;
			this.btnGenID.Name = "btnGenID";
			this.btnGenID.UseUnderline = true;
			this.btnGenID.Label = global::Mono.Unix.Catalog.GetString ("Generate ID");
			global::Gtk.Image w11 = new global::Gtk.Image ();
			w11.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-execute", global::Gtk.IconSize.Menu);
			this.btnGenID.Image = w11;
			this.hbox3.Add (this.btnGenID);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.btnGenID]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.vbox4.Add (this.hbox3);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox3]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.lblPieceTitle = new global::Gtk.Label ();
			this.lblPieceTitle.Name = "lblPieceTitle";
			this.lblPieceTitle.LabelProp = global::Mono.Unix.Catalog.GetString ("Piece Title:");
			this.hbox4.Add (this.lblPieceTitle);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.lblPieceTitle]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.txtPieceTitle = new global::Gtk.Entry ();
			this.txtPieceTitle.CanFocus = true;
			this.txtPieceTitle.Name = "txtPieceTitle";
			this.txtPieceTitle.IsEditable = true;
			this.txtPieceTitle.InvisibleChar = '●';
			this.hbox4.Add (this.txtPieceTitle);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.txtPieceTitle]));
			w15.Position = 1;
			this.vbox4.Add (this.hbox4);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox4]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.lblPricePerUnit = new global::Gtk.Label ();
			this.lblPricePerUnit.Name = "lblPricePerUnit";
			this.lblPricePerUnit.LabelProp = global::Mono.Unix.Catalog.GetString ("Price Per Unit:");
			this.hbox5.Add (this.lblPricePerUnit);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.lblPricePerUnit]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.txtPricePerUnit = new global::Gtk.Entry ();
			this.txtPricePerUnit.CanFocus = true;
			this.txtPricePerUnit.Name = "txtPricePerUnit";
			this.txtPricePerUnit.IsEditable = true;
			this.txtPricePerUnit.InvisibleChar = '●';
			this.hbox5.Add (this.txtPricePerUnit);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.txtPricePerUnit]));
			w18.Position = 1;
			this.vbox4.Add (this.hbox5);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox5]));
			w19.Position = 2;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.lblGivenStock = new global::Gtk.Label ();
			this.lblGivenStock.Name = "lblGivenStock";
			this.lblGivenStock.LabelProp = global::Mono.Unix.Catalog.GetString ("Initial Stock:");
			this.hbox6.Add (this.lblGivenStock);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.lblGivenStock]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.txtGivenStock = new global::Gtk.Entry ();
			this.txtGivenStock.CanFocus = true;
			this.txtGivenStock.Name = "txtGivenStock";
			this.txtGivenStock.IsEditable = true;
			this.txtGivenStock.InvisibleChar = '●';
			this.hbox6.Add (this.txtGivenStock);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.txtGivenStock]));
			w21.Position = 1;
			this.vbox4.Add (this.hbox6);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox6]));
			w22.Position = 3;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.chkSDC = new global::Gtk.CheckButton ();
			this.chkSDC.CanFocus = true;
			this.chkSDC.Name = "chkSDC";
			this.chkSDC.Label = global::Mono.Unix.Catalog.GetString ("Sell Display Copy?");
			this.chkSDC.DrawIndicator = true;
			this.chkSDC.UseUnderline = true;
			this.vbox4.Add (this.chkSDC);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.chkSDC]));
			w23.Position = 4;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.table2 = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.btnAdd = new global::Gtk.Button ();
			this.btnAdd.CanFocus = true;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.UseUnderline = true;
			this.btnAdd.Label = global::Mono.Unix.Catalog.GetString ("Add");
			global::Gtk.Image w24 = new global::Gtk.Image ();
			w24.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			this.btnAdd.Image = w24;
			this.table2.Add (this.btnAdd);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table2 [this.btnAdd]));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.btnClear = new global::Gtk.Button ();
			this.btnClear.CanFocus = true;
			this.btnClear.Name = "btnClear";
			this.btnClear.UseUnderline = true;
			this.btnClear.Label = global::Mono.Unix.Catalog.GetString ("Clear");
			global::Gtk.Image w26 = new global::Gtk.Image ();
			w26.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.btnClear.Image = w26;
			this.table2.Add (this.btnClear);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.table2 [this.btnClear]));
			w27.TopAttach = ((uint)(1));
			w27.BottomAttach = ((uint)(2));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.btnDelete = new global::Gtk.Button ();
			this.btnDelete.CanFocus = true;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.UseUnderline = true;
			this.btnDelete.Label = global::Mono.Unix.Catalog.GetString ("Delete");
			global::Gtk.Image w28 = new global::Gtk.Image ();
			w28.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.btnDelete.Image = w28;
			this.table2.Add (this.btnDelete);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table2 [this.btnDelete]));
			w29.TopAttach = ((uint)(1));
			w29.BottomAttach = ((uint)(2));
			w29.LeftAttach = ((uint)(1));
			w29.RightAttach = ((uint)(2));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.btnUpdate = new global::Gtk.Button ();
			this.btnUpdate.CanFocus = true;
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.UseUnderline = true;
			this.btnUpdate.Label = global::Mono.Unix.Catalog.GetString ("Update");
			global::Gtk.Image w30 = new global::Gtk.Image ();
			w30.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.btnUpdate.Image = w30;
			this.table2.Add (this.btnUpdate);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table2 [this.btnUpdate]));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox4.Add (this.table2);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.table2]));
			w32.Position = 5;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.btnGenBarcode = new global::Gtk.Button ();
			this.btnGenBarcode.CanFocus = true;
			this.btnGenBarcode.Name = "btnGenBarcode";
			this.btnGenBarcode.UseUnderline = true;
			this.btnGenBarcode.Label = global::Mono.Unix.Catalog.GetString ("Generate Barcode");
			global::Gtk.Image w33 = new global::Gtk.Image ();
			w33.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-execute", global::Gtk.IconSize.Menu);
			this.btnGenBarcode.Image = w33;
			this.vbox4.Add (this.btnGenBarcode);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.btnGenBarcode]));
			w34.Position = 6;
			w34.Expand = false;
			w34.Fill = false;
			this.GtkAlignment.Add (this.vbox4);
			this.frame1.Add (this.GtkAlignment);
			this.lblPieceInfo = new global::Gtk.Label ();
			this.lblPieceInfo.Name = "lblPieceInfo";
			this.lblPieceInfo.LabelProp = global::Mono.Unix.Catalog.GetString ("Piece Info:");
			this.lblPieceInfo.UseMarkup = true;
			this.frame1.LabelWidget = this.lblPieceInfo;
			this.vbox3.Add (this.frame1);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.frame1]));
			w37.Position = 2;
			w37.Expand = false;
			w37.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnGenCS = new global::Gtk.Button ();
			this.btnGenCS.CanFocus = true;
			this.btnGenCS.Name = "btnGenCS";
			this.btnGenCS.UseUnderline = true;
			this.btnGenCS.Label = global::Mono.Unix.Catalog.GetString ("Generate Control Sheet");
			global::Gtk.Image w38 = new global::Gtk.Image ();
			w38.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-execute", global::Gtk.IconSize.Menu);
			this.btnGenCS.Image = w38;
			this.vbox3.Add (this.btnGenCS);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnGenCS]));
			w39.Position = 3;
			w39.Expand = false;
			w39.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString ("Cancel");
			global::Gtk.Image w40 = new global::Gtk.Image ();
			w40.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-close", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w40;
			this.vbox3.Add (this.btnCancel);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnCancel]));
			w41.Position = 4;
			w41.Expand = false;
			w41.Fill = false;
			this.hbox2.Add (this.vbox3);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vbox3]));
			w42.Position = 1;
			w42.Expand = false;
			w42.Fill = false;
			w42.Padding = ((uint)(8));
			this.Add (this.hbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 800;
			this.DefaultHeight = 532;
			this.Show ();
			this.lstMerch.RowActivated += new global::Gtk.RowActivatedHandler (this.OnLstMerchRowActivated);
			this.txtPieceID.Changed += new global::System.EventHandler (this.OnTxtPieceIDChanged);
			this.btnGenID.Clicked += new global::System.EventHandler (this.OnBtnGenIDClicked);
			this.btnUpdate.Clicked += new global::System.EventHandler (this.OnBtnUpdateClicked);
			this.btnDelete.Clicked += new global::System.EventHandler (this.OnBtnDeleteClicked);
			this.btnClear.Clicked += new global::System.EventHandler (this.OnBtnClearClicked);
			this.btnAdd.Clicked += new global::System.EventHandler (this.OnBtnAddClicked);
			this.btnGenBarcode.Clicked += new global::System.EventHandler (this.OnBtnGenBarcodeClicked);
			this.btnGenCS.Clicked += new global::System.EventHandler (this.OnBtnGenCSClicked);
			this.btnCancel.Clicked += new global::System.EventHandler (this.OnBtnCancelClicked);
		}
	}
}
