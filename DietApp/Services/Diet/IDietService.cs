using DietApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Services.Diet
{
    public interface IDietService
    {
        List<Aliment> RandomAliments(List<Aliment> aliments, int calories);
        List<Aliment> BreakfastAliments(List<Aliment> aliments, int calories);
        int CalculateTotalCalories(List<Aliment> aliments);
        int DailyCalories();
        int BreakfastCalories(int calories);
        int LunchCalories(int calories);
        int DinnerCalories(int calories);
    }
}
