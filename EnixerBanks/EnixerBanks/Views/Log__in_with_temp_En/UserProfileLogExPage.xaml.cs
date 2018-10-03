using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnixerBanks.ModelApp;
using EnixerBank.Models;

namespace EnixerBanks.Log__in_with_temp_En
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfileLogExPage : ContentPage
	{
        GreenBank_UserProfile UserProfile;

		public UserProfileLogExPage ()
		{
			InitializeComponent ();
		}

        public UserProfileLogExPage(GreenBank_UserProfile userProfile)
        {
            InitializeComponent();
            UserProfile = userProfile;
            this.BindingContext = userProfile;

            
        }
                    

        private void next_btn(object sender, EventArgs e)
        {

            UserProfile data = new UserProfile(UserProfile);

            Navigation.PushAsync(new SetupAccountLogExPage(data));
        }
    }
}