using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsEntities.Entites
{
    public class DealerCars
    {

        public DealerCars(){
            Cars = new List<Car>();
        }
        
        public long Id { get; set; }
        public long DealerId { get; set; }
        public Dealer Dealer { get; set; }
        public List<Car> Cars { get; set; }
    }
}
