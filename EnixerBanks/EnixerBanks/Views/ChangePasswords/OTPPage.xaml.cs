using EnixerBanks;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EnixerBanks.ChangePasswords
{
    public partial class OTPPage : ContentPage
    {
        VM.OTPVM vm;
        private string newPassword1;

        public OTPPage()
        {
            InitializeComponent();

        }

        public OTPPage(string newPassword1) : this()
        {
            this.newPassword1 = newPassword1;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm = new VM.OTPVM(CurrentPage: this);

            vm.OnOTPCorrected += OnOTPCorrected;

            BindingContext = vm;
        }

        async private void OnOTPCorrected()
        {
            bool isChangePasswordOK = await Services.ChangePassword(App.User.ID, newPassword1);
            if (isChangePasswordOK == false)
            {
                await DisplayAlert("Error", "Can't change your password", "ok");
                return;
            }

            LocalDB.Save(username: App.User.Username, password: newPassword1);
            await Navigation.PushAsync(new ChangePasswords.ChangePassSuccess());

        }



    }
}
