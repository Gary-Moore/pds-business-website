using System;
using System.Collections.Generic;
using System.Text;

namespace ParliamentBusinessWebsite.Domain.Business
{
    public class Event
    {
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Description { get; set; }

        public string House { get; set; }

        public string Category { get; set; }
        public string Type { get; set; }
    }
}
