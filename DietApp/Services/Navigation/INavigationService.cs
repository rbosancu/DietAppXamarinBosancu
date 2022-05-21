using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DietApp.PageModels.Base;

namespace DietApp.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigationmethod to push onto the Navigation Stack
        /// </summary>
        /// <typeparam name="TPageModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false) where TPageModelBase : PageModelBase;

        /// <summary>
        /// Navigation method to pop out from Navigation Stack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
