
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmAuctionSale
	{
		private global::Gtk.HBox hboxCheckin;

		private global::Gtk.ScrolledWindow GtkScrolWinMerch;

		private global::Gtk.NodeView lstMerch;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Label lblBarcode;

		private global::Gtk.Entry txtBarcode;

		private global::Gtk.Label lblPrice;

		private global::Gtk.Entry txtPrice;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button btnAddToList;

		private global::Gtk.Button btnClear;

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

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Momiji.frmAuctionSale
			this.WidthRequest = 800;
			this.Name = "Momiji.frmAuctionSale";
			this.Title = global::Mono.Unix.Catalog.GetString("Auction Sale");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource("Momiji.Resources.tag-sale-icon.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmAuctionSale.Gtk.Container+ContainerChild
			this.hboxCheckin = new global::Gtk.HBox();
			this.hboxCheckin.Name = "hboxCheckin";
			this.hboxCheckin.Spacing = 6;
			// Container child hboxCheckin.Gtk.Box+BoxChild
			this.GtkScrolWinMerch = new global::Gtk.ScrolledWindow();
			this.GtkScrolWinMerch.Name = "GtkScrolWinMerch";
			this.GtkScrolWinMerch.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolWinMerch.Gtk.Container+ContainerChild
			this.lstMerch = new global::Gtk.NodeView();
			this.lstMerch.CanFocus = true;
			this.lstMerch.Name = "lstMerch";
			this.lstMerch.EnableSearch = false;
			this.GtkScrolWinMerch.Add(this.lstMerch);
			this.hboxCheckin.Add(this.GtkScrolWinMerch);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxCheckin[this.GtkScrolWinMerch]));
			w2.Position = 0;
			// Container child hboxCheckin.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(8));
			// Container child vbox2.Gtk.Box+BoxChild
			this.lblBarcode = new global::Gtk.Label();
			this.lblBarcode.Name = "lblBarcode";
			this.lblBarcode.Xalign = 0F;
			this.lblBarcode.LabelProp = global::Mono.Unix.Catalog.GetString("Highlight this box and scan:");
			this.vbox2.Add(this.lblBarcode);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.lblBarcode]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.txtBarcode = new global::Gtk.Entry();
			this.txtBarcode.CanFocus = true;
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.IsEditable = true;
			this.txtBarcode.InvisibleChar = '●';
			this.vbox2.Add(this.txtBarcode);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.txtBarcode]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.lblPrice = new global::Gtk.Label();
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Xalign = 0F;
			this.lblPrice.LabelProp = global::Mono.Unix.Catalog.GetString("Price item sold for:");
			this.vbox2.Add(this.lblPrice);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.lblPrice]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.txtPrice = new global::Gtk.Entry();
			this.txtPrice.Sensitive = false;
			this.txtPrice.CanFocus = true;
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.IsEditable = true;
			this.txtPrice.InvisibleChar = '●';
			this.vbox2.Add(this.txtPrice);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.txtPrice]));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnAddToList = new global::Gtk.Button();
			this.btnAddToList.CanFocus = true;
			this.btnAddToList.Name = "btnAddToList";
			this.btnAddToList.UseUnderline = true;
			this.btnAddToList.Label = global::Mono.Unix.Catalog.GetString("Add to list");
			global::Gtk.Image w7 = new global::Gtk.Image();
			w7.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.btnAddToList.Image = w7;
			this.hbox1.Add(this.btnAddToList);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnAddToList]));
			w8.Position = 0;
			w8.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnClear = new global::Gtk.Button();
			this.btnClear.Sensitive = false;
			this.btnClear.CanFocus = true;
			this.btnClear.Name = "btnClear";
			this.btnClear.UseUnderline = true;
			this.btnClear.Label = global::Mono.Unix.Catalog.GetString("Clear");
			global::Gtk.Image w9 = new global::Gtk.Image();
			w9.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.btnClear.Image = w9;
			this.hbox1.Add(this.btnClear);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnClear]));
			w10.Position = 1;
			w10.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w11.Position = 4;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.drpPaymentType = global::Gtk.ComboBox.NewText();
			this.drpPaymentType.AppendText(global::Mono.Unix.Catalog.GetString("Cash"));
			this.drpPaymentType.AppendText(global::Mono.Unix.Catalog.GetString("Card"));
			this.drpPaymentType.Name = "drpPaymentType";
			this.drpPaymentType.Active = 0;
			this.vbox2.Add(this.drpPaymentType);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.drpPaymentType]));
			w12.Position = 5;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.lblPaid = new global::Gtk.Label();
			this.lblPaid.Name = "lblPaid";
			this.lblPaid.Xalign = 0F;
			this.lblPaid.LabelProp = global::Mono.Unix.Catalog.GetString("Paid: <b>$</b>");
			this.lblPaid.UseMarkup = true;
			this.table1.Add(this.lblPaid);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.lblPaid]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblTotal = new global::Gtk.Label();
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.LabelProp = global::Mono.Unix.Catalog.GetString("Total: <b>$</b>");
			this.lblTotal.UseMarkup = true;
			this.table1.Add(this.lblTotal);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.lblTotal]));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtPaid = new global::Gtk.Entry();
			this.txtPaid.CanFocus = true;
			this.txtPaid.Name = "txtPaid";
			this.txtPaid.IsEditable = true;
			this.txtPaid.InvisibleChar = '●';
			this.table1.Add(this.txtPaid);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.txtPaid]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtTotal = new global::Gtk.Entry();
			this.txtTotal.Sensitive = false;
			this.txtTotal.CanFocus = true;
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.IsEditable = true;
			this.txtTotal.InvisibleChar = '●';
			this.table1.Add(this.txtTotal);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1[this.txtTotal]));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.table1);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.table1]));
			w17.Position = 6;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixedPay = new global::Gtk.Fixed();
			this.fixedPay.WidthRequest = 256;
			this.fixedPay.HeightRequest = 96;
			this.fixedPay.Name = "fixedPay";
			this.fixedPay.HasWindow = false;
			// Container child fixedPay.Gtk.Fixed+FixedChild
			this.btnPay = new global::Gtk.Button();
			this.btnPay.WidthRequest = 256;
			this.btnPay.HeightRequest = 96;
			this.btnPay.CanFocus = true;
			this.btnPay.Name = "btnPay";
			this.btnPay.UseUnderline = true;
			this.btnPay.Xalign = 0.75F;
			this.btnPay.Label = global::Mono.Unix.Catalog.GetString("Mark as Paid");
			this.fixedPay.Add(this.btnPay);
			// Container child fixedPay.Gtk.Fixed+FixedChild
			this.imgPay = new global::Gtk.Image();
			this.imgPay.Name = "imgPay";
			this.imgPay.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("Momiji.Resources.tag-sale-icon.png");
			this.fixedPay.Add(this.imgPay);
			global::Gtk.Fixed.FixedChild w19 = ((global::Gtk.Fixed.FixedChild)(this.fixedPay[this.imgPay]));
			w19.X = 32;
			w19.Y = 16;
			this.vbox2.Add(this.fixedPay);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.fixedPay]));
			w20.Position = 7;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.lblChange = new global::Gtk.Label();
			this.lblChange.Name = "lblChange";
			this.lblChange.LabelProp = global::Mono.Unix.Catalog.GetString("Change: <b>$</b>");
			this.lblChange.UseMarkup = true;
			this.hbox3.Add(this.lblChange);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.lblChange]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.txtChange = new global::Gtk.Entry();
			this.txtChange.Sensitive = false;
			this.txtChange.CanFocus = true;
			this.txtChange.Name = "txtChange";
			this.txtChange.IsEditable = false;
			this.txtChange.InvisibleChar = '●';
			this.hbox3.Add(this.txtChange);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.txtChange]));
			w22.Position = 1;
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w23.Position = 8;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnPrintReceipt = new global::Gtk.Button();
			this.btnPrintReceipt.CanFocus = true;
			this.btnPrintReceipt.Name = "btnPrintReceipt";
			this.btnPrintReceipt.UseUnderline = true;
			this.btnPrintReceipt.Label = global::Mono.Unix.Catalog.GetString("Print Receipt");
			global::Gtk.Image w24 = new global::Gtk.Image();
			w24.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-print", global::Gtk.IconSize.Menu);
			this.btnPrintReceipt.Image = w24;
			this.vbox2.Add(this.btnPrintReceipt);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.btnPrintReceipt]));
			w25.Position = 9;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString("Clear Transaction");
			global::Gtk.Image w26 = new global::Gtk.Image();
			w26.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w26;
			this.vbox2.Add(this.btnCancel);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.btnCancel]));
			w27.Position = 10;
			w27.Expand = false;
			w27.Fill = false;
			w27.Padding = ((uint)(8));
			this.hboxCheckin.Add(this.vbox2);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hboxCheckin[this.vbox2]));
			w28.Position = 1;
			w28.Expand = false;
			w28.Fill = false;
			w28.Padding = ((uint)(8));
			this.Add(this.hboxCheckin);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 800;
			this.DefaultHeight = 563;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.txtBarcode.Activated += new global::System.EventHandler(this.OnTxtBarcodeActivated);
			this.txtPrice.Activated += new global::System.EventHandler(this.OnTxtPriceActivated);
			this.btnAddToList.Clicked += new global::System.EventHandler(this.OnBtnAddToListClicked);
			this.btnClear.Clicked += new global::System.EventHandler(this.OnBtnClearClicked);
			this.drpPaymentType.Changed += new global::System.EventHandler(this.OnDrpPaymentTypeChanged);
			this.txtPaid.Activated += new global::System.EventHandler(this.OnTxtPaidActivated);
			this.btnPay.Clicked += new global::System.EventHandler(this.OnBtnPayClicked);
			this.btnPrintReceipt.Clicked += new global::System.EventHandler(this.OnBtnPrintReceiptClicked);
			this.btnCancel.Clicked += new global::System.EventHandler(this.OnBtnCancelClicked);
		}
	}
}
