using AutoMapper;
using SBS.BusinessEntities;
using SBS.DAL.Models;
using SBS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly Models.DBSBSEntities1 _dbContext;
        public UserRepository()
        {
            _dbContext = new Models.DBSBSEntities1();
        }
        public bool createUser(UserViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, Models.User>());
                var mapper = new Mapper(config);
                Models.User user = mapper.Map<Models.User>(model);
                user.ID = 0;
                user.ExternalID = Guid.NewGuid();
                user.Password = GetMD5(user.Password);
                user.CreatedAt = DateTime.Now;
                user.IsActive = true;
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public List<UserViewModel> getAllUsers()
        {
            List<UserViewModel> list = new List<UserViewModel>();
            try
            {
                var entities = _dbContext.Users.OrderBy(c => c.CreatedAt).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.User, UserViewModel>());
                        var mapper = new Mapper(config);
                        UserViewModel user = mapper.Map<UserViewModel>(item);
                        list.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    

        public UserViewModel validateUser(UserLoginViewModel model)
        {
            var f_password = GetMD5(model.Password);
            var data = _dbContext.Users.Where(s => (s.Email.Equals(model.UserName) && s.Password.Equals(f_password))).ToList();
            UserViewModel user = new UserViewModel();
            if (data.Count() > 0)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.User, UserViewModel>());
                var mapper = new Mapper(config);
                user = mapper.Map<UserViewModel>(data.FirstOrDefault());
            }
            return user;
        }
    

        public bool validateUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public bool resetUserPassword(UserLoginViewModel model)
        {
            try
            {
                var f_password = GetMD5(model.Password);
                var data = _dbContext.Users.Where(s => s.Email.Equals(model.UserName)).ToList();

                if (data.Count() > 0)
                {
                    User user = data.FirstOrDefault();
                    user.Password = f_password;
                    _dbContext.SaveChanges();
                    return true;
                }
            }catch(Exception ex)
            {

            }
            return false;
        }

        public List<UserDealerDropDown> getAllUserDealer()
        {
            List<UserDealerDropDown> list = new List<UserDealerDropDown>();
            try
            {
                var entities = _dbContext.Users.Where(c => c.Role.Equals("Dealer")).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.User, UserDealerDropDown>());
                        var mapper = new Mapper(config);
                        UserDealerDropDown user = mapper.Map<UserDealerDropDown>(item);
                        list.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
}
