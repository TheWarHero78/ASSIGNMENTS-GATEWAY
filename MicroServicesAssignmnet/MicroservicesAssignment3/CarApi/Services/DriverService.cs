using CarsEntities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApi.Services
{
    public class DriverService
    {
        public List<Driver> GetDrivers()
        {
            var drivers = new List<Driver>();
            for (int i = 1; i <= 7; i++)
            {
                drivers.Add(new Driver
                {


                    Name = $"Name_{i}",
                    Experience = Convert.ToByte(i),
                    Sex = "Male",
                    LicenseNumber = $"License_{i}",
                    DealerID = i,
                    ExternalID = new Guid()

                });
            }
            return drivers;
        }
    }
}
