using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EnixerBanks.ExistingUserLoginView
{
    public partial class IntroNewLogin :ContentPage
    {
        public IntroNewLogin()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void Next_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync( new AgreementPage() );
        }

        async void X_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
