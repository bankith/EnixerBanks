using System;
using System.Collections.Generic;
using EnixerBank.Models;
using Xamarin.Forms;

namespace EnixerBanks.PayBills2
{
    public partial class Transfer2ndPage : ContentPage
    {
        private string numPin;
        private string Reftext;
        private GreenBank_BillerCompany cardSelected;
        private FullUserInformation user;
        private string Note = "";

        public Transfer2ndPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public Transfer2ndPage(string numPin, string text, GreenBank_BillerCompany cardSelected, FullUserInformation user) : this()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.numPin = numPin;
            this.Reftext = text;
            this.cardSelected = cardSelected;
            this.user = user;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            namefrom.Text = user.Firstname + " " + user.LastName;
            numberfrom.Text = user.AccountNumber;

            nameto.Text = App.Check ? App.FavoruSelected.ProductName : cardSelected.ProductName;
            numberto.Text = App.Check ? App.FavoruSelected.AccountNumber : cardSelected.AccountNumber;

            moneylable.Text = numPin;
            cuury.Text = user.Currency;
            Avalablelable.Text = user.AvailableBalance.ToString() + " " + user.Currency;

        }

        void Note_Tapped(object sender, System.EventArgs e)
        {
            //Navigation.PushModalAsync(new TransferView.NoteP(this));
        }

        private void backBT_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void NextBT_Clicked(object sender, EventArgs e)
        {
            if (!App.Check)
            {
                await Navigation.PushAsync(new PayBills2.ConfirmPage(numPin, this.user, this.cardSelected, this.Reftext, Note));
            }
            await Navigation.PushAsync(new PayBills2.ConfirmPage(numPin, this.user, App.FavoruSelected, this.Reftext, Note));
        }
    }
}
