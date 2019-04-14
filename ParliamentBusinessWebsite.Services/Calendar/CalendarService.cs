using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParliamentBusinessWebsite.Domain.Business;

namespace ParliamentBusinessWebsite.Services.Calendar
{
    public class CalendarService : ICalendarService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string CalendarUrl = "http://service.calendar.parliament.uk/calendar/events/list.json";

        public CalendarService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Event>> Get(SearchQueryParams searchParams)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(searchParams));
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Event>>(data);
            }
            else
            {
                throw new Exception("Error");
            }
        }

        private string BuildUrl(SearchQueryParams searchParams)
        {
            var query = new StringBuilder($"{CalendarUrl}?");
            query.Append($"queryParameters.startDate={searchParams.StartDate.ToString("yyyy-MM-dd", CultureInfo.CurrentUICulture)}");

            if (searchParams.EndDate.HasValue)
            {
                query.Append($"&queryParameters.endDate={searchParams.EndDate.Value.ToString("yyyy-MM-dd", CultureInfo.CurrentUICulture)}");
            }
            
            query.Append($"&queryParameters.house=Commons");

            if (searchParams.EventId.HasValue)
            {
                query.Append($"&queryParameters.eventId={searchParams.EventId}");
            }

            return query.ToString();
        }
    }
}
