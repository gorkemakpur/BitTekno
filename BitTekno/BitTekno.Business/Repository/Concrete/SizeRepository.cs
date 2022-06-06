using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class SizeRepository : ISizeRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Size entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Size.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Size size = context.Size.Find(id);
                context.Size.Remove(size);
                context.SaveChanges();
            }
        }

        public void Delete(Size entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Size.Remove(entity);
                context.SaveChanges();
            }
        }

        public Size Get(int id)
        {
            using(BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Size.Find(id);
            }
        }

        public List<Size> GetList()
        {
            using(BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Size.ToList();
            }
        }

        public void Update(Size entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Size.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            
        }
    }
}
