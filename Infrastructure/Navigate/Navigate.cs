using Journey.MVVM.Views;

namespace Journey.Infrastructure.Navigate
{
    internal class Navigate
    {

        public void ToMain()
        {
            App.Current.MainWindow = new MainWindow();
            App.Current.Windows[0].Close();
            App.Current.MainWindow.Show();
        }

        public void ToLog() 
        {
            App.Current.MainWindow = new LogWindow();
            App.Current.Windows[1].Close();
            App.Current.MainWindow.Show();
        }

        public Navigate() 
        {
        }
    }
}