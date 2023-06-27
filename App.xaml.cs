using Journey.Data.MSSQL;
using System.IO;
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
            try
            {
                using (FileStream f = new FileStream(
                         System.Reflection.Assembly.GetExecutingAssembly().Location + "user.melog",
                         FileMode.Open))
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {

                    }
                }


            }
            catch (FileNotFoundException)
            {
                
            }
            
        }
    }
}
