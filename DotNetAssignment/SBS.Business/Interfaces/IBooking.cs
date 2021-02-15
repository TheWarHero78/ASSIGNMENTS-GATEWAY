using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Interfaces
{
   public interface IBooking
    {
        Boolean registerBooking(BookingViewModel model);
        Boolean updateBookingDetails(BookingViewModel model);
        Boolean deleteBookingDetails(String exID);
        BookingViewModel getBookingByExID(String exID);
        List<BookingViewModel> getAllBooking();
        List<BookingViewModel> getAllBookingByCust(String custExID);
    }
}
