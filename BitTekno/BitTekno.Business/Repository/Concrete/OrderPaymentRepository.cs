using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class OrderPaymentRepository : IOrderPaymentRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(OrderPayment entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.OrderPayment.Add(entity);
                context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                OrderPayment orderPayment = context.OrderPayment.Find(id);
                context.OrderPayment.Remove(orderPayment);
                context.SaveChanges();
            }
        }

        public void Delete(OrderPayment entity)
        {
            context.OrderPayment.Remove(entity);
            context.SaveChanges();
        }

        public OrderPayment Get(int id)
        {
            return context.OrderPayment.Find(id);
        }

        public List<OrderPayment> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.OrderPayment.ToList();
            }
        }

        public void Update(OrderPayment entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.OrderPayment.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
