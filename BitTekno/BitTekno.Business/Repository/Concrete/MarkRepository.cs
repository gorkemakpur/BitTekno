using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class MarkRepository : IMarkRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Mark entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Mark.Add(entity);
                context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Mark mark = context.Mark.Find(id);
                context.Mark.Remove(mark);
                context.SaveChanges();
            }

        }

        public void Delete(Mark entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Mark.Remove(entity);
                context.SaveChanges();
            }

        }

        public Mark Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Mark.Find(id);
            }


        }

        public List<Mark> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Mark.ToList();
            }
        }

        public void Update(Mark entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Mark.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
