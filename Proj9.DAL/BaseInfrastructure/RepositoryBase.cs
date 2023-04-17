using Microsoft.EntityFrameworkCore;
using Proj9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proj9.DAL.BaseInfrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
		private DB9Context dataContext;
		private readonly DbSet<T> dbSet;

		protected IDbFactory DbFactory
		{
			get;
			private set;
		}

		protected DB9Context DbContext
		{
			get { return dataContext ?? (dataContext = DbFactory.Init()); }
		}
		#endregion

        protected RepositoryBase(IDbFactory dbFactory)
		{
			DbFactory = dbFactory;
			dbSet = DbContext.Set<T>();
		}

        #region Implementation

		public virtual async Task AddAsync(T entity)
		{
			await dbSet.AddAsync(entity);
		}


		public virtual void Update(T entity)
		{
			dbSet.Attach(entity);
			dataContext.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(T entity)
		{
			dbSet.Remove(entity);
		}


		public virtual void Delete(Expression<Func<T, bool>> where)
		{
			IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
			foreach (T obj in objects)
				dbSet.Remove(obj);
		}

		public virtual async Task<T> GetByIdAsync (long id)
		{
			return await dbSet.FindAsync(id);
		}
        
        public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
		{
			return await dbSet.Where(where).ToListAsync();
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> where)
		{
			return await dbSet.Where(where).FirstOrDefaultAsync<T>();
		}

		#endregion
    }


	public interface IRepository<T> where T : class
	{
		Task AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(Expression<Func<T, bool>> where);
		Task<T> GetByIdAsync(long id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);
		Task<T> GetAsync(Expression<Func<T, bool>> where);
	}
}