using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DietApp.Views.Entries
{
    public class OnboardingEntryNumeric : Entry
    {
        public OnboardingEntryNumeric()
        {
            this.Keyboard = Keyboard.Numeric;
        }
    }
}
