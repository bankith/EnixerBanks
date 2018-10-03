using System;
using System.Collections.Generic;
using EnixerBank.Models;
using Xamarin.Forms;

namespace EnixerBanks.PayBills
{
    public partial class SearchBillNextPage : ContentPage
    {
        private GreenBank_BillerCompany cardSelected;
        private FullUserInformation user;

        public SearchBillNextPage()
        {
            InitializeComponent();
        }

        public SearchBillNextPage(GreenBank_BillerCompany cardSelected, FullUserInformation user):this()
        {
            this.cardSelected = cardSelected;
            this.user = user;
            this.BindingContext = cardSelected;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void NextBT_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new PayBills.PaybillAmountPage(Reftext.Text, cardSelected, user));
        }
    }
}
