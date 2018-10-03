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
    public partial class CarditCardPage : ContentPage
    {
        private string cardType;
        private FullUserInformation user;

        public CarditCardPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public CarditCardPage(string cardType, FullUserInformation user) : this()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.cardType = cardType;
            this.user = user;
            LoadThisPage(cardType);

        }

        private async void LoadThisPage(string cardtype)
        {
            Loading.Start(Loader, LoaderBackground);
            List<GreenBank_BillerCompany> myBillerCompanys = await Services.GetBillerByType(cardtype);
            Mylistview.ItemsSource = myBillerCompanys;
            Loading.Stop(Loader, LoaderBackground);

        }

        protected override void OnAppearing()
        {

            // Mylistview.ItemsSource = "2"; //binding from table biller Company
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //  Navigation.PushAsync(new SearchBillPage());
            Navigation.PopAsync();
        }

        private void Mylistview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            GreenBank_BillerCompany CardSelected = (GreenBank_BillerCompany)e.SelectedItem;
            Navigation.PushAsync(new PayBills2.SearchBillNextPage(CardSelected, user));
        }
    }
}
