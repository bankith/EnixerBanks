﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		}

        private void AddandRemoveBT_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAcountView.AddRemoveAccountStartPage());
        }

        private void ChangePasswordBT_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePasswords.ChangePassword());
        }
    }
}