using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace EnixerBanks
{
    public class EntryNumberOnlyBehavior : Behavior<Entry>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            var isNumber = Regex.IsMatch(entry.Text, @"^\d+$");

            if (isNumber == false && entry.Text.Length > 0)
            {
                string entryText = entry.Text;

                entryText = entryText.Remove(entryText.Length - 1);

                entry.Text = entryText;
            }
        }
    }
}
