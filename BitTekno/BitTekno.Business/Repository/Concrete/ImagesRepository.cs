using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class ImagesRepository : IImagesRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Images entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Images.Add(entity);
                context.SaveChanges();

            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Images ımages = context.Images.Find(id);
                context.Images.Remove(ımages);
                context.SaveChanges();
            }
        }

        public void Delete(Images entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Images.Remove(entity);
                context.SaveChanges();
            }
        }

        public Images Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
               return context.Images.Find(id);      
            }
        }

        public List<Images> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Images.ToList();    
            }
        }

        public void Update(Images entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Images.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
