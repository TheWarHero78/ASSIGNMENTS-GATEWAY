using AarshModi_CLPM.Models;


using CLPM.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPM.DAL.Repository.Classes
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly DBCLPMEntities1 _dbContext;
        public PassengerRepository()
        {
            _dbContext = new DBCLPMEntities1();
        }
        public bool deletePassengerDetails(string exID)
        {
            try
            {
                var passenger = _dbContext.Passengers.Where(s => (exID.Equals(s.PNumber.ToString()))).FirstOrDefault();
                if (passenger.FirstName != null)
                {
                    _dbContext.Passengers.Remove(passenger);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public IList<Passenger> getAllPassenger()
        {                    
                var entities = _dbContext.Passengers.OrderBy(c => c.FirstName).ToList();               
                return entities;
        }


        public Passenger getPassengerByexID(string exID)
        {
           
                var passenger = _dbContext.Passengers.Where(s => (exID.Equals(s.PNumber.ToString()))).FirstOrDefault();
                 return passenger;
        }

        public Passenger registerPassenger(Passenger model)
        {
           

                Passenger passenger = model;
                passenger.PNumber = Guid.NewGuid();
                _dbContext.Passengers.Add(passenger);
                _dbContext.SaveChanges();
           
            return model;
        }

        public Passenger updatePassengerDetails(Passenger model)
        {

            Passenger passenger = _dbContext.Passengers.Where(s => (model.Equals(s.PNumber.ToString()))).FirstOrDefault();
            _dbContext.Passengers.Attach(model);

            _dbContext.SaveChanges();
            return model;
        }
    }
}

