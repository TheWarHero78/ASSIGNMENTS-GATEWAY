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
    public class HotelRepository : IHotelRepository
    {

        private readonly EntityDB.DBHotelsEntities _dbContext;
        public HotelRepository()
        {
            _dbContext = new EntityDB.DBHotelsEntities();
        }
        public string createHotel(Hotel entity)
        {
          
            try
            {
                if (entity != null)
                {
                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Hotel, EntityDB.Hotel>());
                    var mapper = new Mapper(config);
                    EntityDB.Hotel hotel = mapper.Map<EntityDB.Hotel>(entity);
                    hotel.Created_Date = DateTime.Now;

                    //// TODO: manually mapping

                    //hotel.ID = entity.ID;
                    //hotel.Name = entity.Name;
                    //hotel.Address = entity.Address;
                    //hotel.City = entity.City;
                    //hotel.Pincode = entity.Pincode;
                    //hotel.Contact_Number = entity.Contact_Number;
                    //hotel.Contatct_Person = entity.Contatct_Person;
                    //hotel.Website = entity.Website;
                    //hotel.Facebook = entity.Facebook;
                    //hotel.Twitter = entity.Twitter;
                    //hotel.IsActive = entity.IsActive;

                    //hotel.Created_By = entity.Created_By;
                    //hotel.Updated_Date = entity.Updated_Date;
                    //hotel.Updated_By = entity.Updated_By;

                    _dbContext.Hotels.Add(hotel);
                    _dbContext.SaveChanges();

                    return "Hotel" + hotel.Name + " is successfully Added!!";
                }
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Hotel> getAllHolels()
        {
            List<Hotel> list = new List<Hotel>();
            try
            {
                var entities = _dbContext.Hotels.OrderBy(c => c.Name).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<EntityDB.Hotel, Hotel>());
                        var mapper = new Mapper(config);
                        Hotel hotel = mapper.Map<Hotel>(item);

                        //// TODO : manually mapping

                        //Hotel hotel = new Hotel();
                        //hotel.ID = item.ID;
                        //hotel.Name = item.Name;
                        //hotel.Address = item.Address;
                        //hotel.City = item.City;
                        //hotel.Pincode = item.Pincode;
                        //hotel.Contact_Number = item.Contact_Number;
                        //hotel.Contatct_Person = item.Contatct_Person;
                        //hotel.Website = item.Website;
                        //hotel.Facebook = item.Facebook;
                        //hotel.Twitter = item.Twitter;
                        //hotel.IsActive = item.IsActive;
                        //hotel.Created_Date = item.Created_Date;
                        //hotel.Created_By = item.Created_By;
                        //hotel.Updated_Date = item.Updated_Date;
                        //hotel.Updated_By = item.Updated_By;

                        list.Add(hotel);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public Hotel getHotel(long id)
        {
            var entity = _dbContext.Hotels.Where(c => c.ID == id).FirstOrDefault();
            Hotel hotel = null;
            if (entity != null)
            {
                //// TODO: automapper mapping

                var config = new MapperConfiguration(cfg => cfg.CreateMap<EntityDB.Hotel, Hotel>());
                var mapper = new Mapper(config);
                 hotel = mapper.Map<Hotel>(entity);

                //// TODO: manually mapping

                //hotel.ID = entity.ID;
                //hotel.Name = entity.Name;
                //hotel.Address = entity.Address;
                //hotel.City = entity.City;
                //hotel.Pincode = entity.Pincode;
                //hotel.Contact_Number = entity.Contact_Number;
                //hotel.Contatct_Person = entity.Contatct_Person;
                //hotel.Website = entity.Website;
                //hotel.Facebook = entity.Facebook;
                //hotel.Twitter = entity.Twitter;
                //hotel.IsActive = entity.IsActive;
                //hotel.Created_Date = entity.Created_Date;
                //hotel.Created_By = entity.Created_By;
                //hotel.Updated_Date = entity.Updated_Date;
                //hotel.Updated_By = entity.Updated_By;

                //Mapper.CreateMap<EntityDB.Hotel,Hotel>();
                //Hotel hotel = Mapper.Map<Hotel>(item);
                
            }
            return hotel;

        }

    }
}
