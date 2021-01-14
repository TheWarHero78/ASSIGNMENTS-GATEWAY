using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IHotel
    {
        Hotel getHotel(long id);
        List<Hotel> getAllHolels();
        string createHotel(Hotel model);
    }
}
