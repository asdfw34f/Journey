using Journey.MVVM.ViewModels;
using System.Windows;

namespace Journey.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        LogViewModel context;
        public LogWindow()
        {
            InitializeComponent();
            
            context = new LogViewModel();
            DataContext = context;

        }

        private void LoginBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            {
                passwordBox.Focus();
            }
        }

        private void passwordBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)
            {
                LoginBox.Focus();
            }
            else if (e.Key == System.Windows.Input.Key.Enter)
            {
                EnterBTN.Command.Execute(null);
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            context.Password = passwordBox.Password.ToString();

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void passwordBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            passwordBox.Clear();
        }
    }
}