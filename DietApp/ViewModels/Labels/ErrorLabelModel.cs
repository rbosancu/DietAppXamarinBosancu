using DietApp.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.ViewModels.Labels
{
    public class ErrorLabelModel : ExtendedBindableObject
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        //private string _textColor;
        //public string TextColor
        //{
        //    get => _textColor;
        //    set => SetProperty(ref _textColor, value);
        //}

        private bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        public ErrorLabelModel()
        {
            //TextColor = "Red";
            IsVisible = false;
        }

    }
}
