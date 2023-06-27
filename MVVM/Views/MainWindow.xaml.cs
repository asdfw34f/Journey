using Journey.MVVM.ViewModels;
using System.Windows;

namespace Journey.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            DataContext = vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}