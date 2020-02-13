using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRM_BL.Model
{
    public class ShopComputerModel
    {
        Generator generator = new Generator();
        private bool isWorking = false;

        public List<CashRegister> CashRegisters { get; set; } = new List<CashRegister>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        public int CustomerSpeed { get; set; } = 100;
        public int CashRegisterSpeed { get; set; } = 100;

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
            isWorking = true;
            Task.Run(() => CreateCarts(50, CustomerSpeed));

            var cashRegisterTasks = CashRegisters.Select(c => new Task(() => CashRegisterHandling(c, CashRegisterSpeed)));
            foreach (var task in cashRegisterTasks)
            {
                task.Start();
            }
        }

        public void Stop()
        {
            isWorking = false;
        }

        private void CashRegisterHandling(CashRegister cashRegister, int sleepTime)
        {
            while (isWorking)
            {
                if (cashRegister.Count > 0)
                {
                    cashRegister.Dequeue();
                }
                Thread.Sleep(sleepTime);
            }
        }

        private void CreateCarts(int customerCounts, int sleepTime)
        {
            while (isWorking)
            {
                var customers = generator.GetNewCustomers(customerCounts);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);

                    foreach (var randomProduct in generator.GetRandomProducts(10,30))
                    {
                        cart.Add(randomProduct);
                    }



                    var cashRegister = CashRegisters.OrderBy(x => x.Count).FirstOrDefault();
                    cashRegister.Enqueue(cart);
                }

                Thread.Sleep(sleepTime);
            }
        }
    }
}