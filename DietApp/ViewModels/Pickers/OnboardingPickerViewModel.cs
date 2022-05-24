using DietApp.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.ViewModels.Pickers
{
    public class OnboardingPickerViewModel : ExtendedBindableObject
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private List<string> _itemsSource;
        public List<string> ItemsSource
        {
            get => _itemsSource;
            set => SetProperty(ref _itemsSource, value);
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        public OnboardingPickerViewModel(string title, List<string> itemsSource)
        {
            SelectedIndex = -1;
            Title = title;
            ItemsSource = itemsSource;
        }
    }
}
