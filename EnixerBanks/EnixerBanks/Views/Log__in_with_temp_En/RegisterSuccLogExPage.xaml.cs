using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnixerBanks.Log__in_with_temp_En;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.Log__in_with_temp_En
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterSuccLogExPage : ContentPage
	{
        UserProfile UserProfile;

		public RegisterSuccLogExPage ()
		{
			InitializeComponent ();
		}

        public RegisterSuccLogExPage(UserProfile user)
        {
			InitializeComponent ();
            UserProfile = user;
        }

        private void next_btn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Helper.SetupPinLogExPage(UserProfile));
        }
    }
}