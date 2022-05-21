using DietApp.PageModels.Base;
using DietApp.Services.Navigation;
using System;
using System.Threading.Tasks;
using DietApp.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();

            return navService.NavigateToAsync<OnboardingPageModel>();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
