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
    public class ServiceManager : IService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public bool deleteServiceDetails(string exID)
        {
            return _serviceRepository.deleteServiceDetails(exID);
        }

        public List<ServiceViewModel> getAllServices()
        {
            return _serviceRepository.getAllServices();
        }

        public List<ServiceViewModel> getAllServicesByDealer(string dealerExID)
        {
            return _serviceRepository.getAllServicesByDealer(dealerExID);
        }

        public List<ServiceDropDown> getAllServicesByDealerDrop(string dealerExID)
        {
            return _serviceRepository.getAllServicesByDealerDrop(dealerExID);
        }

        public ServiceViewModel getServiceByExID(string exID)
        {
            return _serviceRepository.getServiceByExID(exID);
        }

        public bool registerService(ServiceViewModel model)
        {
            return _serviceRepository.registerService(model);
        }

        public bool updateServiceDetails(ServiceViewModel model)
        {
            return _serviceRepository.updateServiceDetails(model);
        }
    }
}
