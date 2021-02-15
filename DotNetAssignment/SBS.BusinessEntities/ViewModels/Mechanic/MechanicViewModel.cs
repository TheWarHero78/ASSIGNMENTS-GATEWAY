using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
  public  class MechanicViewModel
    {
        [Key]
        public System.Guid ExternalID { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "MobileNo is Required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "DealerID is Required")]
        public long DealerID { get; set; }
    }
}
