using System;

namespace Journey.MVVM.Models
{
    [Serializable]
    public class Tickets
    {
        // {"startCity":"Москва","startCityCode":"mow",
        // "endCity":"Санкт-Петербург","endCityCode":"led",
        // "startDate":"2023-07-20T00:00:00Z","endDate":"2023-07-25T00:00:00Z",
        // "price":2690,"searchToken":"MOW2007LED2507Y100"},

        public string startCity { get; set; }
        public string startCodeCity { get; set; }
        public string endCity { get; set; }
        public string endCodeCity { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime endDate { get; set; }
        public string price { get; set; }
        public string SearchToken { get; set; }

    }
}
