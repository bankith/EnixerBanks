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
    public partial class RegisSuccPage : ContentPage
    {
        UserProfile UserProfile;
        public RegisSuccPage()
        {
            InitializeComponent();
        }
        public RegisSuccPage(UserProfile user)
        {
            InitializeComponent();
            UserProfile = user;
        }

        private void next_btn(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetupPinRegisEnPage(UserProfile));
        }
    }
}