// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.MVVM.ViewModels;
using Journey.MVVM.Views.Controls;
using Journey.MVVM.Views.Pages;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

namespace Journey.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            DataContext = vm;
            list.Content = new ProfileView();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm.LoadedMyselfCommand.Execute(null);
        }
    }
}