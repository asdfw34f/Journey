// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Infrastructure.Commands;
using Journey.Infrastructure.Navigate;
using Journey.MVVM.Base;
using Journey.MVVM.Models.Tables;
using Journey.Security;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Journey.MVVM.ViewModels
{
    internal class MainViewModel : NotifyPropertyChanged
    {
        private string _Name;
        private string _Surname = "nsjifnjoildsf";
        private string _Description;
        private string _Login;
        private string _Date;
        private Image _FinalImage = new();

        public Image FinalImage
        {
            get => _FinalImage;
            set => Set(ref _FinalImage, value);
        }

        public string? Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        public string Surname
        {
            get => _Surname;
            set => Set(ref _Surname, value);
        }

        public string Description
        {
            get => _Description;
            set => Set(ref _Description, value);
        }

        public string Date
        {
            get => _Date;
            set => Set(ref _Date, value);
        }

        public ICommand LoadedMyselfCommand { get; }
        private bool CanLoadedMyself(object p) => true;
        private void OnLoadedMyself(object p)
        {
            Users users =  new FileLog().ReadLog();
            Login = users.Email;
            Name = users.Name;
            Surname = users.Surname;
            Date = $"{users.Date.Value:f}";
            Description = users.Status;
        }

        public ICommand ExitCommand { get; }
        private bool CanExit(object p) => true;
        private async void OnExit(object p)
        {
            new FileLog().FileDelete();
            await new Navigate().ToLogAsync();
        }


        public MainViewModel()
        {
            ExitCommand = new LambdaCommand(OnExit, CanExit);
            LoadedMyselfCommand = new LambdaCommand(OnLoadedMyself, CanLoadedMyself);
        }
    }
}