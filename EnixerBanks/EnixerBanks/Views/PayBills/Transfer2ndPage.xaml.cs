using System;
using System.Collections.Generic;
using EnixerBank.Models;
using Xamarin.Forms;

namespace EnixerBanks.PayBills
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

        public Transfer2ndPage(string numPin, string text, GreenBank_BillerCompany cardSelected, FullUserInformation user):this()
        {
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

            nameto.Text = cardSelected.ProductName;
            numberto.Text = cardSelected.AccountNumber;

            moneylable.Text = numPin + " THB";
            Avalablelable.Text = user.AvailableBalance.ToString();

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
            await Navigation.PushAsync(new PayBills.ConfirmPage(numPin, this.user, this.cardSelected, this.Reftext, Note));
        }
    }
}
