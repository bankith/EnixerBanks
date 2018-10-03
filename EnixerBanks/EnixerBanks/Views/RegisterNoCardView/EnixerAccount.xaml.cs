using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.RegisterNoCardView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnixerAccount : ContentPage
    {
        VM.EnixerAccountRegisterVM vm;
        public EnixerAccount()
        {
            InitializeComponent();
            Title = "Picker ItemsSource";


            var items = new List<string>();
            items.Add(" Thai (+66)");
            items.Add(" Laos (+67)");
            items.Add(" Pama (+68)");
            items.Add(" Kumpucha (+69)");
            items.Add(" Philiphin (+70)");
            items.Add(" Marasia (+71)");
            items.Add(" Singkapo (+72)");

            picker.ItemsSource = items;
            picker.Title = "ThaiLand (+66)";

            var itemsNameLabel = new Label();
            itemsNameLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: picker));


            vm = new VM.EnixerAccountRegisterVM();
            this.BindingContext = vm;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            testdate.DateSelected += date_select;
        }

        private void date_select(object sender, DateChangedEventArgs e)
        {

            vm.BirthDay = testdate.Date.ToString("dd/MMM/yyyy");

        }

        void CountryCode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Picker p = (Picker)sender;
            string text = (String)p.SelectedItem;

            vm.CountryCode = text.Substring(text.IndexOf('(') + 1, 3);

            Console.WriteLine(vm.CountryCode);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            testdate.Focus();


        }

        async private void confirm_Clicked(object sender, EventArgs e)
        {
            Loading.Start(Loader, LoaderBackground);
            var info = await Services.GetAccountInfoByAccountNumber(vm.AccountNO);
            if (info == null)
            {
                await DisplayAlert("Wrong", "Account Number is wrong", "OK");
                return;
            }

            var accBalance = await Services.GetAccountBalance(vm.AccountNO);
            info.ID = accBalance.UserID;

            Loading.Stop(Loader, LoaderBackground);

            var nextPage = new Accountinfo(info);
            nextPage.BindingContext = info;
            await Navigation.PushAsync(nextPage);
        }
    }
}