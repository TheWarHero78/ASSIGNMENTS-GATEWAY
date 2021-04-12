using DotNetCoreAssignment.Models;
using DotNetCoreAssignment.Repository;
using Emp.BAL.Interface;
using System.Collections.Generic;

namespace Emp.BAL.Classes
{
    public class UserManager : IUser
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Injecting User Repostory in Constructor
        /// </summary>
        /// <param name="employeeRepository"></param>
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Funtion to add user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns a boolean indicating user is added or not </returns>
        public bool AddUser(User user)
        {
            return _userRepository.Add(user);
        }

        /// <summary>
        /// Function to get all Users
        /// </summary>
        /// <returns>returns a List of User</returns>
        public IList<User> GetAllUsers()
        {
            var model = _userRepository.GetAll();
            return model;
        }

        /// <summary>
        /// Function find User by given Id
        /// </summary>
        /// <param name="usID"></param>
        /// <returns>Returns a User</returns>
        public User GetUserByID(long usID)
        {
            var user = _userRepository.GetSingle(d => d.Id == usID);
            return user;
        }

        /// <summary>
        /// Function to remove user with given ID
        /// </summary>
        /// <param name="usID"></param>
        /// <returns>returns a boolean indicating user is removed or not</returns>
        public bool RemoveUser(long usID)
        {
            var employee = _userRepository.GetSingle(d => d.Id == usID);
            return _userRepository.Remove(employee);
        }

        /// <summary>
        /// Function to update user details with given user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns a boolean indicating user is updated or not</returns>
        public bool UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }

        /// <summary>
        /// Funtion to validate a user with given user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns a user object</returns>
        public User Validate(User user)
        {
            var user1 = _userRepository.GetSingle(d => d.Email == user.Email && d.Password == user.Password);
            return user1;
        }
    }
}
