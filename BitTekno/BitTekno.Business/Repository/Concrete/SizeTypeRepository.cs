using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class SizeTypeRepository : ISizeTypeRepository
    {
        public void Add(SizeType entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.SizeType.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                SizeType sizeType = context.SizeType.Find(id);
                context.SizeType.Remove(sizeType);
                context.SaveChanges();
            }
        }

        public void Delete(SizeType entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.SizeType.Remove(entity);
                context.SaveChanges();
            }
        }

        public SizeType Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.SizeType.Find(id);
            }
        }

        public List<SizeType> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.SizeType.ToList();
            }
        }

        public void Update(SizeType entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.SizeType.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
