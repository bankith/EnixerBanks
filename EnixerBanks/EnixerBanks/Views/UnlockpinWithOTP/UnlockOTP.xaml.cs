using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.UnlockpinWithOTP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnlockOTP : ContentPage
    {
        private VM.UnlockpinwithDebitVM vm;
        public UnlockOTP()
        {
            InitializeComponent();

            vm = new VM.UnlockpinwithDebitVM();
            this.BindingContext = vm;

        }

        private void BirthDate_Tapped(object sender, EventArgs e)
        {
            datepicker.Focus();
        }

        void birthdate_DateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            vm.BirthDay = e.NewDate.ToString("MM/dd/yyyy");
        }

        async private void confirm_Clicked(object sender, EventArgs e)
        {
            Loading.Start(Loader, LoaderBackground);
            bool isAccountOK = await Services.CheckAccountForUnlockPIN(vm.CardNO);

            if( isAccountOK == false ){
                await DisplayAlert("Not Found", "Your Account Number not correct", "ok");
                return;
            }


            bool unlockOK = await Services.UpdateStatusUnlockPin(3, true);
            if (isAccountOK == false)
            {
                await DisplayAlert("Not UNlock", "Your Account is not unlock", "ok");
                return;
            }
            Loading.Stop(Loader, LoaderBackground);

            await Navigation.PushAsync(new UnlockOTPSuccess());
        }
    }
}