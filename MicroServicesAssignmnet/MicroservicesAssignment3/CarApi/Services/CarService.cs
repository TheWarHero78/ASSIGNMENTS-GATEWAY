using CarsEntities.Entites;
using CarsEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApi.Services
{
    public class CarService
    {
        public List<Car> GetCars()
        {
            var cars = new List<Car>();
            for (int i = 1; i <= 7; i++)
            {
                cars.Add(new Car
                {
                    ID = i,
                    Brand = CarBrandEnum.Audi.ToString(),
                    Type = CarTypeEnum.MUV.ToString(),
                    Capacity = i.ToString(),
                    Mileage = i.ToString(),
                    RegNumber = i.ToString(),
                    Booked = false,
                    SupplierID = i,
                    DealerID = i,
                    ExternalID = new Guid()

                });
            }
            return cars;


        }
    }
}
