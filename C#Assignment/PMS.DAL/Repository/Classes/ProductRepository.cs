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
    public class ProductRepository : IProductRepository
    {
        private readonly Models.DBProductsEntities _dbContext;
        public ProductRepository()
        {
            _dbContext = new Models.DBProductsEntities();
        }

        public bool checkProduct(string id)
        {
            return _dbContext.tblProducts.Count(e => e.ProductID == id) > 0;
        }

        public bool createProduct(Product model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Models.tblProduct>());
                var mapper = new Mapper(config);
                Models.tblProduct product = mapper.Map<Models.tblProduct>(model);
                int count = _dbContext.tblProducts.Count();
                product.ProductID = "PR00" + (count + 1);
                _dbContext.tblProducts.Add(product);
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

        public bool deleteProduct(string id)
        {
            try
            {
                var product = _dbContext.tblProducts.Where(s => id.Equals(s.ProductID.ToString())).FirstOrDefault();
                if (product.ProductID != null)
                {
                    _dbContext.tblProducts.Remove(product);
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

        public Product getProductByID(string id)
        {
            Product product = new Product();
            try
            {
                var Mproduct = _dbContext.tblProducts.Where(s => id.Equals(s.ProductID.ToString())).FirstOrDefault();

                if (Mproduct.ProductName != null)
                {

                    //// TODO: automapper mapping

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.tblProduct, Product>());
                    var mapper = new Mapper(config);
                    product = mapper.Map<Product>(Mproduct);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return product;
        }
    

        public List<Product> getProducts(string[] ID, string search, string SortColumn, string IconClass, int PageNo)
        {
            List<Product> list = new List<Product>();
            try
            {
                var entities = _dbContext.tblProducts.Where(temp => temp.ProductName.Contains(search) || temp.tblCategory.CategoryName.Contains(search)).ToList();
                if (SortColumn == "ProductID")
                {
                    if (IconClass == "fa-sort-amount-asc")
                        entities = entities.OrderBy(temp => temp.ProductID).ToList();
                    else
                        entities = entities.OrderByDescending(temp => temp.ProductID).ToList();
                }
                else if (SortColumn == "ProductName")
                {
                    if (IconClass == "fa-sort-amount-asc")
                        entities = entities.OrderBy(temp => temp.ProductName).ToList();
                    else
                        entities = entities.OrderByDescending(temp => temp.ProductName).ToList();
                }
                else if (SortColumn == "Price")
                {
                    if (IconClass == "fa-sort-amount-asc")
                        entities = entities.OrderBy(temp => temp.Price).ToList();
                    else
                        entities = entities.OrderByDescending(temp => temp.Price).ToList();
                }
                else if (SortColumn == "Quantity")
                {
                    if (IconClass == "fa-sort-amount-asc")
                        entities = entities.OrderBy(temp => temp.Quantity).ToList();
                    else
                        entities = entities.OrderByDescending(temp => temp.Quantity).ToList();
                }
                else if (SortColumn == "ShortDescription")
                {
                    if (IconClass == "fa-sort-amount-asc")
                        entities = entities.OrderBy(temp => temp.ShortDescription).ToList();
                    else
                        entities = entities.OrderByDescending(temp => temp.ShortDescription).ToList();
                }
                else if (SortColumn == "Category")
                {
                    if (IconClass == "fa-sort-amount-asc")
                        entities = entities.OrderBy(temp => temp.tblCategory.CategoryName).ToList();
                    else
                        entities = entities.OrderByDescending(temp => temp.tblCategory.CategoryName).ToList();
                }
                if (entities != null)
                {
                    foreach (var item in entities)
                    {
                        //// TODO: automapper mapping

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<Models.tblProduct, Product>());
                        var mapper = new Mapper(config);
                        Product product = mapper.Map<Product>(item);

                        list.Add(product);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    

        public bool updateProduct(Product model)
        {
            try
            {
                var product = _dbContext.tblProducts.Where(s => model.ProductID.Equals(s.ProductID)).FirstOrDefault();
                if (product.ProductID != null)
                {

               
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Models.tblProduct>());
                    var mapper = new Mapper(config);
                    mapper.Map<Product, Models.tblProduct>(model, product);
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
}
