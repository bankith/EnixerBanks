using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using EnixerBank.Models;

namespace EnixerBanks.AddAcountView
{
    public partial class AddRemoveAccountStartPage : ContentPage
    {
        ObservableCollection<GreenBank_Account> listData = new ObservableCollection<GreenBank_Account>();


        public AddRemoveAccountStartPage()
        {
            InitializeComponent();

        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            Loading.Start(Loader, LoaderBackground);
            List<GreenBank_Account> listUsers = await Services.GetAccountsFromUserID(App.User.ID);
            foreach(var user in listUsers)
            {
                if( user.AccountStatus == "Active"){
                    listData.Add(user);
                }
            }

            listView.ItemsSource = listData;
            Loading.Stop(Loader, LoaderBackground);
        }

        void Add_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddAcountView.AddAccountPage());
        }



        void Account_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

        }

        async void OnRemove_Clicked(object sender, System.EventArgs e)
        {
        
            var mi = ((MenuItem)sender);
            var data = (GreenBank_Account)mi.CommandParameter;


            bool answer = await DisplayAlert("Remove Account", "You are about to remove account. Are you sure?", "Confirm", "Cancel");

            if (answer == false) return;

            Loading.Start(Loader, LoaderBackground);
            bool Deleted = await Services.UpdateAccountDeleteStatus(App.User.ID, data.AccountNumber);

            if(!Deleted){
                await DisplayAlert("Not Remove Account", "Something wrong on Deleted account", "Confirm", "Cancel");
                return;
            }
            Loading.Stop(Loader, LoaderBackground);


            int index = listData.IndexOf(data);
            listData.RemoveAt(index);
            await Navigation.PushAsync(new NavigationPage(new RemoveAccountSuccess()));

        }
    }
}
