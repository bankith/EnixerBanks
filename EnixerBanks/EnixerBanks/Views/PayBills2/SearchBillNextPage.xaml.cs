using System;
using System.Collections.Generic;
using EnixerBank.Models;
using Xamarin.Forms;

namespace EnixerBanks.PayBills2
{
    public partial class SearchBillNextPage : ContentPage
    {
        private GreenBank_BillerCompany cardSelected;
        private FullUserInformation user;
        public FavoritedBillInfo FavoruSelected;         // get from favri
        public bool Mycheck = false;

        public SearchBillNextPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public SearchBillNextPage(GreenBank_BillerCompany cardSelected, FullUserInformation user) : this()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.cardSelected = cardSelected;
            this.user = user;
            this.BindingContext = cardSelected;
        }
        public SearchBillNextPage(FullUserInformation user, bool check) : this()
        {
            App.Check = true;
            NavigationPage.SetHasNavigationBar(this, false);

            this.user = user;
            this.BindingContext = App.FavoruSelected;
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void NextBT_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new PayBills2.PaybillAmountPage(Reftext.Text, cardSelected, user));
        }
    }
}
