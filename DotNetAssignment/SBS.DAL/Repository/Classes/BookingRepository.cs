using AutoMapper;
using SBS.BusinessEntities;
using SBS.DAL.Models;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Classes
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Models.DBSBSEntities1 _dbContext;
        public BookingRepository()
        {
            _dbContext = new Models.DBSBSEntities1();
        }



        public bool deleteBookingDetails(string exID)
        {
            try
            {
                Booking booking = _dbContext.Bookings.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();
                if (booking.Status != null)
                {
                    booking.Status = "Deleted";
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // return false;
            }
            return false;

        }
    

        public List<BookingViewModel> getAllBooking()
        {
            List<BookingViewModel> list = new List<BookingViewModel>();
            try
            {
                var entities = _dbContext.Bookings.OrderBy(c => c.CreatedDate).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Booking, BookingViewModel>());
                        var mapper = new Mapper(config);
                        BookingViewModel booking = mapper.Map<BookingViewModel>(item);

                        list.Add(booking);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public List<BookingViewModel> getAllBookingByCust(string custExID)
        {
            List<BookingViewModel> list = new List<BookingViewModel>();
            try
            {
                var entities = _dbContext.Bookings.Where(s => custExID.Equals(s.Customer.ExternalID.ToString())).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Booking, BookingViewModel>());
                        var mapper = new Mapper(config);
                        BookingViewModel booking = mapper.Map<BookingViewModel>(item);

                        list.Add(booking);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    

        public BookingViewModel getBookingByExID(string exID)
        {
            BookingViewModel booking = new BookingViewModel();
            try
            {
                var Mbooking = _dbContext.Bookings.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();

                if (Mbooking.Status != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Booking, BookingViewModel>());
                    var mapper = new Mapper(config);
                    booking = mapper.Map<BookingViewModel>(Mbooking);


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return booking;
        }

        public bool registerBooking(BookingViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingViewModel, Models.Booking>());
                var mapper = new Mapper(config);
                Models.Booking booking = mapper.Map<Models.Booking>(model);
                booking.ID = 0;
                booking.ExternalID = Guid.NewGuid();
                booking.CreatedBy = 1;
                booking.CreatedDate = DateTime.Now;
                booking.Status = "Created";
                _dbContext.Bookings.Add(booking);
                _dbContext.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.EntityCommandCompilationException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;

        }

        public bool updateBookingDetails(BookingViewModel model)
        {
            try
            {
                Booking booking = _dbContext.Bookings.Where(s => model.ExternalID.Equals(s.ExternalID)).FirstOrDefault();
                if (booking.EndDateTime != null)
                {

                    model.UpdatedBy = 1;
                    model.UpdatedDate = DateTime.Now.Date;
                    model.Charge = _dbContext.Services.SingleOrDefault(s => model.ServiceID == s.ID).Charge;
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<BookingViewModel, Booking>());
                    var mapper = new Mapper(config);
                    mapper.Map<BookingViewModel, Booking>(model, booking);                  
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.EntityCommandCompilationException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (Exception ex)
            {

                return false;
            }
            return false;

        }
    
    }
}
