// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.MSSQL;
using Journey.Infrastructure.Commands;
using Journey.Infrastructure.Navigate;
using Journey.MVVM.Base;
using Journey.MVVM.Models;
using Journey.Security;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Journey.MVVM.ViewModels
{
    public class LogViewModel : NotifyPropertyChanged
    {
        private Visibility _Visable = Visibility.Visible;
        public Visibility Visable
        {
            get => _Visable;
            set => Set(ref _Visable, value);
        }

        private bool _isAuth = false;
        public bool IsAuth
        {
            get => _isAuth;
            set => Set(ref _isAuth, value);
        }

        private string _Login;
        private string _Password;

        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }

        public ICommand EnterCommand { get; }
        private bool CanEnter(object p)
        {
            return true;
        }

        private async void OnEnterAsync(object p)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                _ = string.IsNullOrEmpty(Login)
                    ? MessageBox.Show(
                        "Заполните поле логина",
                        "Ошибка авторизации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop
                        )
                    : MessageBox.Show(
                        "Заполните поле пароля",
                        "Ошибка авторизации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Stop
                        );
                return;
            }

            Users? user;
            using (ApplicationContext db = new())
            {
                user = db.Users
                .Where(p => p.Email == Login.ToString() &&
                p.Password == Password.ToString()).FirstOrDefault();
            }

            if (user != null)
            {
                FileLog fl = new FileLog();
                await fl.WriteLogAsync(user);
                
                Navigate navigate = new Navigate();
                await navigate.ToMainAsync();
            }
        }


        private Visibility _menuVis = Visibility.Collapsed;
        public Visibility MenuVis
        {
            get => _menuVis;
            set => Set(ref _menuVis, value);
        }

        public LogViewModel()
        {
            Login = string.Empty;
            Password = string.Empty;

            EnterCommand = new LambdaCommand(OnEnterAsync, CanEnter);
        }
    }
}