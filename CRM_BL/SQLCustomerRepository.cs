using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM_BL.Model
{
    public class SQLCustomerRepository : IRepository<Customer>
    {
        private CrmContext db;

        public SQLCustomerRepository()
        {
            this.db = new CrmContext();
        }

        public IEnumerable<Customer> GetList()
        {
            return db.Customers.ToList();
        }

        public Customer GetItem(int id)
        {
            return db.Customers.Find(id);
        }

        public void Add(Customer item)
        {
            db.Customers.Add(item);
            Save();
        }

        public void Edit(Customer item, int id)
        {
            var result = db.Customers.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                result.Name = item.Name;
            }
            Save();
        }

        public void Delete(int id)
        {
            var customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
            }
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }

            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
