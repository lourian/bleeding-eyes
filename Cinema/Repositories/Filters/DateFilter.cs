using System;

namespace Cinema.Repositories.Filters
{
    public class DateFilter : IFilter
    {
        public int EntityId { get; set; }

        public DateTime Date { get; set; }
    }
}
