using System.Collections.Generic;
using System.Threading.Tasks;
using ParliamentBusinessWebsite.Domain.Business;
using ParliamentBusinessWebsite.Services.Calendar;

namespace ParliamentBusinessWebsite.Services.Business
{
    public interface IBusinessService
    {
        Task<IList<BusinessItem>> Get(SearchQueryParams searchParams);
        Task<BusinessItem> GetById(int id);
    }
}