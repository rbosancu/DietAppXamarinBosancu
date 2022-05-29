using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class RecipeList : List<Aliment>
    {
        public string Name { get; set; }
        public List<Aliment> Ingredients => this;
    }
}
