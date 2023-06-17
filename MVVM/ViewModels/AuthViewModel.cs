using Journey.MVVM.Base;
using System.ComponentModel;
using System.Windows.Input;

namespace Journey.MVVM.ViewModels
{
    public class AuthViewModel: NotifyPropertyChanged
    {
        private string _Message;

        private string _Login;
        private string _Password;

        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        public string Password
        {
            get => _Login;
            set => Set(ref _Password, value);
        }

        public ICommand EnterCommand { get; }
        private bool CanEnter(object p)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                return false;
            else
                return true;
        }
        private void OnEnter(object p)
        {

        }

        public AuthViewModel()
        {
            Login = string.Empty;
            Password = string.Empty;
        }

    }
}