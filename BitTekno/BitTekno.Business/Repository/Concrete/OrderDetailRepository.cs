using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(OrderDetail entity)
        {
           using(BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.OrderDetail.Add(entity);    
                context.SaveChanges();  
            }
        }

        public void Delete(int id)
        {
            OrderDetail orderdetail = context.OrderDetail.Find(id);
            context.OrderDetail.Remove(orderdetail);
            context.SaveChanges();
        }

        public void Delete(OrderDetail entity)
        {
            context.OrderDetail.Remove(entity);
            context.SaveChanges();
        }

        public OrderDetail Get(int id)
        {
            return context.OrderDetail.Find(id);
        }

        public List<OrderDetail> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.OrderDetail.ToList();
            }
        }

        public void Update(OrderDetail entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.OrderDetail.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
