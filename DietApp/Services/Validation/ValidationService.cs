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
        public Task<bool> ValidateFirstName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel)
        {
            if (string.IsNullOrWhiteSpace(entryModel.Text) || entryModel.Text.Length < 3)
            {
                errorLabel.Text = "Prenumele trebuie sa contina minim 3 litere";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else
            {
                errorLabel.IsVisible = false;
                return Task.FromResult(true);
            }
        }

        public Task<bool> ValidateHeightName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateLastName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel)
        {
            if (string.IsNullOrWhiteSpace(entryModel.Text) || entryModel.Text.Length < 3)
            {
                errorLabel.Text = "Numele trebuie sa contina minim 3 litere";
                errorLabel.IsVisible = true;
                return Task.FromResult(false);
            }
            else
            {
                errorLabel.IsVisible = false;
                return Task.FromResult(true);
            }
        }

        public Task<bool> ValidateWeightName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel)
        {
            throw new NotImplementedException();
        }
    }
}
