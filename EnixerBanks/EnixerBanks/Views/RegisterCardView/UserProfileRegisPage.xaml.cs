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
	public partial class UserProfileRegisPage : ContentPage
	{
        VM.UserProfileRegisVM VM;
        AccountInfo AccountInfo;
        

		public UserProfileRegisPage ()
		{
			InitializeComponent ();
            BindingContext = this;

        }

        public UserProfileRegisPage(AccountInfo account)
        {
            InitializeComponent();
            AccountInfo = account;
            VM = new VM.UserProfileRegisVM(AccountInfo);
            BindingContext = VM;
           
        }

    }
}