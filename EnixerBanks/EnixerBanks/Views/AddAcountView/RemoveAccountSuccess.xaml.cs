using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.AddAcountView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RemoveAccountSuccess : ContentPage
	{
		public RemoveAccountSuccess ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new AddRemoveAccountStartPage());
        }
    }
}