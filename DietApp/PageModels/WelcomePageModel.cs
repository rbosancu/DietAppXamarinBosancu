using DietApp.PageModels.Base;
using DietApp.Services.Database;
using DietApp.Services.Navigation;
using DietApp.ViewModels.Buttons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DietApp.PageModels
{
    public class WelcomePageModel : PageModelBase
    {
        private ICommand _nextStepCommand;
        private readonly INavigationService _navigationService;
        private readonly IDatabaseService _databaseService;

        public ICommand NextStepCommand
        {
            get => _nextStepCommand;
            set => SetProperty(ref _nextStepCommand, value);    
        }

        public ButtonModel NextButton { get; set; }

        string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Eroare", "Nu am acces la internet!", "OK");
                App.Current.Quit();

            }
            else
            {
                await _databaseService.InitRemoteData();
            }

            await base.InitializeAsync(navigationData);
        }

        public WelcomePageModel(INavigationService navigationService, IDatabaseService databaseService)
        {
            _navigationService = navigationService;
            _databaseService = databaseService;

            NextButton = new ButtonModel("Pasul Urmator", DoNextStepAction);
        }

        private async void DoNextStepAction()
        {
            await _navigationService.NavigateToAsync<OnboardingPageModel>();
        }
    }
}
