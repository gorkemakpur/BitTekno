using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class ColorRepository : IColorRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Color entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Color.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Color color = context.Color.Find(id);
                context.Color.Remove(color);
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Color.Remove(entity);
                context.SaveChanges();
            }
        }

        public Color Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Color.Find(id);
            }
        }

        public List<Color> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Color.ToList();
            }
        }

        public void Update(Color entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Color.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
