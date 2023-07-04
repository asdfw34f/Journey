using Journey.Data.GetData;
using Journey.MVVM.Models.Tables;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace Journey.MVVM.ViewModels.Pages
{
    internal class TicketsPageViewModel
    {
        private readonly string _start;
        private readonly string _end;
        private readonly List<UserControl> cntTickets;
        private readonly Tickets tickets;

        public ICommand SearchCommand { get; }
        private bool CanSearch()
        {
            return !string.IsNullOrEmpty(_end) && !string.IsNullOrEmpty(_start);
        }
        private void OnSearch(object p)
        {
          //  List<Tickets> search = tickets.Where(t => t.startCity == _start && t.endCity == _end).ToList();

        }

        private TicketsPageViewModel()
        {
         //   tickets = GetTickets.GetNext();
        }
    }
}