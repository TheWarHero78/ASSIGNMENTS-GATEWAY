using PMS.BAL.Interfaces;
using PMS.Common.Models;
using PMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.Classes
{
    public class ProductManager : IProduct
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool checkProduct(string id)
        {
          return  _productRepository.checkProduct(id);
        }

        public bool createProduct(Product model)
        {
            return _productRepository.createProduct(model);
        }

        public bool deleteProduct(string id)
        {
            return _productRepository.deleteProduct(id);
        }

        public Product getProductByID(string id)
        {
            return _productRepository.getProductByID(id);
        }

        public List<Product> getProducts(string[] ID, string search, string SortColumn, string IconClass, int PageNo)
        {
            return _productRepository.getProducts(ID,search,SortColumn,IconClass,PageNo);
        }

        public bool updateProduct(Product model)
        {
            return _productRepository.updateProduct(model)
 ;        }
    }
}
