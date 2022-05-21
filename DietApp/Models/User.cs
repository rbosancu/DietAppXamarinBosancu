using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Height { get; set; }
        public float Weight { get; set; }

        public User(string lastname, string firstname, int height, float weight)
        {
            LastName = lastname;
            FirstName = firstname;
            Height = height;
            Weight = weight;
        }
    }
}
