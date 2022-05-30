using DietApp.Models;
using DietApp.Services.Database;
using DietApp.Services.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DietApp.Services.Diet
{
    public class DietService : IDietService
    {
        private readonly IProfileService _profileService;
        private readonly IDatabaseService _databaseService;

        public DietService(IProfileService profileService, IDatabaseService databaseService)
        {
            _profileService = profileService;
            _databaseService = databaseService;
        }

        public List<Aliment> BreakfastAliments(List<Aliment> aliments, int calories)
        {
            int currentCalories = 0;
            List<Aliment> localAliments = new List<Aliment>();

            foreach (Aliment aliment in aliments)
            {
                localAliments.Add(aliment);
                currentCalories += (int)Math.Floor(aliment.Calorii);
            }

            if (currentCalories > calories)
            {
                while (AlimentsTotalCalories(localAliments) > calories)
                {
                    foreach (Aliment aliment in localAliments)
                    {
                        if (aliment.Greutate > 14)
                        {
                            double calorie = aliment.Calorii / aliment.Greutate;

                            aliment.Calorii -= calorie;
                            aliment.Greutate -= 1;
                        }
                    }
                }
            }
            else if (currentCalories < calories)
            {
                while (AlimentsTotalCalories(localAliments) < calories)
                {
                    foreach (Aliment aliment in localAliments)
                    {
                        double calorie = aliment.Calorii / aliment.Greutate;

                        aliment.Calorii += calorie;
                        aliment.Greutate += 1;
                    }
                }
            }
            else
            {
                return localAliments;
            }

            return localAliments;
        }

        public List<Recipe> LunchAliments(List<Recipe> recipes, int calories)
        {
            int currentCalories = 0;
            List<Recipe> localRecipes = new List<Recipe>();
            List<Aliment> localAliments = new List<Aliment>();

            foreach (Recipe recipe in recipes)
            {
                localRecipes.Add(recipe);

                foreach (Aliment aliment in recipe.Ingredients)
                {
                    localAliments.Add(aliment);
                    currentCalories += (int)Math.Floor(aliment.Calorii);
                }
            }

            if (currentCalories > calories)
            {
                while (AlimentsTotalCalories(localAliments) > calories)
                {
                    foreach (Recipe _recipe in localRecipes)
                    {
                        foreach (Aliment aliment in _recipe.Ingredients)
                        {
                            if (aliment.Greutate > 15)
                            {
                                double calorie = aliment.Calorii / aliment.Greutate;

                                aliment.Calorii -= calorie;
                                aliment.Greutate -= 1;
                            }
                        }
                    }
                }
            }
            else if (currentCalories < calories)
            {
                while (AlimentsTotalCalories(localAliments) < calories)
                {
                    foreach (Recipe _recipe in localRecipes)
                    {
                        foreach (Aliment aliment in _recipe.Ingredients)
                        {
                            double calorie = aliment.Calorii / aliment.Greutate;

                            aliment.Calorii += calorie;
                            aliment.Greutate += 1;
                        }
                    }
                }
            }
            else
            {
                return localRecipes;
            }

            return localRecipes;
        }

        public List<Recipe> DinnerAliments(List<Recipe> recipes, int calories)
        {
            int currentCalories = 0;
            List<Recipe> localRecipes = new List<Recipe>();
            List<Aliment> localAliments = new List<Aliment>();

            foreach (Recipe recipe in recipes)
            {
                localRecipes.Add(recipe);

                foreach (Aliment aliment in recipe.Ingredients)
                {
                    localAliments.Add(aliment);
                    currentCalories += (int)Math.Floor(aliment.Calorii);
                }
            }

            if (currentCalories > calories)
            {
                while (AlimentsTotalCalories(localAliments) > calories)
                {
                    foreach (Recipe _recipe in localRecipes)
                    {
                        foreach (Aliment aliment in _recipe.Ingredients)
                        {
                            if (aliment.Greutate > 15)
                            {
                                double calorie = aliment.Calorii / aliment.Greutate;

                                aliment.Calorii -= calorie;
                                aliment.Greutate -= 1;
                            }
                        }
                    }
                }
            }
            else if (currentCalories < calories)
            {
                while (AlimentsTotalCalories(localAliments) < calories)
                {
                    foreach (Recipe _recipe in localRecipes)
                    {
                        foreach (Aliment aliment in _recipe.Ingredients)
                        {
                            double calorie = aliment.Calorii / aliment.Greutate;

                            aliment.Calorii += calorie;
                            aliment.Greutate += 1;
                        }
                    }
                }
            }
            else
            {
                return localRecipes;
            }

            return localRecipes;
        }

        public int CalculateTotalBreakfastCalories(List<Aliment> aliments)
        {
            int totalCalories = 0;

            foreach (Aliment aliment in aliments)
            {
                totalCalories += (int)Math.Floor(aliment.Calorii);
            }

            return totalCalories;
        }

        public int CalculateTotalLunchCalories(List<Recipe> recipes)
        {
            int totalCalories = 0;

            foreach (Recipe recipe in recipes)
            {
                foreach (Aliment aliment in recipe.Ingredients)
                {
                    totalCalories += (int)Math.Floor(aliment.Calorii);
                }
            }

            return totalCalories;
        }

        public int CalculateTotalDinnerCalories(List<Recipe> recipes)
        {
            int totalCalories = 0;

            foreach (Recipe recipe in recipes)
            {
                foreach (Aliment aliment in recipe.Ingredients)
                {
                    totalCalories += (int)Math.Floor(aliment.Calorii);
                }
            }

            return totalCalories;
        }

        public int AlimentsTotalCalories(List<Aliment> aliments)
        {
            double totalCalories = 0;

            foreach (Aliment aliment in aliments)
            {
                totalCalories += aliment.Calorii;
            }

            return (int)Math.Floor(totalCalories);
        }

        public int DailyCalories()
        {
            User user = _profileService.GetUserInfo();
            List<string> genders = _databaseService.GetGenderOptions();

            int dailyCalories;

            if (user.Gender == genders[0])
            {
                double male = (864 - 9.72 * user.Age + 1.12 * (14.2 * user.Weight + 503 * (user.Height / 100)));

                dailyCalories = (int)Math.Floor(male);
            }
            else
            {
                double female = (387 - 7.31 * user.Age + 1.12 * (10.9 * user.Weight + 660.7 * (user.Height / 100)));

                dailyCalories = (int)Math.Floor(female);
            }

            return dailyCalories;
        }

        public int BreakfastCalories(int calories)
        {
            return (int)Math.Floor(calories * 0.25);
        }

        public int LunchCalories(int calories)
        {
            return (int)Math.Floor(calories * 0.40);
        }

        public int DinnerCalories(int calories)
        {
            return (int)Math.Floor(calories * 0.35);
        }
    }
}
