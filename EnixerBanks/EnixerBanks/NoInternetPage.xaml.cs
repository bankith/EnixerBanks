using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks
{
    public partial class NoInternetPage : ContentPage
    {
        public NoInternetPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
