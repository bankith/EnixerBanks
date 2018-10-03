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
    public partial class PayBillSearchPage : ContentPage
    {
        private FullUserInformation user;

        public PayBillSearchPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


        }
        public PayBillSearchPage(FullUserInformation Thisinfo) : this()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.user = Thisinfo;
            this.BindingContext = Thisinfo;

            namefrom.Text = App.User.Firstname;

            ThisOnload(Thisinfo);

        }

        private async void ThisOnload(FullUserInformation Thisinfo)
        {
            List<FavoritedBillInfo> list = await Services.FavoritedBills(App.User.ID, Thisinfo.AccountNumber);

            if (list == null) return;

            foreach (FavoritedBillInfo bill in list)
            {
                List<GreenBank_BillerCompany> productList = await Services.GetBillerByType(bill.BillType);

                foreach (GreenBank_BillerCompany product in productList)
                {
                    if (product.ProductName == bill.ProductName)
                    {
                        bill.ID = product.ID;
                        bill.AccountNumber = product.AccountNumber;
                        continue;
                    }
                }
            }
            //
            Mylistview.ItemsSource = list;
            Console.WriteLine("test");
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SearchBill_BT_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PayBills2.SearchBillPage(user));
        }

        private void Mylistview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            App.FavoruSelected = (FavoritedBillInfo)e.SelectedItem;
            Navigation.PushAsync(new PayBills2.SearchBillNextPage(user, true));
        }
    }
}
