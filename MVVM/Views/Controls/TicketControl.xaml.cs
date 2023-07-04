// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Journey.MVVM.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для TicketControl.xaml
    /// </summary>
    public partial class TicketControl : UserControl
    {
        public TicketControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.Name == "true")
            {
                fav.Content = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(App.ResourceAssembly.Location) + "//Assets//LikeOn.png"));

            }
        }
    }
}
