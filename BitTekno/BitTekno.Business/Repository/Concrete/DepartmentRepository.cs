using BitTekno.Business.Repository.Abstract;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Business.Repository.Concrete
{
    public class DepartmentRepository : IDepartmentRepository
    {
        BitteknoEntitiess context = new BitteknoEntitiess();
        public void Add(Department entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Department.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                Department department = context.Department.Find(id);
                context.Department.Remove(department);
                context.SaveChanges();
            }
        }

        public void Delete(Department entity)
        {
            context.Department.Remove(entity);
            context.SaveChanges();
        }

        public Department Get(int id)
        {
            return context.Department.Find(id);
        }

        public List<Department> GetList()
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                return context.Department.ToList();
            }
        }

        public void Update(Department entity)
        {
            using (BitteknoEntitiess context = new BitteknoEntitiess())
            {
                context.Department.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
