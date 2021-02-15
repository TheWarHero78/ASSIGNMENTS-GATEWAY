using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Business.Interfaces
{
   public interface ICustomer
    {
        Boolean registerCustomer(CustomerViewModel model);
        Boolean updateCustomerDetails(CustomerViewModel model);
        UserCustomerViewModel getCustomerUser(String exID);
        CustomerViewModel getCustomerByExID(String exID);
        List<CustomerViewModel> getAllCustomer();
        CustomerViewModel getAllCustomerByUser(String userExID);
    }
}
