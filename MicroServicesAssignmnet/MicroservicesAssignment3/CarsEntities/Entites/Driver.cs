using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsEntities.Entites
{
   public class Driver
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public byte Experience { get; set; }
        public string Sex { get; set; }    
        public string LicenseNumber { get; set; }
        public System.Guid ExternalID { get; set; }
        public long DealerID { get; set; }
    }
}
