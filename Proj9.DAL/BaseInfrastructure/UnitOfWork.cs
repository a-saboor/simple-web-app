using Proj9.DAL.Entities;
using System.Threading.Tasks;

namespace Proj9.DAL.BaseInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
		private DB9Context dbContext;

        public UnitOfWork(IDbFactory dbFactory)
		{
			this.dbFactory = dbFactory;
		}

		public DB9Context DbContext
		{
			get { return dbContext ?? (dbContext = dbFactory.Init()); }
		}
		public async Task<bool> CommitAsync()
		{
			return await DbContext.SaveChangesAsync() > 0;
		}
    }

	public interface IUnitOfWork
	{
		Task<bool> CommitAsync();
	}
}