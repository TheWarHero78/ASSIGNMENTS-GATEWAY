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
    public class MechanicRepository : IMechanicRepository
    {
        private readonly Models.DBSBSEntities1 _dbContext;
        public MechanicRepository()
        {
            _dbContext = new Models.DBSBSEntities1();
        }
        public bool deleteMechanicDetails(string exID)
        {
            try
            {
                Mechanic mechanic = _dbContext.Mechanics.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();
                if (mechanic.Name != null)
                {
                    mechanic.IsActive = false;
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


        public List<MechanicViewModel> getAllMechanics()
        {
            List<MechanicViewModel> list = new List<MechanicViewModel>();
            try
            {
                var entities = _dbContext.Mechanics.OrderBy(c => c.CreatedDate).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Mechanic, MechanicViewModel>());
                        var mapper = new Mapper(config);
                        MechanicViewModel mechanic = mapper.Map<MechanicViewModel>(item);

                        list.Add(mechanic);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public List<MechanicDropDown> getAllMechanicsByDealer(string dealerExID)
        {
            List<MechanicDropDown> list = new List<MechanicDropDown>();
            try
            {
                var entities = _dbContext.Mechanics.Where(s => (dealerExID.Equals(s.Dealer.ExternalID.ToString()))).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Mechanic, MechanicDropDown>());
                        var mapper = new Mapper(config);
                        MechanicDropDown mechanic = mapper.Map<MechanicDropDown>(item);

                        list.Add(mechanic);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }


        public MechanicViewModel getMechanicByExID(string exID)
        {
            MechanicViewModel mechanic = new MechanicViewModel();
            try
            {
                Models.Mechanic Mmechanic = _dbContext.Mechanics.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();

                if (Mmechanic.Name != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Mechanic, MechanicViewModel>());
                    var mapper = new Mapper(config);
                    mechanic = mapper.Map<MechanicViewModel>(Mmechanic);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return mechanic;
        }
    
        public bool registerMechanic(MechanicViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<MechanicViewModel, Models.Mechanic>());
                var mapper = new Mapper(config);
                Models.Mechanic mechanic = mapper.Map<Models.Mechanic>(model);
                mechanic.ID = 0;
                mechanic.ExternalID = Guid.NewGuid();
                mechanic.CreatedDate = DateTime.Now;
                mechanic.CreatedBy = 1;
                mechanic.IsActive = true;

                _dbContext.Mechanics.Add(mechanic);
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

        public bool updateMechanicDetails(MechanicViewModel model)
        {
            try
            {
                Mechanic mechanic = _dbContext.Mechanics.Where(s => model.ExternalID.Equals(s.ExternalID)).FirstOrDefault();
                if (mechanic.Name != null)
                {

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<MechanicViewModel, Mechanic>());
                    var mapper = new Mapper(config);
                    mapper.Map<MechanicViewModel, Mechanic>(model, mechanic);

                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //return false;
            }
            return false;
        }
    }
    }

