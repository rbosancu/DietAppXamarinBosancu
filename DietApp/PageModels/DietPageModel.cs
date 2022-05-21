using DietApp.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.PageModels
{
    public class DietPageModel : PageModelBase
    {
        int _currentDay;
        public int CurrentDay
        {
            get => _currentDay;
            set => SetProperty(ref _currentDay, value);
        }

        int _breakfastTotalCalories;
        public int BreakfastTotalCalories
        {
            get => _breakfastTotalCalories;
            set => SetProperty(ref _breakfastTotalCalories, value);
        }

        int _lunchTotalCalories;
        public int LunchTotalCalories
        {
            get => _lunchTotalCalories;
            set => SetProperty(ref _lunchTotalCalories, value);
        }

        int _dinnerTotalCalories;
        public int DinnerTotalCalories
        {
            get => _dinnerTotalCalories;
            set => SetProperty(ref _dinnerTotalCalories, value);
        }

        public DietPageModel()
        {
            CurrentDay = 2;
            BreakfastTotalCalories = 620;
            LunchTotalCalories = 1000;
            DinnerTotalCalories = 540;
        }
    }
}
