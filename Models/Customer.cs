using Cloudy.CMS.ContentSupport;
using Cloudy.CMS.UI.FormSupport.FieldTypes;
using Cloudy.CMS.UI.List;
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
        [ListColumn]
        [Select(typeof(Company))]
        public Guid CompanyId { get; set; }
    }
}
