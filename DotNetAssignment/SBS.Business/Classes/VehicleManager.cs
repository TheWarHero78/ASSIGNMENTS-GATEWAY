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
    public class VehicleManager : IVehicle
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public bool deleteVehicleDetails(string exID)
        {
            return _vehicleRepository.deleteVehicleDetails(exID);
        }

        public List<VehicleViewModel> getAllVehicle()
        {
            return _vehicleRepository.getAllVehicle();
        }

        public List<VehicleViewModel> getAllVehiclesByCustomer(string custExID)
        {
            return _vehicleRepository.getAllVehiclesByCustomer(custExID);
        }

     

        public VehicleViewModel getVehicleByExID(string exID)
        {
            return _vehicleRepository.getVehicleByExID(exID);
        }

        public bool registerVehicle(VehicleViewModel model)
        {
            return _vehicleRepository.registerVehicle(model);
        }

        public bool updateVehicleDetails(VehicleViewModel model)
        {
            return _vehicleRepository.updateVehicleDetails(model);
        }

        List<VehicleDropDown> IVehicle.getAllVehicleByCustomer(string custExID)
        {
            return _vehicleRepository.getAllVehicleByCustomer(custExID);
        }
    }
}
