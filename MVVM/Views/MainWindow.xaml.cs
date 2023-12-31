﻿// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.GetData;
using Journey.MVVM.ViewModels;
using Journey.MVVM.Views.Pages;
using System;
using System.Windows;

namespace Journey.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            DataContext = vm;
            profile.DataContext = vm;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm.LoadedMyselfCommand.Execute(null);
        }

        private void Label_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            StackPwd.Visibility = StackPwd.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.ExitCommand.Execute(null);
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            GetTickets.GetFile();
            list.Content = new TicketsPage();
            BuyBtn.IsEnabled = false;
            ProfileBtn.IsEnabled = true;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            GC.Collect(); // find finalizable objects
            GC.WaitForPendingFinalizers(); // wait until finalizers executed
            GC.Collect(); // collect finalized objects

        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            GetTickets.count = -1;
            list.GoBack();
            ProfileBtn.IsEnabled = false;
            BuyBtn.IsEnabled = true;
        }
    }
}