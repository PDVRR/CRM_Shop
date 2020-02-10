using System;
using System.Collections.Generic;
using System.Linq;
using CRM_BL.Model;

namespace CRM_BL
{
    public class SQLProductRepository : IRepository<Product>
    {
        private CrmContext db;

        public SQLProductRepository()
        {
            this.db = new CrmContext();
        }

        public IEnumerable<Product> GetList()
        {
            return db.Products.ToList();
        }

        public Product GetItem(int id)
        {
            return db.Products.Find(id);
        }

        public void Add(Product item)
        {
            db.Products.Add(item);
            Save();
        }

        public void Edit(Product item, int id)
        {
            var result = db.Products.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                result.Name = item.Name;
                result.Count = item.Count;
                result.Price = item.Price;
            }
            Save();
        }

        public void Delete(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
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
