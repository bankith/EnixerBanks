using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.ExistingUserLoginView
{
    public partial class EnableTouchIDSuccessPage : ContentPage
    {
        public EnableTouchIDSuccessPage()
        {
            InitializeComponent();
        }

        async void Done_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new IntroWelcomePage() );
        }
    }
}
