using CarsEntities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApi.Services
{
    public class DealerService
    {
        public List<Dealer> GetDealers()
        {
            var dealers = new List<Dealer>();
            for (int i = 1; i <= 7; i++)
            {

                dealers.Add(new Dealer
                {
                 
                    ID = i,
                    Name = $"Dealer_{i}",
                    Address = $"Address_{i}",
                    ExternalID = new Guid()

                });
            }
            return dealers;
        }
        public DealerCars GetCar(long id)
        {
            var dealer = GetDealers().Find(r => r.ID == id);
            var dealercar = new DealerCars()
            {
                Id = 1,
                Dealer = dealer,
                DealerId = dealer.ID
            };
            var cars = new CarService().GetCars().FindAll(r => r.DealerID == id);
            dealercar.Cars = cars;
            return dealercar;


        }
        public DealerDrivers GetDriver(long id)
        {
            var dealer = GetDealers().Find(r => r.ID == id);
            var dealerDrivers = new DealerDrivers()
            {
                Id = 1,
                Dealer = dealer,
                DealerID = dealer.ID
            };
            var drivers = new DriverService().GetDrivers().FindAll(r => r.DealerID == id);
            dealerDrivers.Drivers = drivers;
            return dealerDrivers;


        }
    }
}
