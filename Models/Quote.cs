using Cloudy.CMS.UI.FieldSupport.Select;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApplication.Models
{
    public class Quote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Select<Opportunity>]
        public int Opportunity { get; set; }

        public string Name { get; set; }
        [UIHint("html")]
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Sent { get; set; }
    }
}
