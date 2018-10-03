using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.ChangePasswords
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangePassSuccess : ContentPage
	{
		public ChangePassSuccess ()
		{
			InitializeComponent ();
		}
        private void NextBT_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenuPage());
        }
    }
}