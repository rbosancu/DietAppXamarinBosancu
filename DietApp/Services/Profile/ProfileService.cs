using DietApp.Models;
using DietApp.ViewModels.Entries;
using DietApp.ViewModels.Labels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DietApp.Services.Profile
{
    public class ProfileService : IProfileService
    {
        public bool CheckExistingUser()
        {
            if (Application.Current.Properties.ContainsKey("Name"))
            {
                return true;
            }

            return false;
        }

        public async Task ClearUserInfo()
        {
            Application.Current.Properties.Clear();

            await Task.FromResult(true);
        }

        public User GetUserInfo()
        {
            User user = new User();

            user.Gender = (string)Application.Current.Properties["Gender"];
            user.Name = (string)Application.Current.Properties["Name"];
            user.Age = (int)Application.Current.Properties["Age"];
            user.Height = (int)Application.Current.Properties["Height"];
            user.Weight = (double)Application.Current.Properties["Weight"];

            return user;
        }

        public async Task SetUserInfo(User user)
        {
            Application.Current.Properties["Gender"] = user.Gender;
            Application.Current.Properties["Name"] = user.Name;
            Application.Current.Properties["Age"] = user.Age;
            Application.Current.Properties["Height"] = user.Height;
            Application.Current.Properties["Weight"] = user.Weight;

            await Application.Current.SavePropertiesAsync();
        }
    }
}
