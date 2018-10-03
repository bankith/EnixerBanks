using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnixerBanks.ModelApp;
namespace EnixerBanks.Log__in_with_temp_En
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassBookDetailPage : ContentPage
    {
        
        public PassBookDetailPage()
        {
            InitializeComponent();
        }

        void Passbook_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if( e.NewTextValue.Length == 10 ){
                NextBtn.BackgroundColor = Color.FromHex("#347555");
                NextBtn.IsEnabled = true;
            }else{
                NextBtn.BackgroundColor = Color.Silver;
                NextBtn.IsEnabled = false;
            }
        }

        private async void next_btn(object sender, EventArgs e)
        {
            Loading.Start(Loader, LoaderBackground);
            var data = await Services.GetUserInfoByPassbookNumber(entry.Text);
            if (data != null)
            {
                await Navigation.PushAsync(new UserProfileLogExPage(data));
            }
            else
            {
                await  DisplayAlert("Error", "Not Found", "OK");
            }
            Loading.Stop(Loader, LoaderBackground);

        }
    }
}