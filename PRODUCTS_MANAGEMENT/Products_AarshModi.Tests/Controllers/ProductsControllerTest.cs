using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products_AarshModi.Controllers;
using System.Web.Mvc;

namespace Products_AarshModi.Tests.Controllers
{
    /// <summary>
    /// Summary description for ProductsControllerTest
    /// </summary>
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ProductsController controller = new ProductsController();
            string[] id = { };
            // Act
            ViewResult result = controller.Index(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            ProductsController controller = new ProductsController();

            // Act
            ViewResult result = controller.Details("PR001") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

       
    }
}

