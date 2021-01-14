using DAL.Repository.Classes;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepository, HotelRepository>();
            Container.RegisterType<IRoomRepository, RoomRepository>();
            Container.RegisterType<IBookingRepository,BookingRepository>();
        }
    }
}
