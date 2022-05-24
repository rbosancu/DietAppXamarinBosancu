using DietApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Database
{
    public interface IDatabaseService
    {
        void InitializeDatabase();
        Task GetRemoteData();
        Task SetBreakfastAliments();
        Task SetLunchAliments();
        Task SetDinnerAliments();

        List<Aliment> GetBreakfasts();
        List<Aliment> GetLunches();
        List<Aliment> GetDinners();

        List<string> GetGenderOptions();
    }
}
