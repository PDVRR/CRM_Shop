using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BL.Model
{
    public class CashRegister
    {
        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int MaxQueueLength { get; set; }
        public int GoneCustomer { get; set; }
        public bool IsModel { get; set; }

        CrmContext db = new CrmContext();

        public CashRegister(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;

        }

        public void Enqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLength)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                GoneCustomer++;
            }
        }

        public decimal Dequeue()
        {
            decimal sum = 0;
            var cart = Queue.Dequeue();

            if (cart != null)
            {
                var check = new Check()
                {
                    SellerId = Seller.Id,
                    CustomerId = cart.Customer.Id,
                    Seller = Seller,
                    Customer = cart.Customer,
                    Created = DateTime.Now

                };

                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.Id = 0;
                }

                var sells = new List<Sell>();

                foreach (Product product in cart)
                {
                    if (product.Count > 0)
                    {


                        var sell = new Sell()
                        {
                            CheckId = check.Id,
                            Check = check,
                            ProductId = product.Id,
                            Product = product
                        };
                        sells.Add(sell);

                        if (!IsModel)
                        {
                            db.Sells.Add(sell);
                        }

                        product.Count--;
                        sum += product.Price;
                    }
                }

                if (!IsModel)
                {
                    db.SaveChanges();
                }
            }

            return sum;
        }
    }
}
