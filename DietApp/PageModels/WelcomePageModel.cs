using DietApp.PageModels.Base;
using DietApp.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DietApp.PageModels
{
    public class WelcomePageModel : PageModelBase
    {
        private ICommand _nextStepCommand;
        private INavigationService _navigationService;

        public ICommand NextStepCommand
        {
            get => _nextStepCommand;
            set => SetProperty(ref _nextStepCommand, value);    
        }

        string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        public WelcomePageModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ButtonText = "Pasul Urmator";

            // Init our Command
            NextStepCommand = new Command(DoNextStepAction);
        }

        private async void DoNextStepAction(object obj)
        {
            await _navigationService.NavigateToAsync<OnboardingPageModel>();
        }
    }
}
