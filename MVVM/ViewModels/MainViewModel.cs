﻿using Journey.Data.MSSQL;
using Journey.Infrastructure.Commands.Base;
using Journey.MVVM.Base;
using Journey.MVVM.Models;
using System;
using System.Linq;
using System.Windows.Input;

namespace Journey.MVVM.ViewModels
{
    class MainViewModel : NotifyPropertyChanged
    {
        private string _Name;
        private string _Surname;
        private string _Description;
        private DateTime _Date;

        private User _User;

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


        public MainViewModel()
        {

        }
    }
}