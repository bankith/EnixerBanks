using EnixerBanks.Log__in_with_temp_En;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.Helper
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetupPinLogExPage : ContentPage
	{
        UserProfile UserProfile;

		public SetupPinLogExPage ()
		{
			InitializeComponent ();
		}

        public SetupPinLogExPage(UserProfile user)
        {
            InitializeComponent();
            UserProfile = user;
        }

        private void SetPIN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PinSetupPageLogExPage(UserProfile));

        }

        async private void cancle_btn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EverLoginPage());
            Application.Current.MainPage = new NavigationPage(new EverLoginPage());
        }
    }
}