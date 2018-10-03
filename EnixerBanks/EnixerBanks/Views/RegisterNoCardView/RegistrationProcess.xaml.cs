using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.RegisterNoCardView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationProcess : ContentPage
	{
		public RegistrationProcess ()
		{
			InitializeComponent ();
		}

        private void Regisprocess_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new TermandConditions());
        }
    }
}