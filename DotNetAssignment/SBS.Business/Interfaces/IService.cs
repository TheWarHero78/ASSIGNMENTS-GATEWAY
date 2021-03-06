﻿using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Interfaces
{
    public interface IService
    {
        Boolean registerService(ServiceViewModel model);
        Boolean updateServiceDetails(ServiceViewModel model);
        Boolean deleteServiceDetails(String exID);
        ServiceViewModel getServiceByExID(String exID);
        List<ServiceViewModel> getAllServices();

        List<ServiceViewModel> getAllServicesByDealer(String dealerExID);
        List<ServiceDropDown> getAllServicesByDealerDrop(String dealerExID);
    }
}
