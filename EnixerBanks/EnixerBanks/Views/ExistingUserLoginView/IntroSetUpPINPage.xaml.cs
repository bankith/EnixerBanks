using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.ExistingUserLoginView
{
    public partial class IntroSetUpPINPage : ContentPage
    {
        public IntroSetUpPINPage()
        {
            InitializeComponent();
        }

        async void Cancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        void SetPIN_Clicked(object sender, System.EventArgs e)
        {
            //  Navigation.PushAsync(new AgreementPage());
            Navigation.PushAsync(new ExistingUserLoginView.PinSetUpPage());
        }
    }
}
