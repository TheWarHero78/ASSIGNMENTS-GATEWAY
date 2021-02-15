using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
  public class VehicleViewModel
    {
        [Key]    
        public System.Guid ExternalID { get; set; }        
        public string Brand { get; set; }
        public string Make { get; set; }
        public string Model1 { get; set; }
        public string LicensePlate { get; set; }
        public string ChasisNumber { get; set; }
        [DataType(DataType.Date)]
        public string LastServiceDate { get; set; }        
        public Nullable<long> CustomerID { get; set; }
    }
}
