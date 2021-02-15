using SBS.Business.Classes;
using SBS.Business.Helper;
using SBS.Business.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace SBS.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUser, UserManager>();
            container.RegisterType<IVehicle,VehicleManager>();
            container.RegisterType<IService, ServiceManager>();
            container.RegisterType<IDealer, DealerManager>();
            container.RegisterType<IMechanic, MechanicManager>();
            container.RegisterType<ICustomer,CustomerManager>();
            container.RegisterType<IBooking,BookingManager>();
            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}