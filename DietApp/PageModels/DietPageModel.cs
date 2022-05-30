using DietApp.Models;
using DietApp.PageModels.Base;
using DietApp.Services.Control;
using DietApp.Services.Database;
using DietApp.Services.Diet;
using DietApp.Services.Helper;
using DietApp.Services.Profile;
using DietApp.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DietApp.PageModels
{
    public class DietPageModel : PageModelBase
    {
        private readonly int _dailyCalories;
        private int _currentDay;
        private readonly List<Aliment> _breakfasts;
        private readonly List<Recipe> _lunches;
        private readonly List<Recipe> _dinners;
        private readonly IDietService _dietService;
        private readonly IDatabaseService _databaseService;

        public DietCardAlimentViewModel BreakfastCardViewModel { get; set; }
        public DietCardRecipeViewModel LunchCardViewModel { get; set; }
        public DietCardRecipeViewModel DinnerCardViewModel { get; set; }

        public int CurrentDay
        {
            get => _currentDay;
            set => SetProperty(ref _currentDay, value);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await _databaseService.InitRemoteData();
        }

        public DietPageModel(IDietService dietService, IDatabaseService databaseService)
        {
            _dietService = dietService;
            _databaseService = databaseService;

            var currentNetwork = Connectivity.NetworkAccess;

            if (currentNetwork == NetworkAccess.Internet)
            {
                _databaseService.InitRemoteData();

                CurrentDay = _databaseService.GetCurrentDietDay();
                _dailyCalories = _dietService.DailyCalories();

                _breakfasts = _dietService.BreakfastAliments(_databaseService.GetBreakfasts(), _dietService.BreakfastCalories(_dailyCalories));
                _lunches = _dietService.LunchAliments(_databaseService.GetLunches(), _dietService.LunchCalories(_dailyCalories));
                _dinners = _dietService.DinnerAliments(_databaseService.GetDinners(), _dietService.DinnerCalories(_dailyCalories));

                BreakfastCardViewModel = new DietCardAlimentViewModel("Mic Dejun", "#2c9f45", "breakfast", _dietService.CalculateTotalBreakfastCalories(_breakfasts), _dietService.BreakfastCalories(_dailyCalories), _breakfasts);
                LunchCardViewModel = new DietCardRecipeViewModel("Prânz", "#0099e5", "lunch", _dietService.CalculateTotalLunchCalories(_lunches), _dietService.LunchCalories(_dailyCalories), _lunches);
                DinnerCardViewModel = new DietCardRecipeViewModel("Cină", "#fd5c63", "dinner", _dietService.CalculateTotalDinnerCalories(_dinners), _dietService.DinnerCalories(_dailyCalories), _dinners);
            }
        }
    }
}
