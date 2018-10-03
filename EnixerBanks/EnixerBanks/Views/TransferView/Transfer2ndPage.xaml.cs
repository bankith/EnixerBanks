using System;
using System.Collections.Generic;
using EnixerBanks.ModelApp;
using Xamarin.Forms;

namespace EnixerBanks.TransferView
{
    public partial class Transfer2ndPage : ContentPage
    {
        private string amount;
        private FullUserInformation userInfo;
        private AccountInfo toAccountInfo;
        private BankInfo selectedTransferToBank;
        public String Note;

        public Transfer2ndPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public Transfer2ndPage(string amount, FullUserInformation userInfo, AccountInfo toAccountInfo, BankInfo selectedTransferToBank):this()
        {
            this.amount = amount;
            this.userInfo = userInfo;
            this.toAccountInfo = toAccountInfo;
            this.selectedTransferToBank = selectedTransferToBank;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ToBankLogo.Source = ImageSource.FromFile(selectedTransferToBank.Img);

            namefrom.Text =  App.User.Firstname;
            numberfrom.Text = userInfo.AccountNumber;

            nameto.Text = toAccountInfo.FirstName + " " + toAccountInfo.LastName;
            numberto.Text = toAccountInfo.AccountNumber;

            moneylable.Text = amount + " THB";
            Avalablelable.Text = userInfo.AvailableBalance.ToString();
               
        }

        void Note_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new TransferView.NoteP(this));
        }

        private void backBT_Tapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void NextBT_Clicked(object sender, EventArgs e)
        {        
            await Navigation.PushAsync(new TransferView.ConfirmPage(amount, this.userInfo, this.toAccountInfo, this.selectedTransferToBank, Note));

        }
    }
}
