using System;
using System.Windows.Navigation;

namespace Journey.Infrastructure.Navigate
{
    public interface INavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Uri pageUri);
        void GoBack();
    }
}