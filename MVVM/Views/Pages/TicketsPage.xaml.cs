// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.GetData;
using Journey.MVVM.Views.Controls;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Journey.MVVM.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {
        public TicketsPage()
        {
            InitializeComponent();

            List<UserControl> ch = new List<UserControl>();

            int i = 0;
            while (i < GetTickets.Tickets.Count)
            {
                ch.Add(new TicketControl() { Name = GetTickets.Tickets[i].SearchToken });
                TicketsList.Children.Add(ch[i]);
                i++;
            }
        }
    }
}