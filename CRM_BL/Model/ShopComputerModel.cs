using System.Collections.Generic;
using System.Linq;

namespace CRM_BL.Model
{
    public class ShopComputerModel
    {
        Generator generator = new Generator();

        public List<CashRegister> CashRegisters { get; set; } = new List<CashRegister>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public ShopComputerModel()
        {
            var sellers = generator.GetNewSellers(15);
            generator.GetNewProducts(1000);
            generator.GetNewCustomers(100);

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashRegisters.Add(new CashRegister(CashRegisters.Count, Sellers.Dequeue()));
            }
        }

        public void Start()
        {
            var customers = generator.GetNewCustomers(10);
            var carts = new Queue<Cart>();

            foreach (var customer in customers)
            {
                var cart = new Cart(customer);

                foreach (var product in generator.GetRandomProducts(5, 25))
                {
                    cart.Add(product);
                }
                carts.Enqueue(cart);
            }


            while (carts.Count > 0)
            {
                var cash = CashRegisters.OrderByDescending(x => x.Count).FirstOrDefault();
                cash.Enqueue(carts.Dequeue());
            }

            while (true)
            {
                var cash = CashRegisters.OrderByDescending(x => x.Count).FirstOrDefault();
                var money = cash.Dequeue();
            }
        }
    }
}