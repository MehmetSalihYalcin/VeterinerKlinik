using Klinik.Business.Abstract;
using Klinik.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Klinik.DataAccess.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : class
	{
		private readonly DBContext _context;
		private readonly DbSet<T> _dbSet;

		public GenericRepository(DBContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public List<T> TGetList()
		{
			return _dbSet.ToList();
		}

		public void TCreate(T entity)
		{
			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		public void TUpdate(T entity)
		{
			_dbSet.Update(entity);
			_context.SaveChanges();
		}

		public void TDelete(Guid Id)
		{
			var entity = TGetById(Id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
				_context.SaveChanges();
			}
		}

		public T TGetById(Guid Id)
		{
			return _dbSet.Find(Id);
		}

		public T TGetByFilter(Expression<Func<T, bool>> filter)
		{
			return _dbSet.FirstOrDefault(filter);
		}

		public int TCount()
		{
			return _dbSet.Count();
		}

		public int TFilterCount(Expression<Func<T, bool>> filter)
		{
			return _dbSet.Count(filter);
		}

		public List<T> TGetFilterList(Expression<Func<T, bool>> filter)
		{
			return _dbSet.Where(filter).ToList();
		}
	}
}