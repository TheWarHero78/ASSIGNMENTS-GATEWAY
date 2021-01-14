using BAL.Interfaces;
using DAL.Repository.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Classes
{
    public class HotelManager : IHotel
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string createHotel(Hotel model)
        {
            return _hotelRepository.createHotel(model);
        }

        public List<Hotel> getAllHolels()
        {
            return _hotelRepository.getAllHolels();
        }

    

        public Hotel getHotel(long id)
        {
            return _hotelRepository.getHotel(id);
        }
    }
}
