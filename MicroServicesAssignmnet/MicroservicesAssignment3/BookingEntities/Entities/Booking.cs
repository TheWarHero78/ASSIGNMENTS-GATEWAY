using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEntities.Entities
{
   public class Booking
    {
        public long ID { get; set; }      
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public double Charges { get; set; }
        public long CustomerID { get; set; }
        public long CarID { get; set; }
        public Nullable<long> DriverID { get; set; }
        public System.Guid ExternalID { get; set; }


    }
}
