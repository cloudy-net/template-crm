using Cloudy.CMS.EntitySupport;

namespace CrmApplication.Models
{
    public class Order : INameable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public int? ContactId { get; set; }
    }
}
