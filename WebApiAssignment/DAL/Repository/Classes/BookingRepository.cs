using DAL.Repository.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data.Entity;

namespace DAL.Repository.Classes
{
    public class BookingRepository : IBookingRepository
    {
        enum BookingsStatus
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }
        private readonly EntityDB.DBHotelsEntities _dbContext;
        public BookingRepository()
        {
            _dbContext = new EntityDB.DBHotelsEntities();
        }

        public string deleteBooking(Booking model)
        {
            try
            {
                if (model.ID != null)
                {

                    EntityDB.Booking booking = _dbContext.Bookings.Find(model.ID);
                    if (booking != null)
                    {
                        booking.Status = BookingsStatus.Deleted.ToString();
                        _dbContext.SaveChanges();
                        return " Changed Status of Booking ID" + model.ID + " to " + booking.Status;
                    }
                    else
                    {
                        return " Oops we cannot find any booking with ID:" + model.ID; 
                    }
                }
                 throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Booking> getAllBooking()
        {
            var entities = _dbContext.Bookings.ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EntityDB.Booking, Booking>());
            List<Booking> list = new List<Booking>();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                   
                    
                    var mapper = new Mapper(config);
                    Booking booking = mapper.Map<Booking>(item);

                    //Booking booking = new Booking();
                    //booking.ID = item.ID;
                    //booking.Booking_Date = item.Booking_Date;
                    //booking.Room_ID = item.Room_ID;
                    //booking.Status = item.Status;

                    list.Add(booking);




                }
            }
            return list;
        }

        public string updateBooking(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var bookingRecord = _dbContext.Bookings.Where(m => m.ID == model.ID).FirstOrDefault();
                    if (bookingRecord != null)
                    {
                        if (bookingRecord.Status == BookingsStatus.Optional.ToString() || bookingRecord.Status == BookingsStatus.Definitive.ToString())
                        {
                            
                            var previousBookingDate = bookingRecord.Booking_Date;
                            bookingRecord.Booking_Date = model.Booking_Date;
                            _dbContext.SaveChanges();

                            return " Bravo Your Request is sucessfully completed Booking of room no " + model.Room_ID;

                        }
                        return " Sorry we cannot process your request due to change in  booking status";
                    }
                    else
                    {
                        return "Sorry your request cannot be processed due to no booking exist for requested Room ID " + model.Room_ID;
                    }
                }
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string updateBookingStatus(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var bookingRecord = _dbContext.Bookings.Where(m => m.ID == model.ID).FirstOrDefault();
                    if (bookingRecord != null)
                    {
                        if (bookingRecord.Status == BookingsStatus.Optional.ToString() || bookingRecord.Status == BookingsStatus.Definitive.ToString())
                        {
                            bookingRecord.Status = model.Status;
                            _dbContext.SaveChanges();
                        
                            return "Sucessfully updated status for Booking ID " + model.ID + " with " + model.Status;
                        }
                        return "Booking of room no " + model.ID + " has been " + bookingRecord.Status + ". So the booking status cannot be modified";
                    }
                    else
                    {
                        return "Sorry your request cannot be processed due to no booking exist for requested Booking ID " + model.ID;
                    }
                }
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
