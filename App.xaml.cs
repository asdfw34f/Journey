// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.MVVM.Models;
using Journey.MVVM.Views;
using Journey.Security;
using System.Windows;

namespace Journey
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static Users? User { get; set; }

        public App()
        {
            ShutdownMode = ShutdownMode.OnLastWindowClose;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            FileLog log = new();
            bool isLog = log.CheckLogFile();
            if (isLog)
            {
                User = log.ReadLogAsync().Result;
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