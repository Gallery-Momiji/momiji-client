
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmSearchDate
	{
		private global::Gtk.VBox vbox5;

		private global::Gtk.Label lblDate;

		private global::Gtk.ComboBox drpDate;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.NodeView lstLog;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Momiji.frmSearchDate
			this.Name = "Momiji.frmSearchDate";
			this.Title = global::Mono.Unix.Catalog.GetString("frmSearchDate");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmSearchDate.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			this.vbox5.BorderWidth = ((uint)(8));
			// Container child vbox5.Gtk.Box+BoxChild
			this.lblDate = new global::Gtk.Label();
			this.lblDate.Name = "lblDate";
			this.lblDate.Xalign = 0F;
			this.lblDate.LabelProp = global::Mono.Unix.Catalog.GetString("Select a Date");
			this.vbox5.Add(this.lblDate);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.lblDate]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.drpDate = global::Gtk.ComboBox.NewText();
			this.drpDate.Name = "drpDate";
			this.vbox5.Add(this.drpDate);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.drpDate]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.lstLog = new global::Gtk.NodeView();
			this.lstLog.WidthRequest = 600;
			this.lstLog.HeightRequest = 400;
			this.lstLog.CanFocus = true;
			this.lstLog.Name = "lstLog";
			this.GtkScrolledWindow.Add(this.lstLog);
			this.vbox5.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.GtkScrolledWindow]));
			w4.Position = 2;
			this.Add(this.vbox5);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 631;
			this.DefaultHeight = 495;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.drpDate.Changed += new global::System.EventHandler(this.OnDrpDateChanged);
		}
	}
}
