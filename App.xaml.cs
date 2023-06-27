using Journey.Data.MSSQL;
using Journey.MVVM.Views;
using Journey.Security;
using System.Linq;
using System.Windows;

namespace Journey
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.ShutdownMode = ShutdownMode.OnLastWindowClose;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Hashing h = new Hashing();
            string hash;
            if (!string.IsNullOrEmpty(hash = h.ReadLog()))
            {
                hash = hash.Substring(0, h.GetHash("Login ").Length);
                hash = hash.Replace(h.GetHash(" Password "), "");
                
                using (ApplicationContext db = new ApplicationContext())
                {
                   var users = db.Users.Where(u => h.GetHash(u.Email + u.Password) == hash);
                    if (users.Count() != 0)
                    {
                        MainWindow = new MainWindow();
                        Windows[0].Close();
                        MainWindow.Show();
                    }
                }
            }
        }
    }
}