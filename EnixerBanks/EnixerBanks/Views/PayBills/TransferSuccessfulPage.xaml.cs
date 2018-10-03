using System;
using System.Collections.Generic;
using EnixerBank.Models;
using Xamarin.Forms;

namespace EnixerBanks.PayBills
{
    public partial class TransferSuccessfulPage : ContentPage
    {
        private FullUserInformation user;
        private GreenBank_BillerCompany cardSelected;
        private string amount;

        public TransferSuccessfulPage()
        {
            InitializeComponent();
        }

        public TransferSuccessfulPage(FullUserInformation user, GreenBank_BillerCompany cardSelected, string amount):this()
        {
            this.user = user;
            this.cardSelected = cardSelected;
            this.amount = amount;
            transferDate.Text = DateTime.Now.ToString();

            nameto.Text = cardSelected.ProductName;
            numberto.Text = cardSelected.Company;

            namefrom.Text = App.User.Firstname + " " + App.User.Lastname;
            numberfrom.Text = user.AccountNumber;
            toAccountNumber.Text = cardSelected.AccountNumber;
            Amount.Text = amount + " THB";
        }


        async void DONE_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }


    }
}
