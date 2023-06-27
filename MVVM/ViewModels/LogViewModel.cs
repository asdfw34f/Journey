﻿using Journey.Data.MSSQL;
using Journey.Data.Resources.Safing;
using Journey.Infrastructure.Commands;
using Journey.Infrastructure.Navigate;
using Journey.MVVM.Base;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        private bool CanEnter(object p) => true;
        private void OnEnter(object p)
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                if (string.IsNullOrEmpty(Login))
                {
                    MessageBox.Show(
                        "Заполните поле логина", "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Stop
                        );
                }
                else
                {
                    MessageBox.Show(
                        "Заполните поле пароля", "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Stop
                        );
                }
                return;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users
                    .Where(p => (p.Email == Login.ToString() && p.Password == Password.ToString()));

                if (users.Count() != 0)
                {
                    Hashing h= new Hashing();
                    h.WriteLog(Login, Password);

                    Navigate navigate = new Navigate();
                    navigate.ToMain();
                }
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

            EnterCommand = new LambdaCommand(OnEnter, CanEnter);
        }
    }
}