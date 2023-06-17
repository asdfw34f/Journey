using System.Windows;
using Journey;
using Journey.MVVM.ViewModels;

namespace Journey.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        AuthViewModel context;
        public AuthWindow()
        {
            context = new AuthViewModel();
            DataContext = context;
            InitializeComponent();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            context.Password = passwordBox.Password;
        }
    }
}
