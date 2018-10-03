using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnixerBanks.RegisterCardView;
using EnixerBanks.ModelApp;

namespace EnixerBanks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectAccRegisEnPage : ContentPage
	{
        UserProfile UserProfile;
        AccountInfo AccountInfo;

        public SelectAccRegisEnPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            AccountInfo = new AccountInfo()
            {
                CardType=""
                
            };

            Navigation.PushAsync(new TermConditionRegisPage(AccountInfo));
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
           

            //App.Current.MainPage.Navigation.PushAsync(new RegistrationProcess());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
           

        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
          

        }
    }
}