using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using ParliamentBusinessWebsite.Domain.Business;
using ParliamentBusinessWebsite.Services;
using ParliamentBusinessWebsite.Services.Business;
using ParliamentBusinessWebsite.Services.Calendar;
using ParliamentBusinessWebsite.Services.Members;

namespace ParliamentBusinessWebsite.Test
{
    [TestFixture]
    public class BusinessServiceTests
    {
        private IBusinessService Sut;
        private IMemberService _memberService;
        private ICalendarService _calendarService;

        [SetUp]
        public void Setup()
        {
            _memberService = A.Fake<IMemberService>();
            _calendarService = A.Fake<ICalendarService>();
            Sut = new BusinessService(_memberService, _calendarService);
        }

        [Test]
        public async Task GetBusinesssItems_FilterMainChamber_MainChamberEventsReturnedOnly()
        {
            var events =  new List<Event>()
            {
                new Event()
                {
                    Type = "Main Chamber"
                },
                new Event()
                {
                    Type = "Westminster Hall"
                }
            };

            A.CallTo(() => _calendarService.Get(A<SearchQueryParams>._)).Returns(events);

            var result = await Sut.Get(new SearchQueryParams());

            Assert.That(result.All(item => item.Type == "Main Chamber"), Is.True);
        }
    }
}
