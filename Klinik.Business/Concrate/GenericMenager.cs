using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Klinik.Business.Abstract;

namespace Klinik.Business.Concrate
{
	public class GenericMenager<T>(IRepository<T> _repository) : IRepository<T> where T : class
	{
		public int TCount()
		{
			return _repository.TCount();
		}

		public void TCreate(T entity)
		{
			_repository.TCreate(entity);
		}

		public void TDelete(Guid Id)
		{
			_repository.TDelete(Id);
		}

		public int TFilterCount(Expression<Func<T, bool>> filter)
		{
			return _repository.TFilterCount(filter);
		}

		public T TGetByFilter(Expression<Func<T, bool>> filter)
		{
			return _repository.TGetByFilter(filter);
		}

		public T TGetById(Guid Id)
		{
			return _repository.TGetById(Id);
		}

		public List<T> TGetFilterList(Expression<Func<T, bool>> filter)
		{
			return _repository.TGetFilterList(filter);
		}

		public List<T> TGetList()
		{
			if (_repository.TGetList() != null)
			{
				return _repository.TGetList();
			}
			return null;
		}

		public void TUpdate(T entity)
		{
			_repository.TUpdate(entity);
		}
	}
}
