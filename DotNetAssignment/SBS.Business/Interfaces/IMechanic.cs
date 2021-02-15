using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Interfaces
{
   public interface IMechanic
    {
        Boolean registerMechanic(MechanicViewModel model);
        Boolean updateMechanicDetails(MechanicViewModel model);
        Boolean deleteMechanicDetails(String exID);
        MechanicViewModel getMechanicByExID(String exID);
        List<MechanicViewModel> getAllMechanics();
        List<MechanicDropDown> getAllMechanicsByDealer(String dealerExID);

    }
}
