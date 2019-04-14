using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ParliamentBusinessWebsite.Domain.Members;

namespace ParliamentBusinessWebsite.Services.Members
{
    public class MemberService : IMemberService
    {
        private string MemberUrl = "http://data.parliament.uk/membersdataplatform/services/mnis/members/query/";
        private readonly IHttpClientFactory _clientFactory;

        public MemberService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Member> Get(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{MemberUrl}id={id}");
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var serialiser = new XmlSerializer(typeof(List<Member>), new XmlRootAttribute("Members"));
                var content = await response.Content.ReadAsStringAsync();
                using (StringReader stringReader = new StringReader(content))
                {
                    return ((List<Member>)serialiser.Deserialize(stringReader)).FirstOrDefault();
                }
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
