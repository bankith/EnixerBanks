using EnixerBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace EnixerBanks.PayBills
{
    public partial class SearchBillPage : ContentPage
    {
        private FullUserInformation user;

        public SearchBillPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            List<string> mylist = new List<string>()
            {
                "Credit Card",
                "Mobile Phone & Telephone",
                "Internet",
                "Home and Land",
                "Leasing and Rental",
                "Personal Loan",
                "Insurance"
            };
            Mylistview.ItemsSource = mylist;
        }

        public SearchBillPage(FullUserInformation user):this()
        {
            this.user = user;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Mylistview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string CardType;
            switch (e.SelectedItem.ToString())
            {
                case "Credit Card":
                    CardType = "CreditCard";
                    await Navigation.PushAsync(new PayBills.CarditCardPage(CardType, user));

                    ; break;
                case "Mobile Phone & Telephone":; break;
                case "Internet":; break;
                case "Home and Land":; break;
                case "Leasing and Rental":; break;
                case "Personal Loan":; break;
                case "Insurance":; break;
            }
        }
    }
}
