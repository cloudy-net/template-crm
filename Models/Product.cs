using Cloudy.CMS.EntitySupport;

namespace CrmApplication.Models
{
    public class Product : INameable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}