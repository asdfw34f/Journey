// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.MSSQL;
using Journey.Infrastructure.Commands;
using Journey.Infrastructure.Navigate;
using Journey.MVVM.Base;
using Journey.MVVM.Models.Tables;
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
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        private string _Password;
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

            Hashing hashing = new Hashing();

            if (hashing.EqualsLog(Password).Result)
            {
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