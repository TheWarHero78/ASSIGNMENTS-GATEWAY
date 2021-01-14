using DAL.Repository.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace DAL.Repository.Classes
{
    public class RoomRepository : IRoomRepository
    {
        enum BookingsStatus
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }
        private readonly EntityDB.DBHotelsEntities1 _dbContext;
        public RoomRepository()
        {
            _dbContext = new EntityDB.DBHotelsEntities1();
        }

        public string bookRoom(Booking model)
        {
            try
            {
                if (model!=null)
                {
                    var bookingRecord = _dbContext.Bookings.Where(m => m.ID == model.ID && m.Booking_Date == model.Booking_Date).FirstOrDefault();
                    if (bookingRecord == null)
                    {
                        EntityDB.Booking booking = new EntityDB.Booking();
                        booking.Room_ID = model.Room_ID;
                        booking.Status = BookingsStatus.Optional.ToString();
                        booking.Booking_Date = model.Booking_Date;
                        _dbContext.Bookings.Add(booking);
                        _dbContext.SaveChanges();
                        return "Booking sucessfull for "+ model.Booking_Date +" with Room ID:" + booking.Room_ID + " having "+ booking.Status+ " status";
                    }
                    else
                    {
                        return "Sorry , it is already booked by someone else on "+ model.Booking_Date;
                    }
                }
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool checkRoomAvailability(long id, DateTime date)
        {
            try
            {
                if (id != null && date != null)
                {
                    var bookingRecord=_dbContext.Bookings.Where(m => m.Room_ID==id && DbFunctions.TruncateTime(m.Booking_Date)==date).FirstOrDefault();
                    if (bookingRecord == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {

                return false;
            }
        }

        public string createRoom(Room entity)
        {
            try
            {
                if (entity != null)
                {
                  
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Room, EntityDB.Room>());
                    var mapper = new Mapper(config);
                    EntityDB.Room room = mapper.Map<EntityDB.Room>(entity);
                    room.Created_Date = DateTime.Now;



                    //EntityDB.Room room = new EntityDB.Room();
                    //room.ID = entity.ID;
                    //room.Name = entity.Name;
                    //room.Price = entity.Price;
                    //room.IsActive = entity.IsActive;
                    //room.Created_Date = entity.Created_Date;
                    //room.Created_By = entity.Created_By;
                    //room.Updated_Date = entity.Updated_Date;
                    //room.Updated_By = entity.Updated_By;
                    //room.Hotel_ID = entity.Hotel_ID;



                    _dbContext.Rooms.Add(room);
                    _dbContext.SaveChanges();

                    return "Successfully Created New Room!!";
                }
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Room> searchRoom(string city = null, decimal? pincode = null, int? price = null, string category = null)
        {
            
            var entities = _dbContext.Rooms.ToList();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EntityDB.Room, Room>());
            List<Room> list = new List<Room>();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                 
                    var mapper = new Mapper(config);
                    Room room = mapper.Map<Room>(item);
                    room.Created_Date = DateTime.Now;
                    //Mapper.CreateMap<EntityDB.Room,Room>();
                    //Room room = Mapper.Map<Room>(item);

                    //room.ID = item.ID;
                    //room.Name = item.Name;
                    //room.Price = item.Price;
                    //room.IsActive = item.IsActive;

                    //room.Created_By = item.Created_By;
                    //room.Updated_Date = item.Updated_Date;
                    //room.Updated_By = item.Updated_By;
                    //room.Hotel_ID = item.Hotel.ID;
                    list.Add(room);
                }
            }
            return list;
           
        }

    }
}
