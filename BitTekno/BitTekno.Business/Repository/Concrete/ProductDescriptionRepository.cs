using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class ProductDescriptionRepository : IProductDescriptionRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(ProductDescription entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductDescription.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                ProductDescription productDescription = context.ProductDescription.Find(id);
                context.ProductDescription.Remove(productDescription);
                context.SaveChanges();
            }
        }

        public void Delete(ProductDescription entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductDescription.Remove(entity);
                context.SaveChanges();
            }
        }

        public ProductDescription Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.ProductDescription.Find(id);
            }
        }

        public List<ProductDescription> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.ProductDescription.ToList();
            }
        }

        public void Update(ProductDescription entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductDescription.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
