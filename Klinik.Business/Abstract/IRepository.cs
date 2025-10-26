using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Klinik.Business.Abstract
{
	public interface IRepository<T> where T : class

	{
		List<T> TGetList();
		void TCreate(T entity);
		void TUpdate(T entity);
		void TDelete(Guid Id); 
		T TGetById(Guid Id); 
		T TGetByFilter(Expression<Func<T, bool>> filter);
		int TCount();
		int TFilterCount(Expression<Func<T, bool>> filter);
		List<T> TGetFilterList(Expression<Func<T, bool>> filter);
	}
}
