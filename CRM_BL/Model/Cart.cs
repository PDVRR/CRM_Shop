﻿using System;
using System.Collections;
using System.Collections.Generic;


namespace CRM_BL.Model
{
    public class Cart : IEnumerable
    {
        public Customer Customer { get; set; }
        public Dictionary<Product, int> Products { get; set; }
        public int Count { get; private set; }
        public decimal Price { get; private set; }

        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        public void Add(Product product)
        {
            if (Products.TryGetValue(product, out int count))
            {
                Products[product] = ++count;
            }
            else
            {
                Products.Add(product, 1);
            }

            Count++;
            Price += product.Price;
        }

        public List<Product> GetAll()
        {
            var result = new List<Product>();
            foreach (Product product in this)
            {
                result.Add(product);
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var product in Products.Keys)
            {
                for (int i = 0; i < Products[product]; i++)
                {
                    yield return product;
                }
            }
        }

    }
}
