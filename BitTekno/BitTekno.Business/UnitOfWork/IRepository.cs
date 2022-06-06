using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.UnitOfWork
{
    public interface  IRepository<T>  where T : class
    {
        List<T> GetList();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);   
    }
}
