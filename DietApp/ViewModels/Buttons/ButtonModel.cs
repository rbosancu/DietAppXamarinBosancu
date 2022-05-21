﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DietApp.PageModels.Base;
using Xamarin.Forms;

namespace TimeTrackerT.ViewModels.Buttons
{
    public class ButtonModel : ExtendedBindableObject
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private ICommand _command;
        public ICommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        public ButtonModel(string title, ICommand command, bool isVisible = true, bool isEnabled = true)
        {
            Text = title;
            Command = command;
            IsVisible = isVisible;
            IsEnabled = isEnabled;
        }

        public ButtonModel(string title, Action action, bool isVisible = true, bool isEnabled = true)
        {
            Text = title;
            Command = new Command(action);
            IsVisible = isVisible;
            IsEnabled = isEnabled;
        }
    }
}