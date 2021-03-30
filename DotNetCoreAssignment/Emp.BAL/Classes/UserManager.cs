using DotNetCoreAssignment.Models;
using DotNetCoreAssignment.Repository;
using Emp.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.BAL.Classes
{
   public class UserManager :IUser
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(User user)
        {
            return _userRepository.Add(user);
        }

        public IList<User> GetAllUsers()
        {
            var model = _userRepository.GetAll();
            return model;
        }

        public User GetUserByID(long usID)
        {
            var user = _userRepository.GetSingle(d => d.Id == usID);
            return user;
        }

        public bool RemoveUser(long usID)
        {
            var employee = _userRepository.GetSingle(d => d.Id == usID);
            return _userRepository.Remove(employee);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }

        public User Validate(User user)
        {
            var user1 = _userRepository.GetSingle(d => d.Email == user.Email && d.Password==user.Password);
            return user1;
        }
    }
}
