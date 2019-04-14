using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParliamentBusinessWebsite.Domain.Business;
using ParliamentBusinessWebsite.Services.Business;
using ParliamentBusinessWebsite.Services.Calendar;

namespace ParliamentBusinessWebsite.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BusinessItem>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get([FromQuery] SearchQueryParams searchQueryParams)
        {
            var items = await _businessService.Get(searchQueryParams);

            return Ok(items);
        }
    }
}
