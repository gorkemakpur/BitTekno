using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Order entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Order.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Order order = context.Order.Find(id);
                context.Order.Remove(order);
                context.SaveChanges();
            }
        }

        public void Delete(Order entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Order.Remove(entity);
                context.SaveChanges();
            }
        }

        public Order Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Order.Find(id);
            }
        }

        public List<Order> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Order.ToList();
            }
        }

        public void Update(Order entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Order.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
