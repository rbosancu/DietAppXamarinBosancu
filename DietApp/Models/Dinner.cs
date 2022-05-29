using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class Dinner
    {
        public int Day;

        public List<Recipe> Foods = new List<Recipe>();
    }
}
