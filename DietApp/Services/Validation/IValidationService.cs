using DietApp.ViewModels.Entries;
using DietApp.ViewModels.Labels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Validation
{
    public interface IValidationService
    {
        Task<bool> ValidateLastName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel);
        Task<bool> ValidateFirstName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel);
        Task<bool> ValidateHeightName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel);
        Task<bool> ValidateWeightName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel);
    }
}
