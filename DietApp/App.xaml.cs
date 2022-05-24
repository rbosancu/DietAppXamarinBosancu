using DietApp.PageModels.Base;
using DietApp.Services.Navigation;
using System;
using System.Threading.Tasks;
using DietApp.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DietApp.Services.Database;

namespace DietApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        async Task InitRemoteData()
        {
            var databaseService = PageModelLocator.Resolve<IDatabaseService>();

            await databaseService.SetBreakfastAliments();
            await databaseService.SetLunchAliments();
            await databaseService.SetDinnerAliments();
        }

        async Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();

            await navService.NavigateToAsync<DashboardPageModel>();
        }

        protected override async void OnStart()
        {
            await InitRemoteData();

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
