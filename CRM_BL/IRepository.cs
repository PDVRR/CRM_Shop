using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_BL
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetList();
        T GetItem(int id);
        void Add(T item);
        void Edit(T item, int id);
        void Delete(int id);
        void Save();
    }
}
