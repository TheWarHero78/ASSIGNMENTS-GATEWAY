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
    public class RoomManager : IRoom
    {
        private readonly IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public string bookRoom(Booking model)
        {
            return _roomRepository.bookRoom(model);
        }

        public bool checkRoomAvailability(long id, DateTime date)
        {
            return _roomRepository.checkRoomAvailability(id, date);
        }

        public string createRoom(Room model)
        {
            return _roomRepository.createRoom(model);
        }

        public List<Room> searchRoom(string city = null, decimal? pincode = null, int? price = null, string category = null)
        {
            return _roomRepository.searchRoom(city,pincode,price,category);
        }
    }
}
