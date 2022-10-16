using Cloudy.CMS.ContentSupport;
using Cloudy.CMS.UI.FormSupport.FieldTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApplication.Models
{
    public class Customer : INameable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        [UIHint("textarea")]
        public string Notes { get; set; }
        [Select(typeof(Company))]
        public Guid CompanyId { get; set; }
    }
}
