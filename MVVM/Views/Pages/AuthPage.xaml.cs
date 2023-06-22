using Journey.MVVM.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
        }
    }
}