using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products_AarshModi.Models;
using ProductsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProducts.Controllers
{
    [TestClass]
   public class UserCntTest
    {
        [TestMethod]
        public void UserList()
        {
            DBProductsEntities db = new DBProductsEntities();
            var result = db.tblUsers.ToList();
            Assert.IsNotNull(result);
        }
    }
    //[TestMethod]
    //public void ProductList()
    //{
    //    ProductdbEntities db = new ProductdbEntities();

    //    //Act
    //    var result = db.Productslists.ToList();

    //    //Assert
    //    Assert.IsNotNull(result);
    //}

    //[TestMethod]
    //public void CreateorEdit(int id)
    //{
    //    productController pro = new productController();

    //    //Act
    //    pro.CreateorEdit(0);

    //    //Assert

    //}
}
