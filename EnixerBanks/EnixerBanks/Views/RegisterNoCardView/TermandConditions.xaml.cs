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
    public partial class TermandConditions : ContentPage
    {
        public TermandConditions()
        {
            InitializeComponent();
        }

        private void agree_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EnixerAccount());
        }

        private void cancle_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}