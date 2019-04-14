using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParliamentBusinessWebsite.Domain.Business;
using ParliamentBusinessWebsite.Services.Calendar;
using ParliamentBusinessWebsite.Services.Members;

namespace ParliamentBusinessWebsite.Services.Business
{
    public class BusinessService : IBusinessService
    {
        private readonly IMemberService _memberService;
        private readonly ICalendarService _calendarService;

        public BusinessService(IMemberService memberService, ICalendarService calendarService)
        {
            _memberService = memberService;
            _calendarService = calendarService;
        }

        public async Task<IList<BusinessItem>> Get(SearchQueryParams searchParams)
        {
            var events = await _calendarService.Get(searchParams);

            var items = events.Where(evt => evt.Type.ToLower() == "main chamber").Select(evt => new BusinessItem()
            {
                Id = evt.Id,
                Category = evt.Category,
                Type = evt.Type,
                StartDate = evt.StartDate,
                StartTime = evt.StartTime,
                EndDate = evt.EndDate,
                Description = evt.Description,
            }).OrderBy(evt => evt.StartDate).ToArray();

            return items;
        }
    }
}
