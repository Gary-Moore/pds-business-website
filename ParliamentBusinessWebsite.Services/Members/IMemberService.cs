using System.Threading.Tasks;
using ParliamentBusinessWebsite.Domain.Members;

namespace ParliamentBusinessWebsite.Services.Members
{
    public interface IMemberService
    {
        Task<Member> Get(int id);
    }
}