using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Product entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Product.Add(entity);
                context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Product product = context.Product.Find(id);
                context.Product.Remove(product);
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Product.Remove(entity);
                context.SaveChanges();
            }
        }

        public Product Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Product.Find(id);
            }
        }

        public List<Product> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Product.ToList();
            }
        }

        public void Update(Product entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Product.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
