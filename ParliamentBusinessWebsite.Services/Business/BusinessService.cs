using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParliamentBusinessWebsite.Domain.Business;
using ParliamentBusinessWebsite.Domain.Members;
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

        public async Task<BusinessItem> GetById(int id)
        {
            var searchParams = new SearchQueryParams()
            {
                EventId = id,
                StartDate = DateTime.MinValue
            };

            var eventItem = (await _calendarService.Get(searchParams)).FirstOrDefault();

            if (eventItem == null)
            {
                return null;
            }

            var item = new BusinessItem()
            {
                Id = eventItem.Id,
                Category = eventItem.Category,
                Type = eventItem.Type,
                StartDate = eventItem.StartDate,
                StartTime = eventItem.StartTime,
                EndDate = eventItem.EndDate,
                Description = eventItem.Description
            };

            foreach (var eventItemMember in eventItem.Members)
            {
                var member = await _memberService.Get(eventItemMember.Id);
                item.Members.Add(member);
            }

            return item;
        }
    }
}
