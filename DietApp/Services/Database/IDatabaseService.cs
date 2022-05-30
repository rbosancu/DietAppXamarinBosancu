using DietApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Database
{
    public interface IDatabaseService
    {
        Task InitRemoteData();
        Task GetRemoteData();
        Task SetBreakfastAliments();
        Task SetLunchAliments();
        Task SetDinnerAliments();

        Task SetDietStartDate();
        DateTime GetDietStartDate();
        Task SetCurrentDietDay();
        int GetCurrentDietDay();

        List<Aliment> GetBreakfasts();
        List<Recipe> GetLunches();
        List<Recipe> GetDinners();

        List<string> GetGenderOptions();
    }
}
