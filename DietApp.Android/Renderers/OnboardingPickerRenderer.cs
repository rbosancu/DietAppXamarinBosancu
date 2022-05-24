using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DietApp.Droid.Renderers;
using DietApp.Views.Pickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(OnboardingPicker), typeof(OnboardingPickerRenderer))]
namespace DietApp.Droid.Renderers
{
    public class OnboardingPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        public OnboardingPickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
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