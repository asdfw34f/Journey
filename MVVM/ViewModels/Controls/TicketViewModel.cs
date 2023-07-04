using Journey.Data.GetData;
using Journey.Data.MSSQL;
using Journey.Infrastructure.Commands;
using Journey.MVVM.Base;
using Journey.MVVM.Models.Tables;
using Journey.Security;
using System.Linq;
using System.Windows.Input;

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
        private string _token;

        public string Token
        {
            get => _token;
            set => Set(ref _token, value);
        }

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

        public ICommand AddTicketCommand { get; }
        private bool CanAddTicket(object p)
        {
            return true;
        }
        private void OnAddTicket(object p)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                FileLog log = new FileLog();
                int c = db.Favorites.Count();
                c++;
                db.Favorites.Add(new Favorites() {Email = log.ReadLog().Email, ID= c, Token=Token});
                db.SaveChangesAsync();
            }
        }


        public TicketViewModel()
        {
            Tickets = GetTickets.GetNext();
            Token = Tickets.SearchToken;
            StartCity = Tickets.StartCity;
            EndCity = Tickets.EndCity;
            StartDate = $"{Tickets.StartDate:f}";
            EndDate = $"{Tickets.EndDate:f}";
            Price = Tickets.Price.ToString();

            AddTicketCommand = new LambdaCommand(OnAddTicket, CanAddTicket);

        }
    }
}