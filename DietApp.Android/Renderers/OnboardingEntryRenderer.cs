using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DietApp.Views.Entries;
using DietApp.Droid.Renderers;

[assembly: ExportRenderer(typeof(OnboardingEntry),typeof(OnboardingEntryRenderer))]
namespace DietApp.Droid.Renderers
{
    public class OnboardingEntryRenderer : EntryRenderer
    {
        public OnboardingEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackground(null);
                Control.SetPadding(0, 0, 0, 0);
            }
        }
    }
}