using PMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.Interfaces
{
    public interface IProduct
    {
        bool createProduct(Product model);
        bool updateProduct(Product model);
        bool deleteProduct(String id);
        Product getProductByID(String id);
        List<Product> getProducts(string[] ID, string search, string SortColumn, string IconClass, int PageNo);
        bool checkProduct(String id);





    }
}
