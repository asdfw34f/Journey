// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Infrastructure.Commands;
using Journey.MVVM.Base;
using Journey.MVVM.Models.Tables;
using Journey.Security;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Journey.MVVM.ViewModels
{
    internal class MainViewModel : NotifyPropertyChanged
    {
        private string _Name;
        private string _Surname;
        private string _Description;
        private string _Login;
        private string _Date;
        private readonly BitmapImage _Image;
        private Image _FinalImage = new();

        public Image FinalImage
        {
            get => _FinalImage;
            set => Set(ref _FinalImage, value);
        }

        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        public string Name
        {
            get => Name;
            set => Set(ref _Name, value);
        }

        public string Surname
        {
            get => Surname;
            set => Set(ref _Surname, value);
        }

        public string Description
        {
            get => Description;
            set => Set(ref _Description, value);
        }

        public string Date
        {
            get => _Date;
            set => Set(ref _Date, value);
        }

        public ICommand LoadedMyselfCommand { get; }
        private bool CanLoadedMyself(object p)
        {
            return true;
        }

        private void OnLoadedMyself(object p)
        {
            Users? users =  new FileLog().ReadLogAsync().Result;
            Login = users.Email;
            Name = users.Name;
            Surname = users.Surname;
            Date = $"{users.Date.Value:f}";

            //    User = new Users();
            //  User = App.User;
        }

        public ICommand ExitCommand { get; }
        private bool CanExit(object p)
        {
            return true;
        }

        private void OnExit(object p)
        {
            FileLog log = new();
            log.FileDelete();
            Application.Current.Shutdown();
        }

        public MainViewModel()
        {
            ExitCommand = new LambdaCommand(OnExit, CanExit);
            LoadedMyselfCommand = new LambdaCommand(OnLoadedMyself, CanLoadedMyself);
        }
    }
}