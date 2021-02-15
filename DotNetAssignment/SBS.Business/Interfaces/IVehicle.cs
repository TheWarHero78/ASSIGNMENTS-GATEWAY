using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Interfaces
{
    public interface IVehicle
    {
        Boolean registerVehicle(VehicleViewModel model);
        Boolean updateVehicleDetails(VehicleViewModel model);
        Boolean deleteVehicleDetails(String exID);
        VehicleViewModel getVehicleByExID(String exID);
        List<VehicleViewModel> getAllVehicle();
        List<VehicleViewModel> getAllVehiclesByCustomer(String custExID);
        List<VehicleDropDown> getAllVehicleByCustomer(String custExID);
    }
}
