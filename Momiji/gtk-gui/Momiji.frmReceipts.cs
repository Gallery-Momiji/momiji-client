
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmReceipts
	{
		private global::Gtk.VBox vbox4;

		private global::Gtk.Label lblTransaction;

		private global::Gtk.ComboBox drpTransaction;

		private global::Gtk.Button btnPrint;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Momiji.frmReceipts
			this.Name = "Momiji.frmReceipts";
			this.Title = global::Mono.Unix.Catalog.GetString("Print Receipts");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Container child Momiji.frmReceipts.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			this.vbox4.BorderWidth = ((uint)(8));
			// Container child vbox4.Gtk.Box+BoxChild
			this.lblTransaction = new global::Gtk.Label();
			this.lblTransaction.Name = "lblTransaction";
			this.lblTransaction.Xalign = 0F;
			this.lblTransaction.LabelProp = global::Mono.Unix.Catalog.GetString("Select a transaction:");
			this.vbox4.Add(this.lblTransaction);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.lblTransaction]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.drpTransaction = global::Gtk.ComboBox.NewText();
			this.drpTransaction.Name = "drpTransaction";
			this.vbox4.Add(this.drpTransaction);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.drpTransaction]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.btnPrint = new global::Gtk.Button();
			this.btnPrint.CanFocus = true;
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.UseUnderline = true;
			this.btnPrint.Label = global::Mono.Unix.Catalog.GetString("Re-print Receipt");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-print", global::Gtk.IconSize.Menu);
			this.btnPrint.Image = w3;
			this.vbox4.Add(this.btnPrint);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.btnPrint]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.Add(this.vbox4);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 120;
			this.Show();
			this.btnPrint.Clicked += new global::System.EventHandler(this.OnBtnPrintClicked);
		}
	}
}
