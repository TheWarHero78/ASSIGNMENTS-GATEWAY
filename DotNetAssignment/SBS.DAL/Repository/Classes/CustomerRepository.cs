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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Models.DBSBSEntities1 _dbContext;
        public CustomerRepository()
        {
            _dbContext = new Models.DBSBSEntities1();
        }


        public List<CustomerViewModel> getAllCustomer()
        {

            List<CustomerViewModel> list = new List<CustomerViewModel>();
            try
            {
                var entities = _dbContext.Customers.OrderBy(c => c.Name).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Customer, CustomerViewModel>());
                        var mapper = new Mapper(config);
                        CustomerViewModel customer = mapper.Map<CustomerViewModel>(item);

                        list.Add(customer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public CustomerViewModel getAllCustomerByUser(string userExID)
        {
            CustomerViewModel customer = new CustomerViewModel();
            try
            {
                var Mcustomer = _dbContext.Customers.Where(s => userExID.Equals(s.User.ExternalID.ToString())).FirstOrDefault();

                if (Mcustomer.Address1 != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Customer, CustomerViewModel>());
                    var mapper = new Mapper(config);
                    customer = mapper.Map<CustomerViewModel>(Mcustomer);


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }


        public CustomerViewModel getCustomerByExID(string exID)
        {
            CustomerViewModel customer = new CustomerViewModel();
            try
            {
                var Mcustomer = _dbContext.Customers.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();

                if (Mcustomer.Name != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Customer, CustomerViewModel>());
                    var mapper = new Mapper(config);
                    customer = mapper.Map<CustomerViewModel>(Mcustomer);


                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public UserCustomerViewModel getCustomerUser(string exID)
        {
            UserCustomerViewModel customer = new UserCustomerViewModel();
            try
            {
                var Mcustomer = _dbContext.Customers.Where(s => exID.Equals(s.User.ExternalID.ToString())).FirstOrDefault();

                if (Mcustomer.Name != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Customer, UserCustomerViewModel>());

                    var mapper = new Mapper(config);
                    mapper.Map<Customer, UserCustomerViewModel>(Mcustomer, customer);



                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public bool registerCustomer(CustomerViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerViewModel, Models.Customer>());
                var mapper = new Mapper(config);
                Models.Customer customer = mapper.Map<Models.Customer>(model);
                customer.ID = 0;
                customer.ExternalID = Guid.NewGuid();

                _dbContext.Customers.Add(customer);
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


        public bool updateCustomerDetails(CustomerViewModel model)
        {
            try
            {
                Customer customer = _dbContext.Customers.Where(s => model.ExternalID.Equals(s.ExternalID)).FirstOrDefault();
                if (customer.Address1 != null)
                {


                    var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerViewModel, Customer>());
                    var mapper = new Mapper(config);
                    mapper.Map<CustomerViewModel, Customer>(model, customer);

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

