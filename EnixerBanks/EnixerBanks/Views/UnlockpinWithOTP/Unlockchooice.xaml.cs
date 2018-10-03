using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.UnlockpinWithOTP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Unlockchooice : ContentPage
	{
		public Unlockchooice ()
		{
			InitializeComponent ();
		}

        private void WithDebit_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UnlockOTP());
        }

        async private void WithOutDebit_Tapped(object sender, EventArgs e)
        {
            
            Loading.Start(Loader, LoaderBackground);
            var isRefOk = await Services.GetUserRefNumber(3);
            if (isRefOk == null)
            {
                await DisplayAlert("Not OK", "Can't Get Your Refference", "ok");
                return;
            }
            Loading.Stop(Loader, LoaderBackground);

            await Navigation.PushAsync(new RequestforUnlockOTP());
        }
    }
}