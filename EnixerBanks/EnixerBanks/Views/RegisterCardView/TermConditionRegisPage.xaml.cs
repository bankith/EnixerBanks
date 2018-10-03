using System;
using System.Collections.Generic;
using EnixerBanks.ModelApp;
using Xamarin.Forms;

namespace EnixerBanks.RegisterCardView
{
    public partial class TermConditionRegisPage : ContentPage
    {
        AccountInfo AccountInfo;

        public TermConditionRegisPage()
        {
            InitializeComponent();
        }

        public TermConditionRegisPage(AccountInfo account)
        {
            InitializeComponent();

            AccountInfo = account;

            //  Console.WriteLine(AccountInfo.AccountType);

        }

        private void Agree_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CarddetailRegisPage(AccountInfo));
        }

        private void Disagree_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
