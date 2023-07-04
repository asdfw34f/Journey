// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows;
using System.Windows.Controls;

namespace Journey.MVVM.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void passwordBox_Copy_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Label_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Navigate back one page from this page, if there is an entry
            // in back navigation history
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                GC.Collect(); // find finalizable objects
                GC.WaitForPendingFinalizers(); // wait until finalizers executed
                GC.Collect(); // collect finalized objects

            }
        }
    }
}