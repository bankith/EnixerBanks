using EnixerBanks;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.ExistingUserLoginView
{
    public partial class OTPPage : ContentPage
    {

        VM.OTPVM vm;

        public OTPPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm = new VM.OTPVM(CurrentPage: this);

            vm.OnOTPCorrected += () =>
            {
                Navigation.PushAsync(new IntroSetUpPINPage());
            };

            BindingContext = vm;
        }


    }
}
