using System;
using System.Collections.Generic;


using Xamarin.Forms;
using EnixerBank.Models;
using EnixerBanks.ModelApp;

namespace EnixerBanks.AddAcountView
{
    public partial class AddAccountPage : ContentPage
    {
        VM.AccountTypeVM vm;
        //public string AccountTypeText { get { return AccountTypeLabel.Text; } set { AccountTypeLabel.Text = value; } }
        AddAccountTypePage addAccountTypeP;

        public AddAccountPage()
        {
            InitializeComponent();

            SetBinding();
        }

        private void SetBinding()
        {
            addAccountTypeP = new AddAccountTypePage();
            vm = new VM.AccountTypeVM(addAccountTypeP);

            addAccountTypeP.BindingContext = vm;
            this.BindingContext = vm;
        }

        void SelectAccount_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync( addAccountTypeP);
        }

        async void Next_Clicked(object sender, System.EventArgs e)
        {
            Loading.Start(Loader, LoaderBackground);
            Button btn = (Button)sender;

            if ( btn.Text == "NEXT"){
                AccountInfo account = await Services.GetAccounts(vm.accountNO, vm.serialNO);
                if (account == null)
                {
                    await DisplayAlert("Can't find AccountNO or SerialNO", "Try again", "OK");
                    Loading.Stop(Loader, LoaderBackground);
                    return;
                }
                vm.resultVisibility = true;
                vm.NextText = "CONFIRM";
                vm.resultAccountName = account.Prefix + " " + account.FirstName + " " + account.LastName;
                vm.resultAccountNumber = account.AccountNumber;
            }

            Loading.Stop(Loader, LoaderBackground);

            if ( btn.Text == "CONFIRM" )
            {

                await Navigation.PushAsync(new OTPPage( vm.accountNO));
                return;
            }

            




        }
    }
}
