using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.ExistingUserLoginView
{
    public partial class EnableTouchIDPage : ContentPage
    {
        public EnableTouchIDPage()
        {
            InitializeComponent();
        }

        async void Skip_Clicked(object sender, System.EventArgs e)
        {
            //  await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new IntroWelcomePage());
        }

        void Enable_Clicked(object sender, System.EventArgs e)
        {
            LocalDB.TouchID(Enable: true);
            Navigation.PushAsync(new ExistingUserLoginView.EnableTouchIDSuccessPage());
        }
    }
}
