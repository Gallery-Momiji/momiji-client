
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmReceipts
	{
		private global::Gtk.VBox vbox4;
		private global::Gtk.Label lblTransaction;
		private global::Gtk.ComboBox drpTransaction;
		private global::Gtk.Button btnPrint;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.frmReceipts
			this.Name = "Momiji.frmReceipts";
			this.Title = global::Mono.Unix.Catalog.GetString ("frmReceipts");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmReceipts.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			this.vbox4.BorderWidth = ((uint)(8));
			// Container child vbox4.Gtk.Box+BoxChild
			this.lblTransaction = new global::Gtk.Label ();
			this.lblTransaction.Name = "lblTransaction";
			this.lblTransaction.Xalign = 0F;
			this.lblTransaction.LabelProp = global::Mono.Unix.Catalog.GetString ("Select a transaction:");
			this.vbox4.Add (this.lblTransaction);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.lblTransaction]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.drpTransaction = global::Gtk.ComboBox.NewText ();
			this.drpTransaction.Name = "drpTransaction";
			this.vbox4.Add (this.drpTransaction);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.drpTransaction]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.btnPrint = new global::Gtk.Button ();
			this.btnPrint.CanFocus = true;
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.UseUnderline = true;
			// Container child btnPrint.Gtk.Container+ContainerChild
			global::Gtk.Alignment w3 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w4 = new global::Gtk.HBox ();
			w4.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-print", global::Gtk.IconSize.Menu);
			w4.Add (w5);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w7 = new global::Gtk.Label ();
			w7.LabelProp = global::Mono.Unix.Catalog.GetString ("Re-print Receipt");
			w7.UseUnderline = true;
			w4.Add (w7);
			w3.Add (w4);
			this.btnPrint.Add (w3);
			this.vbox4.Add (this.btnPrint);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.btnPrint]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			this.Add (this.vbox4);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 116;
			this.Show ();
		}
	}
}
