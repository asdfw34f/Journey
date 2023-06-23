using Journey.MVVM.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Journey.MVVM.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        AuthViewModel context;

        public AuthPage()
        {
            InitializeComponent();
            context = new AuthViewModel();
            DataContext = context;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
                context.Password = passwordBox.Password;
        }
    }
}