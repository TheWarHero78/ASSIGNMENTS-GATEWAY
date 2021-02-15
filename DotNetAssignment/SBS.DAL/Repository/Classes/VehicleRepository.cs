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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Models.DBSBSEntities1 _dbContext;
        public VehicleRepository()
        {
            _dbContext = new Models.DBSBSEntities1();
        }

        public bool deleteVehicleDetails(string exID)
        {
            try
            {
                Vehicle vehicle = _dbContext.Vehicles.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();
                if (vehicle.Brand != null)
                {
                    vehicle.IsActive = false;
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


        public List<VehicleViewModel> getAllVehicle()
        {
            List<VehicleViewModel> list = new List<VehicleViewModel>();
            try
            {
                var entities = _dbContext.Vehicles.OrderBy(c => c.CreatedDate).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Vehicle, VehicleViewModel>().ForMember(t => t.Model1,
                 opt => opt.MapFrom(s => s.Model)));
                        
                        var mapper = new Mapper(config);
                        VehicleViewModel vehicle = mapper.Map<VehicleViewModel>(item);

                        list.Add(vehicle);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public List<VehicleViewModel> getAllVehiclesByCustomer(string custExID)
        {
            List<VehicleViewModel> list = new List<VehicleViewModel>();
            try
            {
                var entities = _dbContext.Vehicles.Where(s => (custExID.Equals(s.Customer.ExternalID.ToString()))).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Vehicle, VehicleViewModel>().ForMember(t => t.Model1,
                 opt => opt.MapFrom(s => s.Model)));
                        var mapper = new Mapper(config);
                        VehicleViewModel vehicle = mapper.Map<VehicleViewModel>(item);

                        list.Add(vehicle);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public VehicleViewModel getVehicleByExID(string exID)
        {
            VehicleViewModel vehicle = new VehicleViewModel();
            try
            {
                Models.Vehicle Mvehicle = _dbContext.Vehicles.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();

                if (vehicle.Brand != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Vehicle, VehicleViewModel>().ForMember(t => t.Model1,
                 opt => opt.MapFrom(s => s.Model)));
                    var mapper = new Mapper(config);
                    vehicle = mapper.Map<VehicleViewModel>(Mvehicle);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return vehicle;
        }


        public bool registerVehicle(VehicleViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleViewModel, Models.Vehicle>().ForMember(t => t.Model,
                 opt => opt.MapFrom(s => s.Model1)));
                var mapper = new Mapper(config);
                Models.Vehicle vehicle = mapper.Map<Models.Vehicle>(model);
                vehicle.ID = 0;
                vehicle.ExternalID = Guid.NewGuid();
               vehicle.CreatedDate = DateTime.Now;
                vehicle.CreatedBy = 1;
                vehicle.IsActive = true;

                _dbContext.Vehicles.Add(vehicle);
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


        public bool updateVehicleDetails(VehicleViewModel model)
        {
            try
            {
                Vehicle vehicle = _dbContext.Vehicles.Where(s => model.ExternalID.Equals(s.ExternalID)).FirstOrDefault();
                if (vehicle.Brand != null)
                {


                    var config = new MapperConfiguration(cfg => cfg.CreateMap<VehicleViewModel, Vehicle>().ForMember(t => t.Model,
                 opt => opt.MapFrom(s => s.Model1)));
                    var mapper = new Mapper(config);
                    mapper.Map<VehicleViewModel, Vehicle>(model, vehicle);

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

        List<VehicleDropDown> IVehicleRepository.getAllVehicleByCustomer(string custExID)
        {
            List<VehicleDropDown> list = new List<VehicleDropDown>();
            try
            {
                var entities = _dbContext.Vehicles.Where(s => (custExID.Equals(s.Customer.ExternalID.ToString()))).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Vehicle, VehicleDropDown>());
                        var mapper = new Mapper(config);
                        VehicleDropDown vehicle = mapper.Map<VehicleDropDown>(item);

                        list.Add(vehicle);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
    }


