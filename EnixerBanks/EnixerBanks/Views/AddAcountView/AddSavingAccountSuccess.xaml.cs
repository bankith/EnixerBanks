using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.AddAcountView
{
    public partial class AddSavingAccountSuccess : ContentPage
    {
        public AddSavingAccountSuccess()
        {
            InitializeComponent();
        }

        void Done_Clicked(object sender, System.EventArgs e)
        {
            // Navigation.PopToRootAsync();
            Application.Current.MainPage = new NavigationPage(new AddRemoveAccountStartPage());
        }
    }
}
