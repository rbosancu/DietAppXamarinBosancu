using DietApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Diet
{
    public interface IDietService
    {
        List<Aliment> BreakfastAliments(List<Aliment> aliments, int calories);
        List<Recipe> LunchAliments(List<Recipe> recipes, int calories);
        List<Recipe> DinnerAliments(List<Recipe> recipes, int calories);
        int CalculateTotalBreakfastCalories(List<Aliment> aliments);
        int CalculateTotalLunchCalories(List<Recipe> recipes);
        int CalculateTotalDinnerCalories(List<Recipe> recipes);
        int DailyCalories();
        int BreakfastCalories(int calories);
        int LunchCalories(int calories);
        int DinnerCalories(int calories);
    }
}
