
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class AboutBox
	{
		private global::Gtk.HBox hboxAbout;
		
		private global::Gtk.Image imgLogo;
		
		private global::Gtk.VBox vboxAbout;
		
		private global::Gtk.Label lblProduct;
		
		private global::Gtk.Label lblVersion;
		
		private global::Gtk.Label lblCRLicense;
		
		private global::Gtk.ScrolledWindow scrolledwindowAbout;
		
		private global::Gtk.Label lblCopyright;
		
		private global::Gtk.Label lblCompany;
		
		private global::Gtk.Button btnClose;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Momiji.AboutBox
			this.Name = "Momiji.AboutBox";
			this.Title = global::Mono.Unix.Catalog.GetString ("About");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Container child Momiji.AboutBox.Gtk.Container+ContainerChild
			this.hboxAbout = new global::Gtk.HBox ();
			this.hboxAbout.Name = "hboxAbout";
			this.hboxAbout.Spacing = 6;
			// Container child hboxAbout.Gtk.Box+BoxChild
			this.imgLogo = new global::Gtk.Image ();
			this.imgLogo.Name = "imgLogo";
			this.imgLogo.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Momiji.Resources.momijilogosmall.jpg");
			this.hboxAbout.Add (this.imgLogo);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hboxAbout [this.imgLogo]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hboxAbout.Gtk.Box+BoxChild
			this.vboxAbout = new global::Gtk.VBox ();
			this.vboxAbout.Name = "vboxAbout";
			this.vboxAbout.Spacing = 6;
			// Container child vboxAbout.Gtk.Box+BoxChild
			this.lblProduct = new global::Gtk.Label ();
			this.lblProduct.Name = "lblProduct";
			this.lblProduct.LabelProp = global::Mono.Unix.Catalog.GetString ("PRODUCT");
			this.vboxAbout.Add (this.lblProduct);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vboxAbout [this.lblProduct]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			w2.Padding = ((uint)(8));
			// Container child vboxAbout.Gtk.Box+BoxChild
			this.lblVersion = new global::Gtk.Label ();
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.LabelProp = global::Mono.Unix.Catalog.GetString ("VERSION");
			this.vboxAbout.Add (this.lblVersion);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vboxAbout [this.lblVersion]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			w3.Padding = ((uint)(8));
			// Container child vboxAbout.Gtk.Box+BoxChild
			this.lblCRLicense = new global::Gtk.Label ();
			this.lblCRLicense.Name = "lblCRLicense";
			this.lblCRLicense.LabelProp = global::Mono.Unix.Catalog.GetString ("Copyright and License Notice:");
			this.vboxAbout.Add (this.lblCRLicense);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxAbout [this.lblCRLicense]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vboxAbout.Gtk.Box+BoxChild
			this.scrolledwindowAbout = new global::Gtk.ScrolledWindow ();
			this.scrolledwindowAbout.CanFocus = true;
			this.scrolledwindowAbout.Name = "scrolledwindowAbout";
			this.scrolledwindowAbout.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindowAbout.Gtk.Container+ContainerChild
			global::Gtk.Viewport w5 = new global::Gtk.Viewport ();
			w5.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.lblCopyright = new global::Gtk.Label ();
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.LabelProp = global::Mono.Unix.Catalog.GetString ("Copyright 2012-2015 Tiago Rogue Medeiros (medeirosT)\nCopyright 2014-2016 Alexander Jeremy Newton (mystro256)\nSpecial thanks to all the testers and users of this program!\n\nThis code is open source!\nView the code here:\nhttps://github.com/Gallery-Momiji/momiji-client\nReport issues and bugs here:\nhttps://github.com/Gallery-Momiji/momiji-client/issues\n\nThe open source license(s) can be found online here:\nhttp://www.gnu.org/licenses/gpl-3.0.html\nhttp://www.gnu.org/licenses/lgpl-3.0.html\n\nAll credit shall be provided to the copyright holders above, and these names\nshall not be removed from this notice without written consent from such\nindividuals, although names of contributors may be added at the digression of\nsuch individual. This notice must be provided with any redistribution of this\ncode, along with a copy of the GPL 3.0 or later and any other applicable\nlicense files necessary as described below.\n\nAll code listed in this project is licensed as GPL 3.0 or later, with two\nexceptions. First, any BUNDLED CODE (i.e. code not derived from this project)\nmaybe licensed differently, in which it would be otherwise specified within\nthe file or directory. Second, any code that requires linking of GPL\nincompatible libraries can be distributed as LGPL 3.0 or later, BUT ONLY IF\nABSOLUTELY NECESSARY FOR THE FUNCTION OF THE CODE. If any code no longer\nrequires this exception, it shall ONLY BE DISTRIBUTED WITH GPL 3.0 or LATER.\nThe goal of this project is to use LGPL sparingly and in the event that LGPL\nis no longer necessary, this warning and the LGPL license file shall be\nremoved from this project.\n\nAll logos and pictures showing Gallery Momiji or Anime North logos, text or\ntrademarks are owned and copyrighted by either Gallery Momiji or Anime North,\nwhich have been used with permission. If this code is redistributed, these\nlogos must be removed, or require written permission, unless otherwise\nspecified by the authors.\nAnime North is a non-profit organization.\nLearn more at http://www.animenorth.com");
			w5.Add (this.lblCopyright);
			this.scrolledwindowAbout.Add (w5);
			this.vboxAbout.Add (this.scrolledwindowAbout);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vboxAbout [this.scrolledwindowAbout]));
			w8.Position = 3;
			// Container child vboxAbout.Gtk.Box+BoxChild
			this.lblCompany = new global::Gtk.Label ();
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.LabelProp = global::Mono.Unix.Catalog.GetString ("COMPANY");
			this.vboxAbout.Add (this.lblCompany);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vboxAbout [this.lblCompany]));
			w9.Position = 4;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vboxAbout.Gtk.Box+BoxChild
			this.btnClose = new global::Gtk.Button ();
			this.btnClose.CanFocus = true;
			this.btnClose.Name = "btnClose";
			this.btnClose.UseUnderline = true;
			this.btnClose.Label = global::Mono.Unix.Catalog.GetString ("Close");
			global::Gtk.Image w10 = new global::Gtk.Image ();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-close", global::Gtk.IconSize.Menu);
			this.btnClose.Image = w10;
			this.vboxAbout.Add (this.btnClose);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vboxAbout [this.btnClose]));
			w11.Position = 5;
			w11.Expand = false;
			w11.Fill = false;
			w11.Padding = ((uint)(8));
			this.hboxAbout.Add (this.vboxAbout);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hboxAbout [this.vboxAbout]));
			w12.Position = 1;
			w12.Padding = ((uint)(8));
			this.Add (this.hboxAbout);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 769;
			this.DefaultHeight = 480;
			this.Show ();
			this.btnClose.Clicked += new global::System.EventHandler (this.OnBtnCloseClicked);
		}
	}
}
