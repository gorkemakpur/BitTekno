using BitTekno.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitTekno.Base.DataAccess
{

    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
		T Get(Expression<Func<T, bool>> filter = null);
		List<T> GetList(Expression<Func<T, bool>> filter = null);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		List<T> GetInclude(Expression<Func<T, object>> expression = null);
		List<T> GetIncludee(Expression<Func<T, object>> expression = null, Expression<Func<T, object>> expression2 = null);
	}
}
