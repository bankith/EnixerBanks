using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EnixerBanks.ModelApp;

namespace EnixerBanks.RegisterCardView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectLoneAccRegisPage : ContentPage
	{
        UserProfile UserInfo;
        AccountInfo AccountInfo;
        VM.SelectLoneAccRegisVM VM;


        public SelectLoneAccRegisPage ()
		{
			InitializeComponent ();
            BindingContext = this;

        }

        public SelectLoneAccRegisPage(AccountInfo account, UserProfile user)
        {
            InitializeComponent();
            AccountInfo = account;
            UserInfo = user;
            VM = new VM.SelectLoneAccRegisVM(AccountInfo, UserInfo);
            BindingContext = VM;
        }

     
    }
}