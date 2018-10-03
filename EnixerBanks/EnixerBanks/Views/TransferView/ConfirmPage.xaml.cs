using System;
using System.Collections.Generic;
using EnixerBanks.ModelApp;
using Xamarin.Forms;
using EnixerBank.Models;


namespace EnixerBanks.TransferView
{
    public partial class ConfirmPage : ContentPage
    {
        private string amount;
        private FullUserInformation userInfo;
        private AccountInfo toAccountInfo;
        private BankInfo selectedTransferToBank;
        private string note;

        public ConfirmPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public ConfirmPage(string amount, FullUserInformation userInfo, AccountInfo toAccountInfo, BankInfo selectedTransferToBank, string note):this()
        {
            this.amount = amount;
            this.userInfo = userInfo;
            this.toAccountInfo = toAccountInfo;
            this.selectedTransferToBank = selectedTransferToBank;
            this.note = note;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ToBankLogo.Source = ImageSource.FromFile(selectedTransferToBank.Img);
            nameto.Text = toAccountInfo.FirstName + " " + toAccountInfo.LastName;
            numberto.Text = toAccountInfo.AccountNumber;

            namefrom.Text = App.User.Firstname + " " + App.User.Lastname;
            numberfrom.Text = userInfo.AccountNumber;

            monney.Text = amount + " THB";

            Note.Text = note;
            mydatetime.Text = DateTime.Now.ToString();

        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        async  void Confirm_Clicked(object sender, System.EventArgs e)
        {
            Loading.Start(Loader, LoaderBackground);

            Random ran = new Random();

            GreenBank_Transaction transac = new GreenBank_Transaction()
            {
                ReferenceNumber = "BT" + ran.Next(0, 100000000),
                Amount = Convert.ToInt32(amount),
                Sender = userInfo.UserID,
                SenderAccount = userInfo.AccountNumber,
                SenderCountryCode = App.User.CountryCode,
                ReceiverAccount = toAccountInfo.AccountNumber,
                TransactionType = 1,
                ReceiverMobileNumber = toAccountInfo.MobileNumber,
                SenderMobileNumber = App.User.MobileNo,
                TransactionDateTime = DateTime.Now,
                Note = note

            };

            bool result = await Services.InsertTransaction(transac);
            if (!result)
            {
                await DisplayAlert("Something Wrong", "Can't Transfer", "OK");
                Loading.Stop(Loader, LoaderBackground);
                return;
            }

            bool Succeed = await Services.MinusAccountBalance(App.User.ID, userInfo.AccountNumber, Convert.ToInt32(amount));
            if (!Succeed){
                await DisplayAlert("Something Wrong", "Can't Transfer", "OK");
                Loading.Stop(Loader, LoaderBackground);
                return;
            }


            Loading.Stop(Loader, LoaderBackground);

            await Navigation.PushAsync(new TransferView.TransferSuccessfulPage(userInfo, toAccountInfo, amount));
        }
    }
}
