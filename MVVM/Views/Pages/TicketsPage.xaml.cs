// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.GetData;
using Journey.MVVM.Models.Tables;
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
            GetFavorites.Get();

            List<UserControl> ch = new();

            int i = 0;
            int f = 0;
            if (GetFavorites.count > 0)
            {
                while (i < GetTickets.Tickets.Count)
                {
                    ch.Add(new TicketControl() { Name = GetTickets.Tickets[i].SearchToken });
                    if ((f != GetFavorites.count) && ch[i].Name == GetFavorites.Favorites[f].Token)
                    {
                        _ = LikeOnList.Children.Add(ch[i]);
                        f++;
                    }
                    else
                        TicketsList.Children.Add(ch[i]);
                    i++;
                }
            }
            else
            {
                while (i < GetTickets.Tickets.Count)
                {
                    ch.Add(new TicketControl() { Name = GetTickets.Tickets[i].SearchToken });
                    _ = TicketsList.Children.Add(ch[i]);
                    i++;
                }
            }
            
        }
    }
}