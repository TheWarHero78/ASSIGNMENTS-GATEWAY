using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IHotelRepository
    {
        Hotel getHotel(long id);
        List<Hotel> getAllHolels();
        string createHotel(Hotel model);
    }
}
