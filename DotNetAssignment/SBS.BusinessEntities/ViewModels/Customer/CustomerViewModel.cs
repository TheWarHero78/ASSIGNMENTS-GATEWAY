using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
    public class CustomerViewModel
    {
        [Key]
        public System.Guid ExternalID { get ; set; }       
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address1 is Required")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Address2 is Required")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "ZipCode is Required")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Mobile is Required")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        public string PhoneNo { get; set; }
        public Nullable<long> UserID { get; set; }
    }
}
