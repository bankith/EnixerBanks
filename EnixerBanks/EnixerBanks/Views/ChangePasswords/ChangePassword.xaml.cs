using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace EnixerBanks.ChangePasswords
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePassword : ContentPage
    {
        private VM.ChangePasswordVM vm;
        public ChangePassword()
        {
            InitializeComponent();
            vm = new VM.ChangePasswordVM();
            BindingContext = vm;
        }

        async private void NextBT_Clicked(object sender, EventArgs e)
        {

            Loading.Start(Loader, LoaderBackground);
            bool isOldPassCorrect = await Services.CheckPassword(App.User.ID, vm.OldPassword);
            Loading.Stop(Loader, LoaderBackground);

            if (isOldPassCorrect == false)
            {
                Vibration.Vibrate();
                vm.OldPassword = "";
                await DisplayAlert("Wrong", "current password is Wrong", "OK");
                return;
            }

            await Navigation.PushAsync(new ChangePasswords.OTPPage(vm.NewPassword1));
        }
    }
}