﻿using Journey.MVVM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.MVVM.ViewModels.Pages
{
    internal class RegisterViewModel: NotifyPropertyChanged
    {
        private string _Name;
        private string _Surename;
        private DateTime _Date;
        private string _Email;
        private string _Login;
        private string _Password;

        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        public string Surename
        {
            get => _Surename;
            set => Set(ref _Surename, value);
        }

        public DateTime Date
        {
            get => _Date;
            set => Set(ref _Date, value);
        }

        public string Enail
        {
            get => _Email;
            set => Set(ref _Email, value);
        }

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
    }
}