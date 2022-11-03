using Cloudy.CMS.ContentSupport;
using Cloudy.CMS.UI.FieldTypes.MediaPicker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApplication.Models
{
    public class Company : INameable, IImageable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        [UIHint("html")]
        public string Description { get; set; }
        [MediaPicker]
        public string Image { get; set; }
    }
}
