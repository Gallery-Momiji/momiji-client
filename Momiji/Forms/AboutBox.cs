using System;
using System.Reflection;

namespace Momiji
{
	public partial class AboutBox : Gtk.Window
	{
		/////////////////////////
		//  Private Functions  //
		/////////////////////////

		private string AssemblyProduct
		{
			get
			{
				// Get all Product attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// If there aren't any Product attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Product attribute, return its value
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		private string AssemblyCompany
		{
			get
			{
				// Get all Company attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// If there aren't any Company attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Company attribute, return its value
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}

		/////////////////////////
		//     Contructor      //
		/////////////////////////

		public AboutBox() :
			base(Gtk.WindowType.Toplevel)
		{
			this.Build();
#if DEBUG
			this.lblVersion.Text = String.Format ("Version {0}-debug",
#else
			this.lblVersion.Text = String.Format("Version {0}",
#endif
				Assembly.GetExecutingAssembly().GetName().Version.ToString());

			this.lblProduct.Text = AssemblyProduct;
			this.lblCompany.Text = AssemblyCompany;
		}

		/////////////////////////
		//     GTK Signals     //
		/////////////////////////

		protected void OnBtnCloseClicked(object sender, EventArgs e)
		{
			this.Destroy();
		}
	}
}

