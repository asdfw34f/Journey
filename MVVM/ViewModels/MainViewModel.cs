// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Infrastructure.Commands;
using Journey.MVVM.Base;
using Journey.MVVM.Models;
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
        private string _Password;
        private DateTime _Date;
        private BitmapImage _Image;
        private Image _FinalImage = new();

        private Users _User;

        public Image FinalImage
        {
            get => _FinalImage;
            set => Set(ref _FinalImage, value);
        }

        public Users User
        {
            get => _User;
            set => Set(ref _User, value);
        }

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

        public DateTime Date
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
            User = App.User;
            _Image = (BitmapImage)new System.Drawing.ImageConverter().ConvertFrom(User.Image);
            FinalImage.Source = _Image;
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