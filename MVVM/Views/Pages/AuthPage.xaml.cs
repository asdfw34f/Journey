using Journey.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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