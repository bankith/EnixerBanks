using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.ExistingUserLoginView
{
    public partial class AgreementPage : ContentPage
    {
        public AgreementPage()
        {
            InitializeComponent();
        }

        void Agree_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new OTPPage());
        }

        void Disagree_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
