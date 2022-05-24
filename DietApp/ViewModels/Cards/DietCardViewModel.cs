using DietApp.Models;
using DietApp.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.ViewModels.Cards
{
    public class DietCardViewModel : ExtendedBindableObject
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _textColor;
        public string TextColor
        {
            get => _textColor;
            set => SetProperty(ref _textColor, value);
        }

        private string _source;
        public string Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        private int _totalBreakfastCalories;
        public int TotalBreakfastCalories
        {
            get => _totalBreakfastCalories;
            set => SetProperty(ref _totalBreakfastCalories, value);
        }

        private int _recommendedCalories;
        public int RecommendedCalories
        {
            get => _recommendedCalories;
            set => SetProperty(ref _recommendedCalories, value);
        }

        private List<Aliment> _breakfasts;
        public List<Aliment> Breakfasts
        {
            get => _breakfasts;
            set => SetProperty(ref _breakfasts, value);
        }

        public DietCardViewModel(string title, string textColor, string source, int totalBreakfastCalories, int recommendedCalories, List<Aliment> breakfasts)
        {
            Title = title;
            TextColor = textColor;
            Source = source;
            TotalBreakfastCalories = totalBreakfastCalories;
            RecommendedCalories = recommendedCalories;
            Breakfasts = breakfasts;
        }

    }
}
