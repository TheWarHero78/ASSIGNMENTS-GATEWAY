using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApi
{
    public static class DAL
    {
        static DBProductsEntities DbContext;
        static DAL()
        {
            DbContext = new DBProductsEntities();
        }
        public static List<tblProduct> GetAllProducts()
        {
            return DbContext.tblProducts.ToList();
        }
        public static tblProduct GetProduct(String productId)
        {
            return DbContext.tblProducts.Where(p => p.ProductID == productId).FirstOrDefault();
        }
        public static bool InsertProduct(tblProduct productItem)
        {
            bool status;
            try
            {
                DbContext.tblProducts.Add(productItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateProduct(tblProduct productItem)
        {
            bool status;
            try
            {
                tblProduct prodItem = DbContext.tblProducts.Where(p => p.ProductID == productItem.ProductID).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.ProductName = productItem.ProductName;
                    prodItem.Quantity = productItem.Quantity;
                    prodItem.Price = productItem.Price;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteProduct(String id)
        {
            bool status;
            try
            {
                tblProduct prodItem = DbContext.tblProducts.Where(p => p.ProductID == id).FirstOrDefault();
                if (prodItem != null)
                {
                    DbContext.tblProducts.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}