using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class User
    {
        public string Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }

        public User()
        {
                
        }
        public User(string gender, string name, int age, int height, double weight)
        {
            Gender = gender;
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
        }
    }
}
