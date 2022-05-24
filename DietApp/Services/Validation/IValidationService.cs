using DietApp.ViewModels.Entries;
using DietApp.ViewModels.Labels;
using DietApp.ViewModels.Pickers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Services.Validation
{
    public interface IValidationService
    {
        Task<bool> ValidateGender(OnboardingPickerViewModel pickerModel, ErrorLabelModel errorLabel);
        Task<bool> ValidateName(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel);
        Task<bool> ValidateAge(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel);
        Task<bool> ValidateHeight(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel);
        Task<bool> ValidateWeight(OnboardingEntryViewModel entryModel, ErrorLabelModel errorLabel);
    }
}
