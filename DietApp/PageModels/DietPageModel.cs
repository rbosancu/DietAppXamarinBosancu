using DietApp.Models;
using DietApp.PageModels.Base;
using DietApp.Services.Database;
using DietApp.Services.Diet;
using DietApp.Services.Helper;
using DietApp.Services.Profile;
using DietApp.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.PageModels
{
    public class DietPageModel : PageModelBase
    {
        private int _dailyCalories;
        public DietCardViewModel BreakfastCardViewModel { get; set; }
        public DietCardViewModel LunchCardViewModel { get; set; }
        public DietCardViewModel DinnerCardViewModel { get; set; }

        private int _currentDay;
        private List<Aliment> _breakfasts;
        private List<Aliment> _lunches;
        private List<Aliment> _dinners;

        private readonly IDietService _dietService;
        private readonly IDatabaseService _databaseService;

        public int CurrentDay
        {
            get => _currentDay;
            set => SetProperty(ref _currentDay, value);
        }


        public DietPageModel(IDietService dietService, IDatabaseService databaseService)
        {
            _dietService = dietService;
            _databaseService = databaseService;

            _dailyCalories = _dietService.DailyCalories();

            _breakfasts = _dietService.BreakfastAliments(_databaseService.GetBreakfasts(), _dietService.BreakfastCalories(_dailyCalories));
            _lunches = _dietService.RandomAliments(_databaseService.GetLunches(), _dietService.LunchCalories(_dailyCalories));
            _dinners = _dietService.RandomAliments(_databaseService.GetDinners(), _dietService.DinnerCalories(_dailyCalories));

            BreakfastCardViewModel = new DietCardViewModel("Mic Dejun", "#2c9f45", "breakfast", _dietService.CalculateTotalCalories(_breakfasts), _dietService.BreakfastCalories(_dailyCalories), _breakfasts);
            LunchCardViewModel = new DietCardViewModel("Prânz", "#0099e5", "lunch", _dietService.CalculateTotalCalories(_lunches), _dietService.LunchCalories(_dailyCalories), _lunches);
            DinnerCardViewModel = new DietCardViewModel("Cină", "#fd5c63", "dinner", _dietService.CalculateTotalCalories(_dinners), _dietService.DinnerCalories(_dailyCalories), _dinners);

            CurrentDay = 2;
        }
    }
}
