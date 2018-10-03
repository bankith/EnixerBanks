using System;
using System.Collections.Generic;
using EnixerBank.Models;
using Xamarin.Forms;

namespace EnixerBanks.PayBills2
{
    public partial class ConfirmPage : ContentPage
    {
        private string amount;
        private FullUserInformation user;
        private GreenBank_BillerCompany cardSelected;
        private string reftext;
        private string note;

        public ConfirmPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public ConfirmPage(string amount, FullUserInformation user, GreenBank_BillerCompany cardSelected, string reftext, string note) : this()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.amount = amount;
            this.user = user;
            this.cardSelected = cardSelected;
            this.reftext = reftext;
            this.note = note;
        }
        public ConfirmPage(string amount, FullUserInformation user, FavoritedBillInfo cardSelected, string reftext, string note) : this()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.amount = amount;
            this.user = user;
            // this.cardSelected = cardSelected;
            this.reftext = reftext;
            this.note = note;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //ToBankLogo.Source = ImageSource.FromFile(selectedTransferToBank.Img);

            nameto.Text = App.Check ? App.FavoruSelected.ProductName : cardSelected.ProductName;
            numberto.Text = App.Check ? App.FavoruSelected.AccountNumber : cardSelected.AccountNumber;

            namefrom.Text = App.User.Firstname + " " + App.User.Lastname;
            numberfrom.Text = user.AccountNumber;

            monney.Text = amount + " " + user.Currency;

            Note.Text = note;
            mydatetime.Text = DateTime.Now.ToString();

        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        async void Confirm_Clicked(object sender, System.EventArgs e)
        {
            Loading.Start(Loader, LoaderBackground);

            Random ran = new Random();

            GreenBank_Transaction transac = new GreenBank_Transaction()
            {
                ReferenceNumber = "BT" + ran.Next(0, 100000000),
                Amount = Convert.ToInt32(amount),
                Sender = App.User.ID,
                Receiver = Convert.ToInt32(App.Check ? App.FavoruSelected.ID : cardSelected.ID),
                SenderAccount = user.AccountNumber,
                SenderCountryCode = App.User.CountryCode,
                ReceiverAccount = App.Check ? App.FavoruSelected.AccountNumber : cardSelected.AccountNumber,
                TransactionType = 2,
                SenderMobileNumber = App.User.MobileNo,
                ReceiverMobileNumber = App.User.MobileNo,
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

            bool Succeed = await Services.MinusAccountBalance(App.User.ID, user.AccountNumber, Convert.ToInt32(amount));
            if (!Succeed)
            {
                await DisplayAlert("Something Wrong", "Can't Transfer", "OK");
                Loading.Stop(Loader, LoaderBackground);
                return;
            }


            Loading.Stop(Loader, LoaderBackground);

            await Navigation.PushAsync(new PayBills2.TransferSuccessfulPage(user, cardSelected, amount));
        }
    }
}
