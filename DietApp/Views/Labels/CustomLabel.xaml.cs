using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietApp.Views.Labels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomLabel : Label
    {
        public CustomLabel()
        {
            InitializeComponent();
        }
    }
}