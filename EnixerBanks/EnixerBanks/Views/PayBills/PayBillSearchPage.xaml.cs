using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.PayBills
{
    public partial class PayBillSearchPage : ContentPage
    {
        private FullUserInformation user;
        public PayBillSearchPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Mylistview.ItemsSource = "2";

        }
        public PayBillSearchPage(FullUserInformation Thisinfo):this()
        {
            this.user = Thisinfo;
            this.BindingContext = Thisinfo;

            namefrom.Text = App.User.Firstname;


        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SearchBill_BT_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PayBills.SearchBillPage(user));
        }
    }
}
