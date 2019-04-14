using System.Xml.Serialization;

namespace ParliamentBusinessWebsite.Domain.Members
{
    public class Member
    {
        [XmlAttribute("Member_Id")]
        public int Id { get; set; }

        public string DisplayAs { get; set; }

        public string ListAs { get; set; }

        public string FullTitle { get; set; }
    }
}
