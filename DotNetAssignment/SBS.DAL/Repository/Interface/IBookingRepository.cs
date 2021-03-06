﻿using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Interface
{
 public interface IBookingRepository
    {
        Boolean registerBooking(BookingViewModel model);
        Boolean updateBookingDetails(BookingViewModel model);
        Boolean deleteBookingDetails(String exID);
        BookingViewModel getBookingByExID(String exID);
        List<BookingViewModel> getAllBooking();
        List<BookingViewModel> getAllBookingByCust(String custExID);


    }
}
