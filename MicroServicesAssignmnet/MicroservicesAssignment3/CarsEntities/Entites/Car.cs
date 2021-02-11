using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsEntities.Entites
{
   public class Car
    {
        public long ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
        public string Mileage { get; set; }
        public string RegNumber { get; set; }
        public bool Booked { get; set; }
        public long SupplierID { get; set; }
        public long DealerID { get; set; }
        public System.Guid ExternalID { get; set; }
    }
}
