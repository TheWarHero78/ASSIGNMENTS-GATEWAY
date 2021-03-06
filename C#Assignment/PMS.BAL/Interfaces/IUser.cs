﻿using PMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.Interfaces
{
    public interface IUser
    {
        bool createUser(User model);
        bool updateUser(User model);
        bool deleteUser(String id);
        List<User> getAllUsers();
        User getUserByID(string id);
        bool checkUser(String id);
    }
}
