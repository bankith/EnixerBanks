using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnixerBanks.ModelApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.RegisterNoCardView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accountinfo : ContentPage
    {
        private AccountInfo info;

        public Accountinfo()
        {
            InitializeComponent();
        }

        public Accountinfo(AccountInfo info) : this()
        {
            this.info = info;
        }

        async void CONFIRM_Clicked(object sender, System.EventArgs e)
        {
            Loading.Start(Loader, LoaderBackground);
            var random = new Random();
            var refnumber = "RT " + random.Next(0, 100000000).ToString();
            bool complete = await Services.RegisterNonConfirmUser(info.ID, refnumber);
            if (!complete)
            {
                await DisplayAlert("Wrong", "Can't register RefNumber", "OK");
                return;
            }

            Loading.Stop(Loader, LoaderBackground);

            if (complete)
            {
                await Navigation.PushAsync(new Requestforbtn(refnumber));
            }
        }
    }
}