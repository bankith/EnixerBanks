using EnixerBanks.ModelApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.RegisterCardView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarddetailRegisPage : ContentPage
    {
        AccountInfo AccountInfo;
        VM.CarddetailRegisVM VM;

        public CarddetailRegisPage()
        {
            InitializeComponent();
        }

        public CarddetailRegisPage(AccountInfo account)
        {
            InitializeComponent();
            AccountInfo = account;
            VM = new VM.CarddetailRegisVM();
            BindingContext = VM;

        }

    }
}