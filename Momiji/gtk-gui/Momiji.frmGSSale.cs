
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmGSSale
	{
		private global::Gtk.HBox hboxCheckin;
		
		private global::Gtk.ScrolledWindow GtkScrolWinMerch;
		
		private global::Gtk.NodeView lstMerch;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Label lblBarcode;
		
		private global::Gtk.Entry txtBarcode;
		
		private global::Gtk.ComboBox drpPaymentType;
		
		private global::Gtk.Table table1;
		
		private global::Gtk.Label lblPaid;
		
		private global::Gtk.Label lblTotal;
		
		private global::Gtk.Entry txtPaid;
		
		private global::Gtk.Entry txtTotal;
		
		private global::Gtk.Fixed fixedPay;
		
		private global::Gtk.Button btnPay;
		
		private global::Gtk.Image imgPay;
		
		private global::Gtk.HBox hbox3;
		
		private global::Gtk.Label lblChange;
		
		private global::Gtk.Entry txtChange;
		
		private global::Gtk.Button btnPrintReceipt;
		
		private global::Gtk.Button btnCancel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmGSSale
			this.WidthRequest = 800;
			this.Name = "Momiji.frmGSSale";
			this.Title = global::Mono.Unix.Catalog.GetString ("Gallery Store Sale");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.shopping-basket-icon.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmGSSale.Gtk.Container+ContainerChild
			this.hboxCheckin = new global::Gtk.HBox ();
			this.hboxCheckin.Name = "hboxCheckin";
			this.hboxCheckin.Spacing = 6;
			// Container child hboxCheckin.Gtk.Box+BoxChild
			this.GtkScrolWinMerch = new global::Gtk.ScrolledWindow ();
			this.GtkScrolWinMerch.Name = "GtkScrolWinMerch";
			this.GtkScrolWinMerch.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolWinMerch.Gtk.Container+ContainerChild
			this.lstMerch = new global::Gtk.NodeView ();
			this.lstMerch.CanFocus = true;
			this.lstMerch.Name = "lstMerch";
			this.lstMerch.EnableSearch = false;
			this.GtkScrolWinMerch.Add (this.lstMerch);
			this.hboxCheckin.Add (this.GtkScrolWinMerch);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxCheckin [this.GtkScrolWinMerch]));
			w2.Position = 0;
			// Container child hboxCheckin.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(8));
			// Container child vbox2.Gtk.Box+BoxChild
			this.lblBarcode = new global::Gtk.Label ();
			this.lblBarcode.Name = "lblBarcode";
			this.lblBarcode.Xalign = 0F;
			this.lblBarcode.LabelProp = global::Mono.Unix.Catalog.GetString ("Highlight this box and scan:");
			this.vbox2.Add (this.lblBarcode);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.lblBarcode]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.txtBarcode = new global::Gtk.Entry ();
			this.txtBarcode.CanFocus = true;
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.IsEditable = true;
			this.txtBarcode.InvisibleChar = '●';
			this.vbox2.Add (this.txtBarcode);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.txtBarcode]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.drpPaymentType = global::Gtk.ComboBox.NewText ();
			this.drpPaymentType.AppendText (global::Mono.Unix.Catalog.GetString ("Cash"));
			this.drpPaymentType.AppendText (global::Mono.Unix.Catalog.GetString ("Credit"));
			this.drpPaymentType.Name = "drpPaymentType";
			this.drpPaymentType.Active = 0;
			this.vbox2.Add (this.drpPaymentType);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.drpPaymentType]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.lblPaid = new global::Gtk.Label ();
			this.lblPaid.Name = "lblPaid";
			this.lblPaid.Xalign = 0F;
			this.lblPaid.LabelProp = global::Mono.Unix.Catalog.GetString ("Paid: <b>$</b>");
			this.lblPaid.UseMarkup = true;
			this.table1.Add (this.lblPaid);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblPaid]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblTotal = new global::Gtk.Label ();
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.LabelProp = global::Mono.Unix.Catalog.GetString ("Total: <b>$</b>");
			this.lblTotal.UseMarkup = true;
			this.table1.Add (this.lblTotal);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblTotal]));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtPaid = new global::Gtk.Entry ();
			this.txtPaid.CanFocus = true;
			this.txtPaid.Name = "txtPaid";
			this.txtPaid.IsEditable = true;
			this.txtPaid.InvisibleChar = '●';
			this.table1.Add (this.txtPaid);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.txtPaid]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtTotal = new global::Gtk.Entry ();
			this.txtTotal.Sensitive = false;
			this.txtTotal.CanFocus = true;
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.IsEditable = false;
			this.txtTotal.InvisibleChar = '●';
			this.table1.Add (this.txtTotal);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.txtTotal]));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add (this.table1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.table1]));
			w10.Position = 3;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixedPay = new global::Gtk.Fixed ();
			this.fixedPay.WidthRequest = 256;
			this.fixedPay.HeightRequest = 96;
			this.fixedPay.Name = "fixedPay";
			this.fixedPay.HasWindow = false;
			// Container child fixedPay.Gtk.Fixed+FixedChild
			this.btnPay = new global::Gtk.Button ();
			this.btnPay.WidthRequest = 256;
			this.btnPay.HeightRequest = 96;
			this.btnPay.CanFocus = true;
			this.btnPay.Name = "btnPay";
			this.btnPay.UseUnderline = true;
			this.btnPay.Xalign = 0.75F;
			this.btnPay.Label = global::Mono.Unix.Catalog.GetString ("Mark as Paid");
			this.fixedPay.Add (this.btnPay);
			// Container child fixedPay.Gtk.Fixed+FixedChild
			this.imgPay = new global::Gtk.Image ();
			this.imgPay.Name = "imgPay";
			this.imgPay.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.shopping-basket-icon.png");
			this.fixedPay.Add (this.imgPay);
			global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixedPay [this.imgPay]));
			w12.X = 32;
			w12.Y = 16;
			this.vbox2.Add (this.fixedPay);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.fixedPay]));
			w13.Position = 4;
			w13.Expand = false;
			w13.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.lblChange = new global::Gtk.Label ();
			this.lblChange.Name = "lblChange";
			this.lblChange.LabelProp = global::Mono.Unix.Catalog.GetString ("Change: <b>$</b>");
			this.lblChange.UseMarkup = true;
			this.hbox3.Add (this.lblChange);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.lblChange]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.txtChange = new global::Gtk.Entry ();
			this.txtChange.Sensitive = false;
			this.txtChange.CanFocus = true;
			this.txtChange.Name = "txtChange";
			this.txtChange.IsEditable = false;
			this.txtChange.InvisibleChar = '●';
			this.hbox3.Add (this.txtChange);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.txtChange]));
			w15.Position = 1;
			this.vbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox3]));
			w16.Position = 5;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnPrintReceipt = new global::Gtk.Button ();
			this.btnPrintReceipt.CanFocus = true;
			this.btnPrintReceipt.Name = "btnPrintReceipt";
			this.btnPrintReceipt.UseUnderline = true;
			this.btnPrintReceipt.Label = global::Mono.Unix.Catalog.GetString ("Print Receipt");
			global::Gtk.Image w17 = new global::Gtk.Image ();
			w17.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-print", global::Gtk.IconSize.Menu);
			this.btnPrintReceipt.Image = w17;
			this.vbox2.Add (this.btnPrintReceipt);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btnPrintReceipt]));
			w18.Position = 6;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString ("Clear Transaction");
			global::Gtk.Image w19 = new global::Gtk.Image ();
			w19.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w19;
			this.vbox2.Add (this.btnCancel);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btnCancel]));
			w20.Position = 7;
			w20.Expand = false;
			w20.Fill = false;
			w20.Padding = ((uint)(8));
			this.hboxCheckin.Add (this.vbox2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hboxCheckin [this.vbox2]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			w21.Padding = ((uint)(8));
			this.Add (this.hboxCheckin);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 800;
			this.DefaultHeight = 452;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.txtBarcode.Activated += new global::System.EventHandler (this.OnTxtBarcodeActivated);
			this.drpPaymentType.Changed += new global::System.EventHandler (this.OnDrpPaymentTypeChanged);
			this.txtPaid.Activated += new global::System.EventHandler (this.OnTxtPaidActivated);
			this.btnPay.Clicked += new global::System.EventHandler (this.OnBtnPayClicked);
			this.btnPrintReceipt.Clicked += new global::System.EventHandler (this.OnBtnPrintReceiptClicked);
			this.btnCancel.Clicked += new global::System.EventHandler (this.OnBtnCancelClicked);
		}
	}
}
