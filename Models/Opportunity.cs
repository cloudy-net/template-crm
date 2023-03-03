using Cloudy.CMS.UI.FieldSupport.Select;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApplication.Models
{
    public class Opportunity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Select<Person>]
        public int? ContactPerson { get; set; }
        [Select<Company>]
        public int? Company { get; set; }
    }
}
