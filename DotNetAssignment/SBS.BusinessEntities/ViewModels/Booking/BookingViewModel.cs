using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
  public  class BookingViewModel
    {

      [Key]
        public System.Guid ExternalID { get; set; }        
        public Nullable<long> CustomerID { get; set; }
        public Nullable<long> MechanicID { get; set; }
        public Nullable<long> DealerID { get; set; }
        [Required(ErrorMessage = "VehicleID is Required")]
        public long VehicleID { get; set; }
        public Nullable<long> ServiceID { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> Charge { get; set; }
        [Required(ErrorMessage = "StartDateTime is Required")]
        [DataType(DataType.DateTime)]
        public System.DateTime StartDateTime { get; set; }
        [Required(ErrorMessage = "EndDateTime is Required")]
        [DataType(DataType.DateTime)]
        public System.DateTime EndDateTime { get; set; }
        [DataType(DataType.DateTime)]
        public System.DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        [Required(ErrorMessage = "Status is Required")]
        public  System.String  Status { get; set; }
      
     
       
              

    }
}
