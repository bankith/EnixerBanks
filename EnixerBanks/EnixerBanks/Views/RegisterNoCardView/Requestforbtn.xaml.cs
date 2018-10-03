using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.RegisterNoCardView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Requestforbtn : ContentPage
	{
        private string refnum;

        public Requestforbtn ()
		{
			InitializeComponent ();
		}

        public Requestforbtn(string refnumber):this()
        {
            this.refnum = refnumber;
            this.refnumber.Text = refnumber;
        }

        void DONE_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}