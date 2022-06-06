using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class ProductDepartmentRepository : IProductDepartmentRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        
        public void Add(ProductDepartment entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductDepartment.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                ProductDepartment productDepartment = context.ProductDepartment.Find(id);
                context.ProductDepartment.Remove(productDepartment);
                context.SaveChanges();
            }
        }

        public void Delete(ProductDepartment entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductDepartment.Remove(entity);
                context.SaveChanges();
            }
        }

        public ProductDepartment Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.ProductDepartment.Find(id);
            }
        }

        public List<ProductDepartment> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.ProductDepartment.ToList();
            }
        }

        public void Update(ProductDepartment entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.ProductDepartment.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
