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
        Task<bool> SetUserInfo(User user);

        User GetUserInfo();
    }
}
