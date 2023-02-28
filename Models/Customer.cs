using Cloudy.CMS.EntitySupport;
using Cloudy.CMS.UI.FieldSupport.Select;
using Cloudy.CMS.UI.List;
using Cloudy.CMS.UI.List.Filter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApplication.Models
{
    public class Customer : INameable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ListColumn]
        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        [UIHint("textarea")]
        public string Notes { get; set; }
        [ListFilter]
        [ListColumn]
        [Select<Company>]
        public Guid CompanyId { get; set; }
    }
}
