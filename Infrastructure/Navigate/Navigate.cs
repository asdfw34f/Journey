// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.MVVM.Views;
using System.Threading.Tasks;

namespace Journey.Infrastructure.Navigate
{
    internal class Navigate
    {

        public Task ToMainAsync()
        {
            App.Current.MainWindow = new MainWindow();
            App.Current.Windows[0].Close();
            App.Current.MainWindow.Show();
            return Task.CompletedTask;
        }

        public Task ToLogAsync()
        {
            App.Current.MainWindow = new LogWindow();
            App.Current.Windows[1].Close();
            App.Current.MainWindow.Show();
            return Task.CompletedTask;
        }

        public Navigate()
        {
        }
    }
}