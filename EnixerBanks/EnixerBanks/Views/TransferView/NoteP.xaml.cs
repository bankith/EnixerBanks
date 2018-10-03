using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EnixerBanks.TransferView
{
    public partial class NoteP : ContentPage
    {
        private Transfer2ndPage transfer2ndPage;

        public NoteP()
        {
            InitializeComponent();
        }

        public NoteP(Transfer2ndPage transfer2ndPage) : this()
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
