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
    public class CashRegisterTests
    {
        [TestMethod()]
        public void CashRegisterTest()
        {
            var customer1 = new Customer()
            {
                Id = 1,
                Name = "testuser1"
            };
            var customer2 = new Customer()
            {
                Id = 1,
                Name = "testuser2"
            };
            var seller = new Seller()
            {
                Id = 1,
                Name = "testseller"
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
                Price = 30,
                Count = 6
            };
            var product3 = new Product()
            {
                Id = 3,
                Name = "product3",
                Price = 50,
                Count = 5
            };
            var cart1 = new Cart(customer1);
            cart1.Add(product1);
            cart1.Add(product2);
            cart1.Add(product3);
            var cart2 = new Cart(customer2);
            cart2.Add(product2);
            cart2.Add(product2);
            cart2.Add(product3);

            var cashRegister = new CashRegister(1, seller, null)
            {
                MaxQueueLength = 3
            };
            cashRegister.Enqueue(cart1);
            cashRegister.Enqueue(cart2);

            var cart1ExpectedResult = 180;
            var cart2ExpectedResult = 110;

            var cart1ActualResult = cashRegister.Dequeue();
            var cart2ActualResult = cashRegister.Dequeue();

            Assert.AreEqual(cart1ExpectedResult, cart1ActualResult);
            Assert.AreEqual(cart2ExpectedResult, cart2ActualResult);
            Assert.AreEqual(1, product1.Count);
            Assert.AreEqual(3, product2.Count);
            Assert.AreEqual(3, product3.Count);
        }

        
    }
}