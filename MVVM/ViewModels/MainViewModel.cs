using Journey.MVVM.Base;
using System.Windows;

namespace Journey.MVVM.ViewModels
{
    public class MainViewModel: NotifyPropertyChanged
    {
        private Visibility _menuVis = Visibility.Collapsed;
        
        public Visibility MenuVis
        {
            get => _menuVis;
            set => Set(ref _menuVis, value);
        }

        public MainViewModel() { }
    }
}