using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;

namespace DAL.Repository.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> getAllBooking();
        string updateBooking(Booking model);

        string updateBookingStatus(Booking model);
        string deleteBooking(Booking model);
    }
}
