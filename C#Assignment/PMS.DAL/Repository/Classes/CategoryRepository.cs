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
    public class CategoryRepository : ICategoryReposiory
    {
        private readonly Models.DBProductsEntities _dbContext;
        public CategoryRepository()
        {
            _dbContext = new Models.DBProductsEntities();
        }
        public bool checkCategory(string id)
        {
            return _dbContext.tblCategories.Where(s => id .Equals(s.CategoryID)).Count() > 0;
        }

        public bool createCategory(Category model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, Models.tblCategory>());
                var mapper = new Mapper(config);
                Models.tblCategory category = mapper.Map<Models.tblCategory>(model);
                int count = _dbContext.tblCategories.Count();
                category.CategoryID = "CA00" + (count + 1);
                _dbContext.tblCategories.Add(category);
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
            return false;
        }

        public bool deleteCategory(string id)
        {
            try
            {
                Models.tblCategory tblCategory = _dbContext.tblCategories.Find(id);
                if (tblCategory == null)
                {
                    return false;
                }
                else
                {

                    _dbContext.tblCategories.Remove(tblCategory);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public List<Category> getAllCategory()
        {
            List<Category> list = new List<Category>();
            try
            {
                var entities = _dbContext.tblCategories.OrderBy(c => c.CategoryName).ToList();

                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.tblCategory, Category>());
                        var mapper = new Mapper(config);
                        Category category = mapper.Map<Category>(item);

                        list.Add(category);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }


            
        

        public Category getCategoryByID(string id)
        {
            Category category = new Category();
            try
            {
                var MCategory = _dbContext.tblCategories.Where(s => id.Equals(s.CategoryID)).FirstOrDefault();

                if (MCategory.CategoryName != null)
                {                    
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.tblCategory, Category>());
                    var mapper = new Mapper(config);
                    category = mapper.Map<Category>(MCategory);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return category;
        }
    

        public bool updateCategory(Category model)
        {
            try
            {
                Models.tblCategory category = _dbContext.tblCategories.Where(s => model.CategoryID.Equals(s.CategoryID)).FirstOrDefault();
                if (category.CategoryName != null)
                {                 
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, Models.tblCategory>());
                    var mapper = new Mapper(config);
                    mapper.Map<Category, Models.tblCategory>(model, category);
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
