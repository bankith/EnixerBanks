using System;
using System.Collections.Generic;
using EnixerBank.Models;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Screenshot;
using Xamarin.Forms;

namespace EnixerBanks.PayBills2
{
    public partial class TransferSuccessfulPage : ContentPage
    {
        private FullUserInformation user;
        private GreenBank_BillerCompany cardSelected;
        private string amount;

        public TransferSuccessfulPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public TransferSuccessfulPage(FullUserInformation user, GreenBank_BillerCompany cardSelected, string amount) : this()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.user = user;
            this.cardSelected = cardSelected;
            this.amount = amount;
            transferDate.Text = DateTime.Now.ToString();

            nameto.Text = App.Check ? App.FavoruSelected.ProductName : cardSelected.ProductName;


            namefrom.Text = App.User.Firstname + " " + App.User.Lastname;
            numberfrom.Text = user.AccountNumber;
            toAccountNumber.Text = App.Check ? App.FavoruSelected.AccountNumber : cardSelected.AccountNumber;
            Amount.Text = amount + " " + App.Current;
        }


        async void DONE_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void Favorite_Tapped(object sender, EventArgs e)
        {

            //App.Company
        }

        private void BackToTrab2ndBT_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage = new NavigationPage(new EverLoginPage());
        }

        async void SaveScreen_Tapped(object sender, System.EventArgs e)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                {
                    await DisplayAlert("Need Storage", "Gunna need that Storage", "OK");
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Storage))
                    status = results[Permission.Storage];
            }

            if (status == PermissionStatus.Granted)
            {
                Console.WriteLine("OK");
                string path = await CrossScreenshot.Current.CaptureAndSaveAsync();
                var saveOK = await DependencyService.Get<ISavePic>().Save(path, "afdsf");

                if (saveOK) await DisplayAlert("Save", "Save OK", "OK");
                else await DisplayAlert("Save", "Save Not OK", "OK");
            }
        }
    }
}
