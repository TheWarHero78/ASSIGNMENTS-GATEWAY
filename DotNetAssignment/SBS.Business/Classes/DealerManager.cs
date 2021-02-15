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
    public class DealerManager : IDealer
    {
        private readonly IDealerRepository _dealerRepository;
        public DealerManager(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        public bool deleteDealerDetails(string exID)
        {
            return _dealerRepository.deleteDealerDetails(exID);
        }

        public DealerViewModel getAllDealerByUser(string userExID)
        {
            return _dealerRepository.getAllDealerByUser(userExID);
        }

        public List<DealerDropDown> getAllDealerName()
        {
            return _dealerRepository.getAllDealerName();
        }

        public List<DealerViewModel> getAllDealers()
        {
            return _dealerRepository.getAllDealers();
        }

        public DealerViewModel getDealerByExID(string exID)
        {
            return _dealerRepository.getDealerByExID(exID);
        }

        public DealerViewModel getDealerByID(long ID)
        {
            return _dealerRepository.getDealerByID(ID);
        }

        public bool registerDealer(DealerViewModel model)
        {
            return _dealerRepository.registerDealer(model);
        }

        public bool updateDealerDetails(DealerViewModel model)
        {
            return _dealerRepository.updateDealerDetails(model);
        }
    }
}
