using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DietApp.Models;
using DietApp.PageModels.Base;
using DietApp.Services.Navigation;
using DietApp.Services.Profile;
using DietApp.Services.Validation;
using DietApp.ViewModels.Entries;
using DietApp.ViewModels.Labels;
using TimeTrackerT.ViewModels.Buttons;
using Xamarin.Forms;

namespace DietApp.PageModels
{
    public class OnboardingPageModel : PageModelBase
    {
        private INavigationService _navigationService;
        private IProfileService _profileService;
        private IValidationService _validationService;

        public OnboardingEntryViewModel LastNameEntryViewModel { get; set; }
        public OnboardingEntryViewModel FirstNameEntryViewModel { get; set; }
        public OnboardingEntryViewModel HeightEntryViewModel { get; set; }
        public OnboardingEntryViewModel WeightEntryViewModel { get; set; }

        public ErrorLabelModel LastNameErrorLabel { get; set; }
        public ErrorLabelModel FirstNameErrorLabel { get; set; }
        public ErrorLabelModel HeightErrorLabel { get; set; }
        public ErrorLabelModel WeightErrorLabel { get; set; }

        public ButtonModel StartButton { get; set; }

        public OnboardingPageModel(INavigationService navigationService, IProfileService profileService, IValidationService validationService)
        {
            _navigationService = navigationService;
            _profileService = profileService;
            _validationService = validationService;

            LastNameEntryViewModel = new OnboardingEntryViewModel("Nume", "White");
            LastNameErrorLabel = new ErrorLabelModel();

            FirstNameEntryViewModel = new OnboardingEntryViewModel("Prenume", "White");
            FirstNameErrorLabel = new ErrorLabelModel();

            HeightEntryViewModel = new OnboardingEntryViewModel("Greutate", "White", "Numeric");
            HeightErrorLabel = new ErrorLabelModel();

            WeightEntryViewModel = new OnboardingEntryViewModel("Inaltime", "White", "Numeric");
            WeightErrorLabel = new ErrorLabelModel();

            StartButton = new ButtonModel("Start", DoStartAction);
        }

        private async void DoStartAction()
        {
            bool check = await _validationService.ValidateLastName(LastNameEntryViewModel, LastNameErrorLabel);
            check = await _validationService.ValidateFirstName(FirstNameEntryViewModel, FirstNameErrorLabel);

            if (check)
            {
                await _profileService.SetUserInfo(new User(LastNameEntryViewModel.Text, FirstNameEntryViewModel.Text, HeightEntryViewModel.Text, WeightEntryViewModel.Text));
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
        }
    }
}
