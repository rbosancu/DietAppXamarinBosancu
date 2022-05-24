using DietApp.Models;
using DietApp.Services.Database;
using DietApp.Services.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Services.Helper
{
    public interface IHelperService
    {
        List<Aliment> RandomAliments(List<Aliment> aliments, int calories);

        List<Aliment> BreakfastAliments(List<Aliment> aliments, int calories);
        int CalculateTotalCalories(List<Aliment> aliments);
        int DailyCalories(IProfileService profileService, IDatabaseService databaseService);
        int BreakfastCalories(int calories);
        int LunchCalories(int calories);
        int DinnerCalories(int calories);
    }
}
