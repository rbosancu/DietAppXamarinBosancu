using DietApp.ViewModels.Entries;
using DietApp.ViewModels.Labels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Validation
{
    public class ValidationService : IValidationService
    {
        public Task<bool> ValidateLastName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel)
        {
            if (string.IsNullOrWhiteSpace(entryModel.Text) || entryModel.Text.Length < 3)
            {
                errorLabel.Text = "Numele trebuie să conțină minim 3 litere";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else
            {
                errorLabel.IsVisible = false;
                return Task.FromResult(true);
            }
        }

        public Task<bool> ValidateFirstName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel)
        {
            if (string.IsNullOrWhiteSpace(entryModel.Text) || entryModel.Text.Length < 3)
            {
                errorLabel.Text = "Prenumele trebuie să conțină minim 3 litere";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else
            {
                errorLabel.IsVisible = false;
                return Task.FromResult(true);
            }
        }

        public Task<bool> ValidateHeight(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel)
        {
            bool isNumber = int.TryParse(entryModel.Text, out int number);

            if (string.IsNullOrWhiteSpace(entryModel.Text))
            {
                errorLabel.Text = "Câmpul înălțime este obligatoriu";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else if (!isNumber)
            {
                errorLabel.Text = "Câmpul înălțime trebuie să fie un număr întreg";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else if (number < 100)
            {
                errorLabel.Text = "Înălțimea trebuie să fie mai mare de 100cm";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else
            {
                errorLabel.IsVisible = false;
                return Task.FromResult(true);
            }
        }

        public Task<bool> ValidateWeight(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel)
        {
            bool isNumber = float.TryParse(entryModel.Text, out float number);

            if (string.IsNullOrWhiteSpace(entryModel.Text))
            {
                errorLabel.Text = "Câmpul greutate este obligatoriu";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else if (!isNumber)
            {
                errorLabel.Text = "Câmpul greutate trebuie să fie un număr";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else if (number < 20)
            {
                errorLabel.Text = "Greutatea trebuie să fie mai mare de 20kg";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else
            {
                errorLabel.IsVisible = false;
                return Task.FromResult(true);
            }
        }
    }
}
