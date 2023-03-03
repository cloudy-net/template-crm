using Cloudy.CMS.UI.FieldSupport.Select;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApplication.Models
{
    public class Invoice 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [Select<Quote>]
        public int Quote { get; set; }
        public DateOnly? PayBy { get; set; }
        public DateOnly? SentBy { get; set; }
    }
}
