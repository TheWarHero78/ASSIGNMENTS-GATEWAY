using System.Web.Http;
using Unity;
using Unity.WebApi;
using BAL.Classes;
using BAL.Helper;
using BAL.Interfaces;
namespace Hotels_WebApi_AarshModi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();


            container.RegisterType<IHotel, HotelManager>();
            container.RegisterType<IRoom, RoomManager>();
            container.RegisterType<IBooking, BookingManager>();
            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}