using Journey.Data.GetData;
using Journey.MVVM.Base;
using Journey.MVVM.Models.Tables;

namespace Journey.MVVM.ViewModels.Controls
{
    internal class TicketViewModel : NotifyPropertyChanged
    {
        private readonly Tickets? Tickets;

        private string? _startCity;
        private string? _endCity;
        private string? _startDate;
        private string? _endDate;
        private string? _price;
        private readonly string? _SearchToken;

        public string StartCity
        {
            get => _startCity;
            set => Set(ref _startCity, value);
        }

        public string EndCity
        {
            get => _endCity;
            set => Set(ref _endCity, value);
        }

        public string StartDate
        {
            get => _startDate;
            set => Set(ref _startDate, value);
        }

        public string EndDate
        {
            get => _endDate;
            set => Set(ref _endDate, value);
        }

        public string Price
        {
            get => _price;
            set => Set(ref _price, value);
        }

        public TicketViewModel()
        {
            Tickets = GetTickets.GetNext();
        }
    }
}