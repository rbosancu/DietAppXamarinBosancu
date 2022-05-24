using DietApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Profile
{
    public class MockProfileService : IProfileService
    {
        private User _user = new User("Barbat", "Stachie Alexandru-Dan", 26, 100, 76);
        public User GetUserInfo()
        {
            return _user;
        }

        public async Task SetUserInfo(User user)
        {
            _user.Gender = "Femeie";
            _user.Name = "Stachie";
            _user.Age = 32;
            _user.Height = 176;
            _user.Weight = 76.6;

            await Task.FromResult(true);
        }
    }
}
