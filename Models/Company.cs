using Cloudy.CMS.ContentSupport;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApplication.Models
{
    public class Company : INameable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
