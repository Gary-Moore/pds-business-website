using System.Collections.Generic;
using System.Threading.Tasks;
using ParliamentBusinessWebsite.Domain.Business;

namespace ParliamentBusinessWebsite.Services.Calendar
{
    public interface ICalendarService
    {
        Task<List<Event>> Get(SearchQueryParams searchParams);
    }
}
