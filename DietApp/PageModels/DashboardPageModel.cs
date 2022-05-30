using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DietApp.PageModels.Base;

namespace DietApp.PageModels
{
    public class DashboardPageModel : PageModelBase
    {
        private DietPageModel _dietPageModel;
        public DietPageModel DietPageModel
        {
            get => _dietPageModel;
            set => SetProperty(ref _dietPageModel, value);
        }

        private ProfilePageModel _profilePageModel;

        public ProfilePageModel ProfilePageModel
        {
            get => _profilePageModel;
            set => SetProperty(ref _profilePageModel, value);
        }

        private SummaryPageModel _summaryPageModel;
        public SummaryPageModel SummaryPageModel
        {
            get => _summaryPageModel;
            set => SetProperty(ref _summaryPageModel, value);
        }

        public DashboardPageModel(DietPageModel dietPM, ProfilePageModel profilePM,
            SummaryPageModel summaryPM)
        {
            DietPageModel = dietPM;
            ProfilePageModel = profilePM;
            SummaryPageModel = summaryPM;
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData), DietPageModel.InitializeAsync(null), ProfilePageModel.InitializeAsync(null));
       }
    }
}
