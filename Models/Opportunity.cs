using Cloudy.CMS.EntitySupport;
using Cloudy.CMS.UI.FieldSupport.Select;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApplication.Models
{
    public class Opportunity : INameable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public OpportunityLevel? Level { get; set; }

        [Select<Person>]
        public int? ContactPerson { get; set; }
        [Select<Company>]
        public int? Company { get; set; }
        [Select<Product>]
        public int? Product { get; set; }

        public enum OpportunityLevel
        {
            Low = 0,
            Medium = 1,
            High = 2,
        }
    }
}
