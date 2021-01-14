using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> searchRoom(string city = null, decimal? pincode = null, int? price = null, string category = null);
        string createRoom(Room model);
        bool checkRoomAvailability(long id, DateTime date);
        string bookRoom(Booking model);
    }
}
