using System;
using System.Collections.Generic;
using System.Linq;
using CRM_BL.Model;

namespace CRM_BL
{
    public class SQLSellerRepository : IRepository<Seller>
    {
        private CrmContext db;

        public SQLSellerRepository()
        {
            this.db = new CrmContext();
        }

        public IEnumerable<Seller> GetList()
        {
            return db.Sellers.ToList();
        }

        public Seller GetItem(int id)
        {
            return db.Sellers.Find(id);
        }

        public void Add(Seller item)
        {
            db.Sellers.Add(item);
            Save();
        }

        public void Edit(Seller item, int id)
        {
            var result = db.Sellers.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                result.Name = item.Name;
            }
            Save();
        }

        public void Delete(int id)
        {
            var seller = db.Sellers.Find(id);
            if (seller != null)
            {
                db.Sellers.Remove(seller);
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