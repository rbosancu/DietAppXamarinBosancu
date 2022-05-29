using DietApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DietApp.Services.Profile
{
    public class MockProfileService : IProfileService
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
            try
            {

                User user = new User();

                user.Gender = (string)Application.Current.Properties["Gender"];
                user.Name = (string)Application.Current.Properties["Name"];
                user.Age = (int)Application.Current.Properties["Age"];
                user.Height = (int)Application.Current.Properties["Height"];
                user.Weight = (double)Application.Current.Properties["Weight"];

                return user;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("Reached Finally");

            }
            return new User();
        }

        public async Task SetUserInfo(User user)
        {
            Application.Current.Properties["Gender"] = "Femeie";
            Application.Current.Properties["Name"] = "Stachie";
            Application.Current.Properties["Age"] = 32;
            Application.Current.Properties["Height"] = 176;
            Application.Current.Properties["Weight"] = (double)76;

            await Task.FromResult(true);
        }
    }
}
