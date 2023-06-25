using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Journey.Infrastructure.Navigate
{
    public class NavigationService : INavigationService
    {
        private NavigationWindow _mainFrame;

        #region Implementation of INavigationService

        public event NavigatingCancelEventHandler Navigating;
        public void NavigateTo(Uri pageUri)
        {

            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(pageUri);
            }

        }

        public void GoBack()
        {
            if (EnsureMainFrame()
                && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }

        }

        #endregion

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            _mainFrame = System.Windows.Application.Current.MainWindow as NavigationWindow;

            if (_mainFrame != null)
            {
                // Could be null if the app runs inside a design tool
                _mainFrame.Navigating += (s, e) =>
                {
                    if (Navigating != null)
                    {
                        Navigating(s, e);
                    }
                };

                return true;
            }

            return false;
        }

    }
}