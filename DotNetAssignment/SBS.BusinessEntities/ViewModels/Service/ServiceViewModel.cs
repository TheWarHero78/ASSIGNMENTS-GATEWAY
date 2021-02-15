using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
 public class ServiceViewModel
    {
        [Key]
        public System.Guid ExternalID { get; set; }
        [Required(ErrorMessage = "Question is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Charge is Required")]
        public decimal Charge { get; set; }
        [Required(ErrorMessage = "Duration is Required")]
        [DataType(DataType.Duration)]
        public System.TimeSpan Duration { get; set; }
        [Required(ErrorMessage = "DealerID is Required")]
        public long DealerID { get; set; }
    }
}
