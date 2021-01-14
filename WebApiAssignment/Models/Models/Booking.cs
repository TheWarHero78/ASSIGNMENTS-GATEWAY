using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Booking
    {

        public long ID { get; set; }
        public System.DateTime Booking_Date { get; set; }
        public long Room_ID { get; set; }
        public string Status { get; set; }

        public virtual Room Room { get; set; }
    }
}
