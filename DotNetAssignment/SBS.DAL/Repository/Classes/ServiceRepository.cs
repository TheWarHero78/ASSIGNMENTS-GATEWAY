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
    public class ServiceRepository : IServiceRepository
    {
        private readonly Models.DBSBSEntities1 _dbContext;
        public ServiceRepository()
        {
            _dbContext = new Models.DBSBSEntities1();
        }
        public bool deleteServiceDetails(string exID)
        {
            try
            {
                Service service = _dbContext.Services.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();
                if (service.Name != null)
                {
                    service.IsActive = false;
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

        public List<ServiceViewModel> getAllServices()
        {
            List<ServiceViewModel> list = new List<ServiceViewModel>();
            try
            {
                var entities = _dbContext.Services.OrderBy(c => c.CreatedDate).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Service, ServiceViewModel>());
                        var mapper = new Mapper(config);
                        ServiceViewModel service = mapper.Map<ServiceViewModel>(item);

                        list.Add(service);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    

        public List<ServiceViewModel> getAllServicesByDealer(string dealerExID)
        {
            List<ServiceViewModel> list = new List<ServiceViewModel>();
            try
            {
                var entities = _dbContext.Services.Where(s => (dealerExID.Equals(s.Dealer.ExternalID.ToString()))).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Service, ServiceViewModel>());
                        var mapper = new Mapper(config);
                        ServiceViewModel service = mapper.Map<ServiceViewModel>(item);

                        list.Add(service);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public List<ServiceDropDown> getAllServicesByDealerDrop(string dealerExID)
        {
            List<ServiceDropDown> list = new List< ServiceDropDown>();
            try
            {
                var entities = _dbContext.Services.Where(s => (dealerExID.Equals(s.Dealer.ExternalID.ToString()))).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Service, ServiceDropDown>());
                        var mapper = new Mapper(config);
                        ServiceDropDown service = mapper.Map<ServiceDropDown>(item);

                        list.Add(service);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

      

        public ServiceViewModel getServiceByExID(string exID)
        {
            ServiceViewModel service = new ServiceViewModel();
            try
            {
                Models.Service Mservice = _dbContext.Services.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();

                if (Mservice.Name != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Service, ServiceViewModel>());
                    var mapper = new Mapper(config);
                    service = mapper.Map<ServiceViewModel>(Mservice);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return service;
        }
    

        public bool registerService(ServiceViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceViewModel, Models.Service>());
                var mapper = new Mapper(config);
                Models.Service service = mapper.Map<Models.Service>(model);
                service.ID = 0;
                service.ExternalID = Guid.NewGuid();
                service.CreatedDate = DateTime.Now;
                service.CreatedBy = 1;
                service.IsActive = true;

                _dbContext.Services.Add(service);
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
    

        public bool updateServiceDetails(ServiceViewModel model)
        {
            try
            {
                Service service = _dbContext.Services.Where(s => model.ExternalID.Equals(s.ExternalID)).FirstOrDefault();
                if (service.Name != null)
                {


                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ServiceViewModel, Service>());
                    var mapper = new Mapper(config);
                    mapper.Map<ServiceViewModel, Service>(model, service);

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

