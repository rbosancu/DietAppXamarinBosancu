using DietApp.Models;
using DietApp.PageModels.Base;
using DietApp.Services.Navigation;
using DietApp.Services.Profile;
using DietApp.ViewModels.Buttons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.PageModels
{
    public class ProfilePageModel : PageModelBase
    {
        private User _user;
        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private readonly IProfileService _profileService;
        private readonly INavigationService _navigationService;
        private double _height;
        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private bool _errorIsVisible;
        public bool ErrorIsVisible
        {
            get => _errorIsVisible;
            set => SetProperty(ref _errorIsVisible, value);
        }

        public ButtonModel ResetButton { get; set; }


        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData == null)
            {
                ErrorIsVisible = false;
            }
            else
            {
                ErrorIsVisible = true;
            }

            User = _profileService.GetUserInfo();
            Height = double.Parse(User.Height.ToString()) / 100;

            await base.InitializeAsync(navigationData);
        }

        public ProfilePageModel(IProfileService profileService, INavigationService navigationService)
        {
            _profileService = profileService;
            _navigationService = navigationService;

            Title = "Profil";

            ResetButton = new ButtonModel("Resetează Dieta", ResetDietAction);
        }

        private async void ResetDietAction()
        {
            await _profileService.ClearUserInfo();
            await _navigationService.NavigateToAsync<OnboardingPageModel>(true);
        }
    }
}
