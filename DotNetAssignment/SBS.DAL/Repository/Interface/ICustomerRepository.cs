using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Interface
{
   public interface ICustomerRepository
    {
        Boolean registerCustomer(CustomerViewModel model);
        Boolean updateCustomerDetails(CustomerViewModel model);        
        CustomerViewModel getCustomerByExID(String exID);
        UserCustomerViewModel getCustomerUser(String exID);
        List<CustomerViewModel> getAllCustomer();
        
        CustomerViewModel getAllCustomerByUser(String userExID);
    }
}
