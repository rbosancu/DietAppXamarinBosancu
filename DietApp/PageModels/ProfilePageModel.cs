using DietApp.Models;
using DietApp.PageModels.Base;
using DietApp.Services.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.PageModels
{
    public class ProfilePageModel : PageModelBase
    {
        private User _user;

        private IProfileService _profileService;

        string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        string _fullName;
        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }


        public override async Task InitializeAsync(object navigationData = null)
        {
            _user = _profileService.GetUserInfo();
            FullName = $"{_user.LastName} {_user.FirstName}";

            await base.InitializeAsync(navigationData);
        }

        public ProfilePageModel(IProfileService profileService)
        {
            _profileService = profileService;
        }
    }
}
