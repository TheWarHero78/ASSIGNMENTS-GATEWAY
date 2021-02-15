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
    public class MechanicManager : IMechanic
    {
        private readonly IMechanicRepository _mechanicRepository;
        public MechanicManager(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        public bool deleteMechanicDetails(string exID)
        {
            return _mechanicRepository.deleteMechanicDetails(exID);
        }

        public List<MechanicViewModel> getAllMechanics()
        {
            return _mechanicRepository.getAllMechanics();
        }

        public List<MechanicDropDown> getAllMechanicsByDealer(string dealerExID)
        {
            return _mechanicRepository.getAllMechanicsByDealer(dealerExID);
        }

        public MechanicViewModel getMechanicByExID(string exID)
        {
            return _mechanicRepository.getMechanicByExID(exID);
        }

        public bool registerMechanic(MechanicViewModel model)
        {
            return _mechanicRepository.registerMechanic(model);
        }

        public bool updateMechanicDetails(MechanicViewModel model)
        {
            return _mechanicRepository.updateMechanicDetails(model);
        }
    }
}
