using DietApp.PageModels.Base;
using DietApp.Services.Navigation;
using System;
using System.Threading.Tasks;
using DietApp.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DietApp.Services.Database;
using DietApp.Services.Profile;
using DietApp.Services.Diet;
using Xamarin.Essentials;

namespace DietApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        async Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            var profileService = PageModelLocator.Resolve<IProfileService>();
            var databaseService = PageModelLocator.Resolve<IDatabaseService>();

            if (profileService.CheckExistingUser())
            {
                await databaseService.SetCurrentDietDay();

                if (databaseService.GetCurrentDietDay() > 15)
                {
                    await navService.NavigateToAsync<ProfilePageModel>(true, true);
                }
                else
                {
                    await navService.NavigateToAsync<DashboardPageModel>();
                }
            }
            else
            {
                await navService.NavigateToAsync<WelcomePageModel>();
            }

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
