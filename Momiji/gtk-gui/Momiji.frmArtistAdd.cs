
// This file has been generated by the GUI designer. Do not modify.
namespace Momiji
{
	public partial class frmArtistAdd
	{
		private global::Gtk.HBox hbox2;

		private global::Gtk.Table table1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TextView txtArtistAddress;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Entry txtArtistID;

		private global::Gtk.Button btnGenerate;

		private global::Gtk.Label lblArtistAddress;

		private global::Gtk.Label lblArtistID;

		private global::Gtk.Label lblArtistName;

		private global::Gtk.Label lblArtistPhone;

		private global::Gtk.Label lblArtistWebsite;

		private global::Gtk.Label lblEmail;

		private global::Gtk.Entry txtArtistName;

		private global::Gtk.Entry txtArtistPhone;

		private global::Gtk.Entry txtArtistWebsite;

		private global::Gtk.Entry txtEmail;

		private global::Gtk.VBox vbox5;

		private global::Gtk.Table table2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gtk.TextView txtAgentAddress;

		private global::Gtk.Label lblAgentAddress;

		private global::Gtk.Label lblAgentEmail;

		private global::Gtk.Label lblAgentName;

		private global::Gtk.Label lblAgentPhone;

		private global::Gtk.Label lblArtistShowName;

		private global::Gtk.Entry txtAgentEmail;

		private global::Gtk.Entry txtAgentName;

		private global::Gtk.Entry txtAgentPhone;

		private global::Gtk.Entry txtArtistShowName;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Button btnCancel;

		private global::Gtk.Button btnDelete;

