using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsEntities.Entites
{
   public class DealerDrivers
    {
        public DealerDrivers() { 
        Drivers = new List<Driver>();
        }

    public long Id { get; set; }
    public long DealerID { get; set; }
    public Dealer Dealer { get; set; }
    public List<Driver> Drivers { get; set; }
}
}
