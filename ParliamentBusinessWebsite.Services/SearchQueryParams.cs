using System;

namespace ParliamentBusinessWebsite.Services
{
    public class SearchQueryParams
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EventId { get; set; }
    }
}
