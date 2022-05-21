using DietApp.Models;
using DietApp.ViewModels.Entries;
using DietApp.ViewModels.Labels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private User _user;

        public User GetUserInfo()
        {
            return _user;
        }

        public Task<bool> SetUserInfo(User user)
        {
            _user = user;

            return Task.FromResult(true);
        }
    }
}