		private global::Gtk.Button btnUpdate;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Momiji.frmArtistAdd
			this.Name = "Momiji.frmArtistAdd";
			this.Title = global::Mono.Unix.Catalog.GetString("frmArtistAdd");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Momiji.frmArtistAdd.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			this.hbox2.BorderWidth = ((uint)(8));
			// Container child hbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(6)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.txtArtistAddress = new global::Gtk.TextView();
			this.txtArtistAddress.CanFocus = true;
			this.txtArtistAddress.Name = "txtArtistAddress";
			this.GtkScrolledWindow.Add(this.txtArtistAddress);
			this.table1.Add(this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.GtkScrolledWindow]));
			w2.TopAttach = ((uint)(2));
			w2.BottomAttach = ((uint)(3));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.txtArtistID = new global::Gtk.Entry();
			this.txtArtistID.CanFocus = true;
			this.txtArtistID.Name = "txtArtistID";
			this.txtArtistID.IsEditable = true;
			this.txtArtistID.WidthChars = 3;
			this.txtArtistID.MaxLength = 3;
			this.txtArtistID.InvisibleChar = '●';
			this.hbox4.Add(this.txtArtistID);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.txtArtistID]));
			w3.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.btnGenerate = new global::Gtk.Button();
			this.btnGenerate.CanFocus = true;
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.UseUnderline = true;
			this.btnGenerate.Label = global::Mono.Unix.Catalog.GetString("Generate");
			global::Gtk.Image w4 = new global::Gtk.Image();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-execute", global::Gtk.IconSize.Menu);
			this.btnGenerate.Image = w4;
			this.hbox4.Add(this.btnGenerate);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.btnGenerate]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.table1.Add(this.hbox4);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox4]));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblArtistAddress = new global::Gtk.Label();
			this.lblArtistAddress.Name = "lblArtistAddress";
			this.lblArtistAddress.Xalign = 1F;
			this.lblArtistAddress.LabelProp = global::Mono.Unix.Catalog.GetString("Artist Address :");
			this.table1.Add(this.lblArtistAddress);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.lblArtistAddress]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblArtistID = new global::Gtk.Label();
			this.lblArtistID.Name = "lblArtistID";
			this.lblArtistID.Xalign = 1F;
			this.lblArtistID.LabelProp = global::Mono.Unix.Catalog.GetString("Artist ID :");
			this.table1.Add(this.lblArtistID);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.lblArtistID]));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblArtistName = new global::Gtk.Label();
			this.lblArtistName.Name = "lblArtistName";
			this.lblArtistName.Xalign = 1F;
			this.lblArtistName.LabelProp = global::Mono.Unix.Catalog.GetString("Artist Name :");
			this.table1.Add(this.lblArtistName);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.lblArtistName]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblArtistPhone = new global::Gtk.Label();
			this.lblArtistPhone.Name = "lblArtistPhone";
			this.lblArtistPhone.Xalign = 1F;
			this.lblArtistPhone.LabelProp = global::Mono.Unix.Catalog.GetString("Artist Phone :");
			this.table1.Add(this.lblArtistPhone);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.lblArtistPhone]));
			w10.TopAttach = ((uint)(3));
			w10.BottomAttach = ((uint)(4));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblArtistWebsite = new global::Gtk.Label();
			this.lblArtistWebsite.Name = "lblArtistWebsite";
			this.lblArtistWebsite.Xalign = 1F;
			this.lblArtistWebsite.LabelProp = global::Mono.Unix.Catalog.GetString("Artist Website:");
			this.table1.Add(this.lblArtistWebsite);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.lblArtistWebsite]));
			w11.TopAttach = ((uint)(4));
			w11.BottomAttach = ((uint)(5));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.lblEmail = new global::Gtk.Label();
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Xalign = 1F;
			this.lblEmail.LabelProp = global::Mono.Unix.Catalog.GetString("Artist Email :");
			this.table1.Add(this.lblEmail);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.lblEmail]));
			w12.TopAttach = ((uint)(5));
			w12.BottomAttach = ((uint)(6));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtArtistName = new global::Gtk.Entry();
			this.txtArtistName.CanFocus = true;
			this.txtArtistName.Name = "txtArtistName";
			this.txtArtistName.IsEditable = true;
			this.txtArtistName.InvisibleChar = '●';
			this.table1.Add(this.txtArtistName);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.txtArtistName]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtArtistPhone = new global::Gtk.Entry();
			this.txtArtistPhone.CanFocus = true;
			this.txtArtistPhone.Name = "txtArtistPhone";
			this.txtArtistPhone.IsEditable = true;
			this.txtArtistPhone.InvisibleChar = '●';
			this.table1.Add(this.txtArtistPhone);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.txtArtistPhone]));
			w14.TopAttach = ((uint)(3));
			w14.BottomAttach = ((uint)(4));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtArtistWebsite = new global::Gtk.Entry();
			this.txtArtistWebsite.CanFocus = true;
			this.txtArtistWebsite.Name = "txtArtistWebsite";
			this.txtArtistWebsite.IsEditable = true;
			this.txtArtistWebsite.InvisibleChar = '●';
			this.table1.Add(this.txtArtistWebsite);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.txtArtistWebsite]));
			w15.TopAttach = ((uint)(4));
			w15.BottomAttach = ((uint)(5));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.txtEmail = new global::Gtk.Entry();
			this.txtEmail.CanFocus = true;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.IsEditable = true;
			this.txtEmail.InvisibleChar = '●';
			this.table1.Add(this.txtEmail);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1[this.txtEmail]));
			w16.TopAttach = ((uint)(5));
			w16.BottomAttach = ((uint)(6));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox2.Add(this.table1);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.table1]));
			w17.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.table2 = new global::Gtk.Table(((uint)(5)), ((uint)(2)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.txtAgentAddress = new global::Gtk.TextView();
			this.txtAgentAddress.CanFocus = true;
			this.txtAgentAddress.Name = "txtAgentAddress";
			this.GtkScrolledWindow1.Add(this.txtAgentAddress);
			this.table2.Add(this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table2[this.GtkScrolledWindow1]));
			w19.TopAttach = ((uint)(2));
			w19.BottomAttach = ((uint)(3));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lblAgentAddress = new global::Gtk.Label();
			this.lblAgentAddress.Name = "lblAgentAddress";
			this.lblAgentAddress.Xalign = 1F;
			this.lblAgentAddress.LabelProp = global::Mono.Unix.Catalog.GetString("Agent Address :");
			this.table2.Add(this.lblAgentAddress);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table2[this.lblAgentAddress]));
			w20.TopAttach = ((uint)(2));
			w20.BottomAttach = ((uint)(3));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lblAgentEmail = new global::Gtk.Label();
			this.lblAgentEmail.Name = "lblAgentEmail";
			this.lblAgentEmail.Xalign = 1F;
			this.lblAgentEmail.LabelProp = global::Mono.Unix.Catalog.GetString("Agent Email :");
			this.table2.Add(this.lblAgentEmail);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table2[this.lblAgentEmail]));
			w21.TopAttach = ((uint)(4));
			w21.BottomAttach = ((uint)(5));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lblAgentName = new global::Gtk.Label();
			this.lblAgentName.Name = "lblAgentName";
			this.lblAgentName.Xalign = 1F;
			this.lblAgentName.LabelProp = global::Mono.Unix.Catalog.GetString("Agent Name :");
			this.table2.Add(this.lblAgentName);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table2[this.lblAgentName]));
			w22.TopAttach = ((uint)(1));
			w22.BottomAttach = ((uint)(2));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lblAgentPhone = new global::Gtk.Label();
			this.lblAgentPhone.Name = "lblAgentPhone";
			this.lblAgentPhone.Xalign = 1F;
			this.lblAgentPhone.LabelProp = global::Mono.Unix.Catalog.GetString("Agent Phone :");
			this.table2.Add(this.lblAgentPhone);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.table2[this.lblAgentPhone]));
			w23.TopAttach = ((uint)(3));
			w23.BottomAttach = ((uint)(4));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lblArtistShowName = new global::Gtk.Label();
			this.lblArtistShowName.Name = "lblArtistShowName";
			this.lblArtistShowName.Xalign = 1F;
			this.lblArtistShowName.LabelProp = global::Mono.Unix.Catalog.GetString("Artist Show Name :");
			this.table2.Add(this.lblArtistShowName);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.table2[this.lblArtistShowName]));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.txtAgentEmail = new global::Gtk.Entry();
			this.txtAgentEmail.CanFocus = true;
			this.txtAgentEmail.Name = "txtAgentEmail";
			this.txtAgentEmail.IsEditable = true;
			this.txtAgentEmail.InvisibleChar = '●';
			this.table2.Add(this.txtAgentEmail);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table2[this.txtAgentEmail]));
			w25.TopAttach = ((uint)(4));
			w25.BottomAttach = ((uint)(5));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.txtAgentName = new global::Gtk.Entry();
			this.txtAgentName.CanFocus = true;
			this.txtAgentName.Name = "txtAgentName";
			this.txtAgentName.IsEditable = true;
			this.txtAgentName.InvisibleChar = '●';
			this.table2.Add(this.txtAgentName);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.table2[this.txtAgentName]));
			w26.TopAttach = ((uint)(1));
			w26.BottomAttach = ((uint)(2));
			w26.LeftAttach = ((uint)(1));
			w26.RightAttach = ((uint)(2));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.txtAgentPhone = new global::Gtk.Entry();
			this.txtAgentPhone.CanFocus = true;
			this.txtAgentPhone.Name = "txtAgentPhone";
			this.txtAgentPhone.IsEditable = true;
			this.txtAgentPhone.InvisibleChar = '●';
			this.table2.Add(this.txtAgentPhone);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.table2[this.txtAgentPhone]));
			w27.TopAttach = ((uint)(3));
			w27.BottomAttach = ((uint)(4));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(2));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.txtArtistShowName = new global::Gtk.Entry();
			this.txtArtistShowName.CanFocus = true;
			this.txtArtistShowName.Name = "txtArtistShowName";
			this.txtArtistShowName.IsEditable = true;
			this.txtArtistShowName.InvisibleChar = '●';
			this.table2.Add(this.txtArtistShowName);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.table2[this.txtArtistShowName]));
			w28.LeftAttach = ((uint)(1));
			w28.RightAttach = ((uint)(2));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox5.Add(this.table2);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.table2]));
			w29.Position = 0;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString("Cancel");
			global::Gtk.Image w30 = new global::Gtk.Image();
			w30.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w30;
			this.hbox3.Add(this.btnCancel);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.btnCancel]));
			w31.Position = 0;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnDelete = new global::Gtk.Button();
			this.btnDelete.CanFocus = true;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.UseUnderline = true;
			this.btnDelete.Label = global::Mono.Unix.Catalog.GetString("Delete Artist");
			global::Gtk.Image w32 = new global::Gtk.Image();
			w32.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.btnDelete.Image = w32;
			this.hbox3.Add(this.btnDelete);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.btnDelete]));
			w33.Position = 1;
			w33.Expand = false;
			w33.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnUpdate = new global::Gtk.Button();
			this.btnUpdate.CanFocus = true;
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.UseUnderline = true;
			this.btnUpdate.Label = global::Mono.Unix.Catalog.GetString("Finish");
			global::Gtk.Image w34 = new global::Gtk.Image();
			w34.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.btnUpdate.Image = w34;
			this.hbox3.Add(this.btnUpdate);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.btnUpdate]));
			w35.Position = 3;
			w35.Expand = false;
			w35.Fill = false;
			this.vbox5.Add(this.hbox3);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hbox3]));
			w36.Position = 1;
			w36.Expand = false;
			w36.Fill = false;
			w36.Padding = ((uint)(8));
			this.hbox2.Add(this.vbox5);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox5]));
			w37.Position = 1;
			this.Add(this.hbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 672;
			this.DefaultHeight = 309;
			this.Show();
			this.btnGenerate.Clicked += new global::System.EventHandler(this.OnBtnGenerateClicked);
			this.btnCancel.Clicked += new global::System.EventHandler(this.OnBtnCancelClicked);
			this.btnDelete.Clicked += new global::System.EventHandler(this.OnBtnDeleteClicked);
			this.btnUpdate.Clicked += new global::System.EventHandler(this.OnBtnUpdateClicked);
		}
	}
}
