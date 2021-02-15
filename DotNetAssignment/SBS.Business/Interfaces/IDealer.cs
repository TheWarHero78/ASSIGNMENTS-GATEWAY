using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Interfaces
{
  public  interface IDealer
    {
        Boolean registerDealer(DealerViewModel model);
        Boolean updateDealerDetails(DealerViewModel model);
        Boolean deleteDealerDetails(String exID);
        DealerViewModel getDealerByExID(String exID);
        List<DealerViewModel> getAllDealers();
        DealerViewModel getAllDealerByUser(String userExID);
        List<DealerDropDown> getAllDealerName();
        DealerViewModel getDealerByID(long ID);
    }
}
