using DietApp.Pages;
using DietApp.Services.Navigation;
using DietApp.Services.Profile;
using DietApp.Services.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamarin.Forms;

namespace DietApp.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            // Register pages and page models
            Register<WelcomePageModel, WelcomePage>();
            Register<OnboardingPageModel, OnboardingPage>();
            Register<DashboardPageModel, DashboardPage>();
            Register<DietPageModel, DietPage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SummaryPageModel, SummaryPage>();

            // Register Services
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IProfileService, ProfileService>();
            _container.Register<IValidationService, ValidationService>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;

            return page;
        }

        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _viewLookup.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }
    }
}
