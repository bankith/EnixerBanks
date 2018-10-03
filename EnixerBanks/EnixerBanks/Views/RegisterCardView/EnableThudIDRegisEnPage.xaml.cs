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
	public partial class EnableThudIDRegisEnPage : ContentPage
	{
		public EnableThudIDRegisEnPage ()
		{
			InitializeComponent ();
		}

        async void Skip_Clicked(object sender, System.EventArgs e)
        {
            //  await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new TabPage());
        }

        async void Enable_Clicked(object sender, System.EventArgs e)
        {
           // await Navigation.PushAsync(new EnableTouchIDSuccessPage());
            //  Navigation.PushAsync(new AgreementPage());
        }
    }
}