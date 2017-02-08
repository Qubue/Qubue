using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;

namespace SportsStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Paging_4_Items_Per_Site()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }.AsQueryable);

            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            IQueryable<Product> result = (IQueryable<Product>)controller.List(2).Model;

            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}
