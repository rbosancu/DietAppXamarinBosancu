using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public User(string lastname, string firstname, string height, string weight)
        {
            LastName = lastname;
            FirstName = firstname;
            Height = height;
            Weight = weight;
        }
    }
}
