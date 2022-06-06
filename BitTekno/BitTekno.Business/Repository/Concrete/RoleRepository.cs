using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Role entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Role.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Role role = context.Role.Find(id);
                context.Role.Remove(role);
                context.SaveChanges();
            }
        }

        public void Delete(Role entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Role.Remove(entity);
                context.SaveChanges();
            }

        }

        public Role Get(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Role.Find(id);
            }

        }

        public List<Role> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Role.ToList();
            }

        }

        public void Update(Role entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Role.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
