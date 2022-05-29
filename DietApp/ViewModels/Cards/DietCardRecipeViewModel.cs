using DietApp.Models;
using DietApp.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.ViewModels.Cards
{
    public class DietCardRecipeViewModel : ExtendedBindableObject
    {
        private List<RecipeList> _listOfRecipes;
        public List<RecipeList> ListOfRecipes
        {
            get => _listOfRecipes;
            set => SetProperty(ref _listOfRecipes, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _textColor;
        public string TextColor
        {
            get => _textColor;
            set => SetProperty(ref _textColor, value);
        }

        private string _source;
        public string Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        private int _totalBreakfastCalories;
        public int TotalBreakfastCalories
        {
            get => _totalBreakfastCalories;
            set => SetProperty(ref _totalBreakfastCalories, value);
        }

        private int _recommendedCalories;
        public int RecommendedCalories
        {
            get => _recommendedCalories;
            set => SetProperty(ref _recommendedCalories, value);
        }

        public DietCardRecipeViewModel(string title, string textColor, string source, int totalBreakfastCalories, int recommendedCalories, List<Recipe> recipes)
        {
            Title = title;
            TextColor = textColor;
            Source = source;
            TotalBreakfastCalories = totalBreakfastCalories;
            RecommendedCalories = recommendedCalories;

            var list = new List<RecipeList>();

            foreach (var recipe in recipes)
            {
                var rList = new RecipeList();

                rList.Name = recipe.Name;

                foreach (var aliment in recipe.Ingredients)
                {
                    rList.Ingredients.Add(aliment);
                }

                list.Add(rList);
            }

            ListOfRecipes = list;
        }
    }
}
