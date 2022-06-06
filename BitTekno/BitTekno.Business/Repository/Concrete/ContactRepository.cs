using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class ContactRepository : IContactRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Contact entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Contact.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Contact contact = context.Contact.Find(id);
                context.Contact.Remove(contact);
                context.SaveChanges();
            }
        }

        public void Delete(Contact entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Contact.Remove(entity);
                context.SaveChanges();
            }
        }

        public Contact Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Contact.Find(id);
            }
        }

        public List<Contact> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Contact.ToList();
            }
        }

        public void Update(Contact entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Contact.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
