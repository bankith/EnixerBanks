using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.ExistingUserLoginView
{
    public partial class IntroWelcomePage : ContentPage
    {
        public IntroWelcomePage()
        {
            InitializeComponent();
        }

        async void Done_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new EverLoginPage() );
            Application.Current.MainPage = new NavigationPage(new EverLoginPage());
        }
    }
}
