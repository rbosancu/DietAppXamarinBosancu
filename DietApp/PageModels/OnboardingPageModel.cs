using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DietApp.Models;
using DietApp.PageModels.Base;
using DietApp.Services.Database;
using DietApp.Services.Navigation;
using DietApp.Services.Profile;
using DietApp.Services.Validation;
using DietApp.ViewModels.Entries;
using DietApp.ViewModels.Labels;
using DietApp.ViewModels.Pickers;
using TimeTrackerT.ViewModels.Buttons;
using Xamarin.Forms;

namespace DietApp.PageModels
{
    public class OnboardingPageModel : PageModelBase
    {
        private INavigationService _navigationService;
        private IProfileService _profileService;
        private IValidationService _validationService;
        private IDatabaseService _databaseService;
        private List<string> _genderOptions;

        public OnboardingPickerViewModel GenderPickerViewModel { get; set; }
        public ErrorLabelModel GenderErrorLabel { get; set; }

        public OnboardingEntryViewModel NameEntryViewModel { get; set; }
        public OnboardingEntryViewModel AgeEntryViewModel { get; set; }
        public OnboardingEntryViewModel HeightEntryViewModel { get; set; }
        public OnboardingEntryViewModel WeightEntryViewModel { get; set; }

        public ErrorLabelModel NameErrorLabel { get; set; }
        public ErrorLabelModel AgeErrorLabel { get; set; }
        public ErrorLabelModel HeightErrorLabel { get; set; }
        public ErrorLabelModel WeightErrorLabel { get; set; }

        public ButtonModel StartButton { get; set; }


        public OnboardingPageModel(INavigationService navigationService, IProfileService profileService, IValidationService validationService, IDatabaseService databaseService)
        {
            _navigationService = navigationService;
            _profileService = profileService;
            _validationService = validationService;
            _databaseService = databaseService;

            _genderOptions = _databaseService.GetGenderOptions();

            GenderPickerViewModel = new OnboardingPickerViewModel("Gen*", _genderOptions);
            GenderErrorLabel = new ErrorLabelModel();

            NameEntryViewModel = new OnboardingEntryViewModel("Nume*", "White");
            NameErrorLabel = new ErrorLabelModel();

            AgeEntryViewModel = new OnboardingEntryViewModel("Vârstă*", "White");
            AgeErrorLabel = new ErrorLabelModel();

            HeightEntryViewModel = new OnboardingEntryViewModel("Înălțime (în cm)*", "White");
            HeightErrorLabel = new ErrorLabelModel();

            WeightEntryViewModel = new OnboardingEntryViewModel("Greutate (în kg)*", "White");
            WeightErrorLabel = new ErrorLabelModel();

            StartButton = new ButtonModel("Start", DoStartAction);
        }

        private async void DoStartAction()
        {
            bool checkGender = await _validationService.ValidateGender(GenderPickerViewModel, GenderErrorLabel);
            bool checkName = await _validationService.ValidateName(NameEntryViewModel, NameErrorLabel);
            bool checkAge = await _validationService.ValidateAge(AgeEntryViewModel, AgeErrorLabel);
            bool checkHeight = await _validationService.ValidateHeight(HeightEntryViewModel, HeightErrorLabel);
            bool checkWeight = await _validationService.ValidateWeight(WeightEntryViewModel, WeightErrorLabel);

            if (checkGender && checkName && checkAge && checkHeight && checkWeight)
            {
                await _profileService.SetUserInfo(new User(convertGender(GenderPickerViewModel.SelectedIndex), NameEntryViewModel.Text, int.Parse(AgeEntryViewModel.Text), int.Parse(HeightEntryViewModel.Text), float.Parse(WeightEntryViewModel.Text)));
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
        }

        private string convertGender (int selectedIndex)
        {
            if (selectedIndex == 1)
            {
                return "Femeie";
            }

            return "Barbat";
        }
    }
}
