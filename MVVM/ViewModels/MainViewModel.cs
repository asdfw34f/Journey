// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.MSSQL;
using Journey.Infrastructure.Commands;
using Journey.MVVM.Base;
using Journey.MVVM.Models;
using Journey.Security;
using System;
using System.Windows;
using System.Windows.Input;

namespace Journey.MVVM.ViewModels
{
    class MainViewModel : NotifyPropertyChanged
    {
        private string _Name;
        private string _Surname;
        private string _Description;
        private DateTime _Date;

        private Users _User;

        public string Name
        {
            get => Name;
            set=>Set(ref  _Name, value);
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

        public ICommand LoadedMyselfCommand{ get; }
        private bool CanLoadedMyself(object p) => true;
        private void OnLoadedMyself(object p)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
            }
        }

        public ICommand ExitCommand { get; }
        private bool CanExit(object p) => true;
        private void OnExit(object p)
        {
            FileLog log = new FileLog();
            log.FileDelete();
            Application.Current.Shutdown();
        }

        public MainViewModel()
        {
            ExitCommand = new LambdaCommand(OnExit, CanExit);

        }
    }
}