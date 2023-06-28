using Journey.MVVM.Models;
using Journey.MVVM.Views;
using Journey.Security;
using System;
using System.Windows;

namespace Journey
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Users User;

        public App()
        {
            this.ShutdownMode = ShutdownMode.OnLastWindowClose;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            FileLog log = new FileLog();
            bool isLog = log.CheckLogFile();
            if (isLog)
            {
                User = log.ReadLogAsync();
                if (User != null)
                {
                    MainWindow = new MainWindow();
                    MainWindow.Show();
                }
            }
            else
            {
                MainWindow = new LogWindow();
                MainWindow.Show();
            }
        }
    }
}