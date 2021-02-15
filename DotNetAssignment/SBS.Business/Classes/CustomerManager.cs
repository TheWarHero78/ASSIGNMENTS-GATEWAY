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
    public class CustomerManager : ICustomer
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerViewModel> getAllCustomer()
        {
            return _customerRepository.getAllCustomer();
        }

        public CustomerViewModel getAllCustomerByUser(string userExID)
        {
            return _customerRepository.getAllCustomerByUser(userExID);
        }

        public CustomerViewModel getCustomerByExID(string exID)
        {
            return _customerRepository.getCustomerByExID(exID);
        }

        public UserCustomerViewModel getCustomerUser(string exID)
        {
            return _customerRepository.getCustomerUser(exID);
        }

        public bool registerCustomer(CustomerViewModel model)
        {
            return _customerRepository.registerCustomer(model);
        }

        public bool updateCustomerDetails(CustomerViewModel model)
        {
            return _customerRepository.updateCustomerDetails(model);
        }
    }
}
