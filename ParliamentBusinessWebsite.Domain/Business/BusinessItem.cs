using System;
using System.Collections.Generic;
using System.Text;
using ParliamentBusinessWebsite.Domain.Members;

namespace ParliamentBusinessWebsite.Domain.Business
{
    public class BusinessItem
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        public string Type { get; set; }

        public IEnumerable<Member> Members { get; set; } = new List<Member>();
    }
}
