using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.Log__in_with_temp_En
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgreemantForLogExPage : ContentPage
    {
        public AgreemantForLogExPage()
        {
            InitializeComponent();


        }

        private void Disagree_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void Agree_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PassBookDetailPage());
        }
    }
}