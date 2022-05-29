using DietApp.Models;
using DietApp.ViewModels.Entries;
using DietApp.ViewModels.Labels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Profile
{
    public interface IProfileService
    {
        bool CheckExistingUser();
        Task SetUserInfo(User user);

        User GetUserInfo();

        Task ClearUserInfo();
    }
}
