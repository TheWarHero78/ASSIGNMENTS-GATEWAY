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
    public class UserManager : IUser
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool createUser(UserViewModel model)
        {
            return _userRepository.createUser(model);
        }

        public List<UserDealerDropDown> getAllUserDealer()
        {
            return _userRepository.getAllUserDealer();
        }

        public List<UserViewModel> getAllUsers()
        {
            return _userRepository.getAllUsers();
        }

        public bool resetUserPassword(UserLoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public UserViewModel validateUser(UserLoginViewModel model)
        {
            return _userRepository.validateUser(model);
        }

        public bool validateUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
