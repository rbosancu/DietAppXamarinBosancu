using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class Recipe
    {
        public string Name { get; set; }

        public List<Aliment> Ingredients = new List<Aliment>();
    }
}
