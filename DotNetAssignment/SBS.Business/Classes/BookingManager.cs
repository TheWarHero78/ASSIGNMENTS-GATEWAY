using SBS.Business.Interfaces;
using SBS.BusinessEntities;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Classes
{
    public class BookingManager : IBooking
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public bool deleteBookingDetails(string exID)
        {
            return _bookingRepository.deleteBookingDetails(exID);
        }

        public List<BookingViewModel> getAllBooking()
        {
            return _bookingRepository.getAllBooking();
        }

        public List<BookingViewModel> getAllBookingByCust(string custExID)
        {
            return _bookingRepository.getAllBookingByCust(custExID);
        }

        public BookingViewModel getBookingByExID(string exID)
        {
            return _bookingRepository.getBookingByExID(exID);
        }

        public bool registerBooking(BookingViewModel model)
        {
            return _bookingRepository.registerBooking(model);
        }

        public bool updateBookingDetails(BookingViewModel model)
        {
            return _bookingRepository.updateBookingDetails(model);
        }
    }
}
