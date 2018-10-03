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
	public partial class Selectaccount : ContentPage
	{
		public Selectaccount ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterCardView.TermConditionRegisPage());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterNoCardView.RegistrationProcess());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {

        }
    }
}