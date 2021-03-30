using DotNetCoreAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.BAL.Interface
{
    public interface IUser
    {
        IList<User> GetAllUsers();
        User GetUserByID(long usID);
        User Validate(User user);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool RemoveUser(long usID);
    }
}
