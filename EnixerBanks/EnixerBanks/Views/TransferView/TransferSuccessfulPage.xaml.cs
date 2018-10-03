using System;
using System.Collections.Generic;
using EnixerBanks.ModelApp;
using Xamarin.Forms;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Screenshot;

namespace EnixerBanks.TransferView
{
    public partial class TransferSuccessfulPage : ContentPage
    {
        private FullUserInformation userInfo;
        private AccountInfo toAccountInfo;
        private string amount;

        public TransferSuccessfulPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public TransferSuccessfulPage(FullUserInformation userInfo, AccountInfo toAccountInfo, string amount) : this()
        {
            this.userInfo = userInfo;
            this.toAccountInfo = toAccountInfo;
            this.amount = amount;

            transferDate.Text = DateTime.Now.ToString();

            nameto.Text = toAccountInfo.FirstName + " " + toAccountInfo.LastName;
            numberto.Text = toAccountInfo.AccountNumber;

            namefrom.Text = App.User.Firstname + " " + App.User.Lastname;
            numberfrom.Text = userInfo.AccountNumber;
            toAccountNumber.Text = toAccountInfo.AccountNumber;
            Amount.Text = amount + " THB";
        }


        async void DONE_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
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
