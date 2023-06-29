// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.MVVM.ViewModels;
using Journey.MVVM.Views.Controls;
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
            PostControl pc = new PostControl();
            Posts.Content = pc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm.LoadedMyselfCommand.Execute(null);
        }
    }
}