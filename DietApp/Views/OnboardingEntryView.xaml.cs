using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnboardingEntryView : ContentView
    {
        public OnboardingEntryView()
        {
            InitializeComponent();
            entryInput.Focused += EntryInput_Focused;
            entryInput.Unfocused += EntryInput_Focused;
        }

        private async void EntryInput_Focused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
            {
                await Task.WhenAll(bvUnderline.FadeTo(1), ugvUnderline.ScaleTo(1));
            }
            else
            {
                await Task.WhenAll(bvUnderline.FadeTo(0.5), ugvUnderline.ScaleTo(0));
            }
        }
    }
}