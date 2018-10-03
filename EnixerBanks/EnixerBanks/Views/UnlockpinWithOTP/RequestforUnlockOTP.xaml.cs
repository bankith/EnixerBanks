using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.UnlockpinWithOTP
{
    public partial class RequestforUnlockOTP : ContentPage
    {
        public RequestforUnlockOTP()
        {
            InitializeComponent();
        }

        void DONE_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
