using SBS.DAL.Repository.Classes;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;

namespace SBS.Business.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IMechanicRepository, MechanicRepository>();
            Container.RegisterType<IDealerRepository, DealerRepository>();
            Container.RegisterType<IServiceRepository,ServiceRepository>();
            Container.RegisterType<IVehicleRepository,VehicleRepository>();
            Container.RegisterType<IBookingRepository,BookingRepository>();
            //Container.RegisterType<ICarRepository, CarRepository>();
        }
    }
}
