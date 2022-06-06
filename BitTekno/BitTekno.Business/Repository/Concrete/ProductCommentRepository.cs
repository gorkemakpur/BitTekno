using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class ProductCommentRepository : IProductCommentRepository
    {
        BitteknoEntitiess context= new BitteknoEntitiess();
        public void Add(ProductComment entity)
        {
           using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductComment.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                ProductComment productComment = context.ProductComment.Find(id);
                context.ProductComment.Remove(productComment);
                context.SaveChanges();  
            }
        }

        public void Delete(ProductComment entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductComment.Remove(entity);
                context.SaveChanges();
            }
        }

        public ProductComment Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.ProductComment.Find(id);
            }
        }

        public List<ProductComment> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
               return context.ProductComment.ToList();
            }
            
        }

        public void Update(ProductComment entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductComment.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
