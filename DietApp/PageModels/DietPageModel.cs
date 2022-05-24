using DietApp.Models;
using DietApp.PageModels.Base;
using DietApp.Services.Database;
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

        private IProfileService _profileService;
        private IHelperService _helperService;
        private IDatabaseService _databaseService;

        public int CurrentDay
        {
            get => _currentDay;
            set => SetProperty(ref _currentDay, value);
        }


        public DietPageModel(IProfileService profileService, IHelperService helperService, IDatabaseService databaseService)
        {
            _profileService = profileService;
            _helperService = helperService;
            _databaseService = databaseService;

            _dailyCalories = _helperService.DailyCalories(_profileService, _databaseService);

            _breakfasts = _helperService.BreakfastAliments(_databaseService.GetBreakfasts(), _helperService.BreakfastCalories(_dailyCalories));
            _lunches = _helperService.RandomAliments(_databaseService.GetLunches(), _helperService.LunchCalories(_dailyCalories));
            _dinners = _helperService.RandomAliments(_databaseService.GetDinners(), _helperService.DinnerCalories(_dailyCalories));

            BreakfastCardViewModel = new DietCardViewModel("Mic Dejun", "#2c9f45", "breakfast", _helperService.CalculateTotalCalories(_breakfasts), _helperService.BreakfastCalories(_dailyCalories), _breakfasts);
            LunchCardViewModel = new DietCardViewModel("Prânz", "#0099e5", "lunch", _helperService.CalculateTotalCalories(_lunches), _helperService.LunchCalories(_dailyCalories), _lunches);
            DinnerCardViewModel = new DietCardViewModel("Cină", "#fd5c63", "dinner", _helperService.CalculateTotalCalories(_dinners), _helperService.DinnerCalories(_dailyCalories), _dinners);

            CurrentDay = 2;
        }
    }
}
