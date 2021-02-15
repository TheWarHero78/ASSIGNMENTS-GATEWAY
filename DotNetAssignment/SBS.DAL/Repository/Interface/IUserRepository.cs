﻿using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Interface
{
  public interface IUserRepository
    {
        Boolean createUser(UserViewModel model);
        UserViewModel validateUser(UserLoginViewModel model);
        List<UserViewModel> getAllUsers();
        bool validateUserByEmail(String email);
        bool resetUserPassword(UserLoginViewModel model);
        List<UserDealerDropDown> getAllUserDealer();
    }
}
