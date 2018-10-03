using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnixerBanks.ModelApp;

namespace EnixerBanks.TransferView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferOtherNextPage : ContentPage
    {
        FullUserInformation Thisinfo;
        BankInfo SelectedTransferToBank;

        public TransferOtherNextPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }
        public TransferOtherNextPage(FullUserInformation Thisinfo):this()
        {
            this.Thisinfo = Thisinfo;

            this.BindingContext = Thisinfo;

            //Mylistview.ItemsSource = "2";
            List<BankInfo> bankList = new List<BankInfo>
            {
                new BankInfo(){ Name="Enixer Bank", Img="iconEnixer" },
                new BankInfo(){ Name="Bank Of KMA", Img="iconKrungsi" },
                new BankInfo(){ Name="Bankok Bank", Img="ImageiconBKK" },
                new BankInfo(){ Name="KrungThai Bank", Img="iconKrungThai" }
            };

            BankList.ItemsSource = bankList;
            BankName.Text = "";

        }
               

        private void BackToTrasferOtherBT_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void SelectBankBT_Clicked(object sender, EventArgs e)
        {
            Showlistview.IsVisible = true;

            SelectBankBT.IsVisible = false;
            hindSelectBankBT.IsVisible = true;
        }

        private void hindSelectBankBT_Clicked(object sender, EventArgs e)
        {
            Showlistview.IsVisible = false;

            hindSelectBankBT.IsVisible = false;
            SelectBankBT.IsVisible = true;
        }

        private void BankList_ItemSelected(object sender, SelectedItemChangedEventArgs e) // selected in Banklistview    
        {
            hindSelectBankBT.IsVisible = false;
            Showlistview.IsVisible = false;
            SelectedBank.IsVisible = true;

            BankInfo info = (BankInfo)e.SelectedItem;
            BankLogo.Source = ImageSource.FromFile( info.Img);
            BankName.Text = info.Name;

            SelectedTransferToBank = info;
            IsEnableNextBTN();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Showlistview.IsVisible = true;
        }

        void AccountTo_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if( e.NewTextValue.Length == 10 )
            {
                CheckmarkImg.IsVisible = true;
                IsEnableNextBTN();
            }
            else{
                CheckmarkImg.IsVisible = false;
                IsEnableNextBTN();
            }
        }

        private void IsEnableNextBTN()
        {
            if(ToAccountNo.Text?.Length == 10  &&  !String.IsNullOrEmpty(BankName.Text) )
            {
                NextBTN.IsEnabled = true;
                NextBTN.TextColor = Color.Black;
            }else
            {
                NextBTN.IsEnabled = false;
                NextBTN.TextColor = Color.Silver;
            }
        }

        async void NEXT_Clicked(object sender, System.EventArgs e)
        {
            var toAccountInfo = await Services.GetAccountInfoByAccountNumber(ToAccountNo.Text);
            if( toAccountInfo == null){
                await DisplayAlert("Not Right", "The account number that you want to transfer to does't Exist", "OK");
                return;
            }

            await Navigation.PushAsync(new TransferView.TransferAmountPage( Thisinfo ,toAccountInfo, SelectedTransferToBank));
        }
    }
}