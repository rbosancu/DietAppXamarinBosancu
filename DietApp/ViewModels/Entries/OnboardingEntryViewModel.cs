using DietApp.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.ViewModels.Entries
{
    public class OnboardingEntryViewModel : ExtendedBindableObject
    {
        private string _placeholder;
        public string Placeholder
        {
            get => _placeholder;
            set => SetProperty(ref _placeholder, value);
        }

        private string _placeholderColor;
        public string PlaceholderColor
        {
            get => _placeholderColor;
            set => SetProperty(ref _placeholderColor, value);
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _textColor;
        public string TextColor
        {
            get => _textColor;
            set => SetProperty(ref _textColor, value);
        }

        private string _keyboard;
        public string Keyboard
        {
            get => _keyboard;
            set => SetProperty(ref _keyboard, value);
        }
        
        private bool _isPassword;
        public bool IsPassword
        {
            get => _isPassword;
            set => SetProperty(ref _isPassword, value);
        }


        public OnboardingEntryViewModel(string placeholder, string placeholderColor, string keyboard="Default", bool isPassword = false)
        {
            Placeholder = placeholder;
            PlaceholderColor = placeholderColor;
            TextColor = placeholderColor;
            Keyboard = keyboard;
            IsPassword = isPassword;
        }
    }
}
