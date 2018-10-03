using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.RegisterCardView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetupPinRegisEnPage : ContentPage
	{
        UserProfile UserProfile;

        public SetupPinRegisEnPage ()
		{
			InitializeComponent ();
		}
        public SetupPinRegisEnPage(UserProfile user)
        {
            InitializeComponent();

            UserProfile = user;
        }

        private void cancle_btn(object sender, EventArgs e)
        {
           // Navigation.PushAsync(new MainMenuPage());
        }

        private void SetPIN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PinSetupPageRegisEn(UserProfile));
        }
    }
}