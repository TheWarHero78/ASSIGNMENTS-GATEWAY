using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
    public class DealerViewModel
    {
        [Key]
        public System.Guid ExternalID { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address1 is Required")]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Address2 is Required")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "ZipCode is Required")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "ContactPerson is Required")]
        public string ContactPerson { get; set; }
        [Required(ErrorMessage = "ContactNo is Required")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "PhoneNo is Required")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Speciality is Required")]
        public string Speciality { get; set; }
        [Required(ErrorMessage = "UserID is Required")]
        public long UserID { get; set; }
        [Required(ErrorMessage = "Approved is Required")]       
        public bool Approved { get; set; }
    }
}
