using System;

namespace Journey.MVVM.Models.Tables
{
    [Serializable]
    public class Tickets
    {
        public string StartCity { get; set; }
        public string StartCityCode { get; set; }
        public string EndCity { get; set; }
        public string EndCityCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string SearchToken { get; set; }
    }
}
