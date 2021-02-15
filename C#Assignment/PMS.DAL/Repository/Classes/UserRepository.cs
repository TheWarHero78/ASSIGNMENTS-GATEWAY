using AutoMapper;
using PMS.Common.Models;
using PMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly Models.DBProductsEntities _dbContext;
        public UserRepository()
        {
            _dbContext = new Models.DBProductsEntities();
        }
        public bool checkUser(string id)
        {
            return _dbContext.tblUsers.Count(e => e.UserID == id) > 0;
        }

        public bool createUser(User model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, Models.tblUser>());
                var mapper = new Mapper(config);
                Models.tblUser user = mapper.Map<Models.tblUser>(model);
                int count = _dbContext.tblUsers.Count() + 1;
                user.UserID = "U00" + count;
                _dbContext.tblUsers.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.EntityCommandCompilationException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;

        }

        public bool deleteUser(string id)
        {
            try
            {
                var user = _dbContext.tblUsers.Where(s => id.Equals(s.UserID.ToString())).FirstOrDefault();
                if (user.FirstName != null)
                {
                    _dbContext.tblUsers.Remove(user);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // return false;
            }
            return false;

        
    }

        public List<User> getAllUsers()
        {
            List<User> list = new List<User>();
            try
            {
                var entities = _dbContext.tblUsers.ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.tblUser, User>());
                        var mapper = new Mapper(config);
                        User user = mapper.Map<User>(item);

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

        public User getUserByID(string id)
        {
            User user = new User();
            try
            {
                var Muser = _dbContext.tblUsers.Where(s => id.Equals(s.UserID.ToString())).FirstOrDefault();

                if (Muser.FirstName != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.tblUser, User>());
                    var mapper = new Mapper(config);
                    user = mapper.Map<User>(Muser);


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    

        public bool updateUser(string id, User model)
        {
            try
            {
                var user = _dbContext.tblUsers.Where(s => model.UserID.Equals(s.UserID)).FirstOrDefault();
                if (user.UserID != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<User, Models.tblUser>());
                    var mapper = new Mapper(config);
                    mapper.Map<User, Models.tblUser>(model, user);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.EntityCommandCompilationException ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                Console.WriteLine(ex.InnerException);
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (Exception ex)
            {

                return false;
            }
            return false;

        }
    }
    
}
