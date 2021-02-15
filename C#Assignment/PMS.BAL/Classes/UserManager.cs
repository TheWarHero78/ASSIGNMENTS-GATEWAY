using PMS.BAL.Interfaces;
using PMS.Common.Models;
using PMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.Classes
{
    public class UserManager : IUser
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool checkUser(string id)
        {
            return _userRepository.checkUser(id);
        }

        public bool createUser(User model)
        {
            return _userRepository.createUser(model);
        }

        public bool deleteUser(string id)
        {
            return _userRepository.deleteUser(id);

        }

        public List<User> getAllUsers()
        {
            return _userRepository.getAllUsers();
        }

        public User getUserByID(string id)
        {
            return _userRepository.getUserByID(id);
        }

        public bool updateUser(User model)
        {
            return _userRepository.updateUser(model);
        }
    }
}
