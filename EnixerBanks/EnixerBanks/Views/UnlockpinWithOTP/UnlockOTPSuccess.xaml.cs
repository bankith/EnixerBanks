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
	public partial class UnlockOTPSuccess : ContentPage
	{
		public UnlockOTPSuccess ()
		{
			InitializeComponent ();
		}

        void DONE_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}