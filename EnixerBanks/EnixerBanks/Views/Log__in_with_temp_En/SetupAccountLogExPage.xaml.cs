using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnixerBanks.Log__in_with_temp_En;


namespace EnixerBanks.Log__in_with_temp_En
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetupAccountLogExPage : ContentPage
	{
        UserProfile UserProfile;

		public SetupAccountLogExPage ()
		{
			InitializeComponent ();
		}

        public SetupAccountLogExPage(UserProfile user)
        {
            InitializeComponent();
            UserProfile = user;

        }

        private async void next_btn(object sender, EventArgs e)
        {
            if( entryPassword.Text != entryConpass.Text )
            {
                await DisplayAlert("Alert", "Password not matched", "OK");
                return;
            }

            UserProfile data = new UserProfile()
            {   ID = UserProfile.ID,
                UserEmail = UserProfile.UserEmail,
                MobileNo = UserProfile.MobileNo,
                Username = entryUsernane.Text,
                Password = entryPassword.Text,
                StatusUnlock = UserProfile.StatusUnlock,
                StatusUser = "Active",
            };

            Loading.Start(Loader, LoaderBackground);
            bool UsernameOK = await Services.UserNameValidate(data.Username);


            if (UsernameOK)
            {

               bool registerSucceed = await Services.RegisterOnlineAccount(data);
                if( !registerSucceed)
                {
                    await DisplayAlert("Alert", "Can't register your account", "OK");
                    Loading.Stop(Loader, LoaderBackground);
                    return;
                }

                App.User = data;
                await Navigation.PushAsync(new RegisterSuccLogExPage(data));
            }
            else
            {
                await DisplayAlert("Alert", "Username มีอยู่ในระบบเเล้ว", "OK");

            }
            Loading.Stop(Loader, LoaderBackground);

        }
    }
}