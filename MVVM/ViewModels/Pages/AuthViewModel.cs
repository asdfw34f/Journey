using Journey.Data;
using Journey.Infrastructure.Commands;
using Journey.MVVM.Base;
using Journey.MVVM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Journey.MVVM.ViewModels.Pages
{
    internal class AuthViewModel: NotifyPropertyChanged
    {
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
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> user = db.Users.Where(u => u.Password == Password && u.Email == Login).ToList();
                if (user != null)
                {
                    MessageBox.Show("URA");
                }
            }
        }

        public AuthViewModel()
        {
            Login = string.Empty;
            Password = string.Empty;

            EnterCommand = new LambdaCommand(OnEnter, CanEnter);
        }

    }
}