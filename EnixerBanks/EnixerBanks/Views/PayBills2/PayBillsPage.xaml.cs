using EnixerBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.PayBills2
{
    public partial class PayBillsPage : ContentPage
    {
        public PayBillsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);

            Loading.Start(Loader, LoaderBackground);
            List<GreenBank_Account> myAccounts = await Services.GetAccountsFromUserID(App.User.ID);
            List<FullUserInformation> listUserInfo = new List<FullUserInformation>();
            for (int i = 0; i < myAccounts.Count; i++)
            {
                var balance = await Services.GetAccountBalance(myAccounts[i].AccountNumber);

                FullUserInformation Thisinfo = new FullUserInformation()
                {
                    // Firstname = myAccounts[i].UserID.ToString(),
                    Firstname = App.User.Firstname,

                    AvailableBalance = balance.AvailableBalance,
                    AccountNumber = balance.AccountNumber,
                    Currency = balance.Currency
                };

                listUserInfo.Add(Thisinfo);
            }



            Mylistview.ItemsSource = listUserInfo;
            Loading.Stop(Loader, LoaderBackground);
        }

        private void BackToMainMenuBT_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void Mylistview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FullUserInformation info = (FullUserInformation)e.SelectedItem;

            Navigation.PushAsync(new PayBills2.PayBillSearchPage(info));
        }
    }
}
