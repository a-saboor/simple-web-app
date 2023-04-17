using Proj9.DAL.BaseInfrastructure;
using Proj9.DAL.Entities;

namespace Proj9.DAL.Base
{
    public class UserRepo : RepositoryBase<User>, IAppUserRepository
    {
        public UserRepo(IDbFactory dbFactory) : base(dbFactory) { }

    }

    public interface IAppUserRepository : IRepository<User>
    {

    }
}