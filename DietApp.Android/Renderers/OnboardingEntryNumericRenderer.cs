using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DietApp.Droid.Renderers;
using DietApp.Views.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(OnboardingEntryNumeric), typeof(OnboardingEntryNumericRenderer))]
namespace DietApp.Droid.Renderers
{
    public class OnboardingEntryNumericRenderer : EntryRenderer
    {
        public OnboardingEntryNumericRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackground(null);
                Control.SetPadding(0, 0, 0, 0);
                Control.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
            }
        }
    }
}