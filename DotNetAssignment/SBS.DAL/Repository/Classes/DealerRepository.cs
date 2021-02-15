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
    public class DealerRepository : IDealerRepository
    {
        private readonly Models.DBSBSEntities1 _dbContext;
        public DealerRepository()
        {
            _dbContext = new Models.DBSBSEntities1();
        }

        public bool deleteDealerDetails(string exID)
        {
            try
            {
                Dealer dealer = _dbContext.Dealers.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();
                if (dealer.Address1 != null)
                {
                    dealer.IsActive = false;
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // return false;
            }
            return false;
        }


        public DealerViewModel getAllDealerByUser(string userExID)
        {
            DealerViewModel dealer = new DealerViewModel();
            try
            {
                var Mdealer = _dbContext.Dealers.Where(s => (userExID.Equals(s.User.ExternalID.ToString()))).FirstOrDefault();

                if (Mdealer.Address1 != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Dealer, DealerViewModel>());
                    var mapper = new Mapper(config);
                    dealer = mapper.Map<DealerViewModel>(Mdealer);


                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dealer;
        }

        public List<DealerDropDown> getAllDealerName()
        {
            List<DealerDropDown> list = new List<DealerDropDown>();
            try
            {
                var entities = _dbContext.Dealers.OrderBy(c => c.CreatedDate).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Dealer, DealerDropDown>());
                        var mapper = new Mapper(config);
                        DealerDropDown dealer = mapper.Map<DealerDropDown>(item);

                        list.Add(dealer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public List<DealerViewModel> getAllDealers()
        {
            List<DealerViewModel> list = new List<DealerViewModel>();
            try
            {
                var entities = _dbContext.Dealers.OrderBy(c => c.CreatedDate).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Dealer, DealerViewModel>());
                        var mapper = new Mapper(config);
                        DealerViewModel dealer = mapper.Map<DealerViewModel>(item);

                        list.Add(dealer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public DealerViewModel getDealerByExID(string exID)
        {
            DealerViewModel dealer = new DealerViewModel();
            try
            {
                Models.Dealer Mdealer = _dbContext.Dealers.Where(s => exID.Equals(s.ExternalID.ToString())).FirstOrDefault();

                if (Mdealer != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Dealer, DealerViewModel>());
                    var mapper = new Mapper(config);
                    dealer = mapper.Map<DealerViewModel>(Mdealer);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dealer;
        }

        public DealerViewModel getDealerByID(long ID)
        {
            DealerViewModel dealer = new DealerViewModel();
            try
            {
                Models.Dealer Mdealer = _dbContext.Dealers.Where(s => ID.Equals(s.ID)).FirstOrDefault();

                if (Mdealer != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.Dealer, DealerViewModel>());
                    var mapper = new Mapper(config);
                    dealer = mapper.Map<DealerViewModel>(Mdealer);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dealer;
        }
    

        public bool registerDealer(DealerViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<DealerViewModel, Models.Dealer>());
                var mapper = new Mapper(config);
                Models.Dealer dealer = mapper.Map<Models.Dealer>(model);
                dealer.ID = 0;
                dealer.ExternalID = Guid.NewGuid();
                dealer.CreatedDate = DateTime.Now;
                dealer.CreatedBy = 1;
                dealer.IsActive = true;
                dealer.Approved = true;

                _dbContext.Dealers.Add(dealer);
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


        public bool updateDealerDetails(DealerViewModel model)
        {
            try
            {
                Dealer dealer = _dbContext.Dealers.Where(s => model.ExternalID.Equals(s.ExternalID)).FirstOrDefault();
                if (dealer.Address1 != null)
                {


                    var config = new MapperConfiguration(cfg => cfg.CreateMap<DealerViewModel, Dealer>());
                    var mapper = new Mapper(config);
                    mapper.Map<DealerViewModel, Dealer>(model, dealer);

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
