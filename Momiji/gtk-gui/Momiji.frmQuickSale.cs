
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmQuickSale
	{
		private global::Gtk.HBox hboxCheckin;
		private global::Gtk.ScrolledWindow GtkScrolWinMerch;
		private global::Gtk.NodeView lstMerch;
		private global::Gtk.VBox vbox2;
		private global::Gtk.Label lblBarcode;
		private global::Gtk.Entry txtBarcode;
		private global::Gtk.Table table1;
		private global::Gtk.Label lblPaid;
		private global::Gtk.Label lblTotal;
		private global::Gtk.Entry txtPaid;
		private global::Gtk.Entry txtTotal;
		private global::Gtk.Button btnPay;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Label lblChange;
		private global::Gtk.Entry txtChange;
		private global::Gtk.Button btnCancel;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmQuickSale
			this.WidthRequest = 800;
			this.Name = "Momiji.frmQuickSale";
			this.Title = global::Mono.Unix.Catalog.GetString ("Quick Sale");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmQuickSale.Gtk.Container+ContainerChild
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
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblPaid]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblTotal = new global::Gtk.Label ();
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.LabelProp = global::Mono.Unix.Catalog.GetString ("Total: <b>$</b>");
			this.lblTotal.UseMarkup = true;
			this.table1.Add (this.lblTotal);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.lblTotal]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtPaid = new global::Gtk.Entry ();
			this.txtPaid.CanFocus = true;
			this.txtPaid.Name = "txtPaid";
			this.txtPaid.IsEditable = true;
			this.txtPaid.InvisibleChar = '●';
			this.table1.Add (this.txtPaid);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.txtPaid]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtTotal = new global::Gtk.Entry ();
			this.txtTotal.Sensitive = false;
			this.txtTotal.CanFocus = true;
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.IsEditable = false;
			this.txtTotal.InvisibleChar = '●';
			this.table1.Add (this.txtTotal);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.txtTotal]));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add (this.table1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.table1]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnPay = new global::Gtk.Button ();
			this.btnPay.CanFocus = true;
			this.btnPay.Name = "btnPay";
			this.btnPay.UseUnderline = true;
			// Container child btnPay.Gtk.Container+ContainerChild
			global::Gtk.Alignment w10 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w11 = new global::Gtk.HBox ();
			w11.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w12 = new global::Gtk.Image ();
			w12.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.tag-sale-icon.png");
			w11.Add (w12);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w14 = new global::Gtk.Label ();
			w14.LabelProp = global::Mono.Unix.Catalog.GetString ("Mark as Paid");
			w14.UseUnderline = true;
			w11.Add (w14);
			w10.Add (w11);
			this.btnPay.Add (w10);
			this.vbox2.Add (this.btnPay);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btnPay]));
			w18.Position = 3;
			w18.Expand = false;
			w18.Fill = false;
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
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.lblChange]));
			w19.Position = 0;
			w19.Expand = false;
			w19.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.txtChange = new global::Gtk.Entry ();
			this.txtChange.Sensitive = false;
			this.txtChange.CanFocus = true;
			this.txtChange.Name = "txtChange";
			this.txtChange.IsEditable = false;
			this.txtChange.InvisibleChar = '●';
			this.hbox3.Add (this.txtChange);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.txtChange]));
			w20.Position = 1;
			this.vbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox3]));
			w21.Position = 4;
			w21.Expand = false;
			w21.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			// Container child btnCancel.Gtk.Container+ContainerChild
			global::Gtk.Alignment w22 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w23 = new global::Gtk.HBox ();
			w23.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w24 = new global::Gtk.Image ();
			w24.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			w23.Add (w24);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w26 = new global::Gtk.Label ();
			w26.LabelProp = global::Mono.Unix.Catalog.GetString ("Clear Transaction");
			w26.UseUnderline = true;
			w23.Add (w26);
			w22.Add (w23);
			this.btnCancel.Add (w22);
			this.vbox2.Add (this.btnCancel);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btnCancel]));
			w30.Position = 5;
			w30.Expand = false;
			w30.Fill = false;
			w30.Padding = ((uint)(8));
			this.hboxCheckin.Add (this.vbox2);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hboxCheckin [this.vbox2]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			w31.Padding = ((uint)(8));
			this.Add (this.hboxCheckin);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 800;
			this.DefaultHeight = 331;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.txtBarcode.Activated += new global::System.EventHandler (this.OnTxtBarcodeActivated);
			this.txtPaid.Activated += new global::System.EventHandler (this.OnTxtPaidActivated);
			this.btnPay.Clicked += new global::System.EventHandler (this.OnBtnPayClicked);
			this.btnCancel.Clicked += new global::System.EventHandler (this.OnBtnCancelClicked);
		}
	}
}
