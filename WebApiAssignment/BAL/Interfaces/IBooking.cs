using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IBooking
    {
        List<Booking> getAllBooking();
        string updateBooking(Booking model);

        string updateBookingStatus(Booking model);
        string deleteBooking(Booking model);
    }
}
