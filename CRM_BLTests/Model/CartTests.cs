using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BL.Model.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            var customer = new Customer()
            {
                Id = 1,
                Name = "testuser"
            };
            var product1 = new Product()
            {
                Id = 1,
                Name = "product1",
                Price = 100,
                Count = 2
            };
            var product2 = new Product()
            {
                Id = 2,
                Name = "product2",
                Price = 100,
                Count = 2
            };
            var product3 = new Product()
            {
                Id = 3,
                Name = "product3",
                Price = 100,
                Count = 2
            };
            var cart = new Cart(customer);
            cart.Add(product1);
            cart.Add(product2);
            cart.Add(product3);
            var expectedResult = new List<Product>()
            {
                product1, product2, product3
            };
            var cartResult = cart.GetAll();
            Assert.AreEqual(expectedResult.Count, cart.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cartResult[i]);
            }
        }

    }
}