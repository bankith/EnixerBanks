using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnixerBanks.TransferView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NotePage : ContentPage
	{
        private Transfer2ndPage transfer2ndPage;

        public NotePage ()
		{
			InitializeComponent ();
		}

        public NotePage(Transfer2ndPage transfer2ndPage):this()
        {
            this.transfer2ndPage = transfer2ndPage;
        }

        void Save_Clicked(object sender, System.EventArgs e)
        {
            transfer2ndPage.Note = Note.Text;
            Navigation.PopModalAsync();
        }
    }
}