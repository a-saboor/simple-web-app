using Proj9.DAL.BaseInfrastructure;
using Proj9.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Proj9.DAL.Base
{
    public class AdminRepo : RepositoryBase<Admin>, IAdminRepo
    {
        public AdminRepo(IDbFactory dbFactory) : base(dbFactory) { }

        public async Task<Admin> GetAdminByEmail(string email)
        {
            return await Task.Run(() => DbContext.Admins.Where(x => x.Email == email).FirstOrDefault());
        }


    }
    public interface IAdminRepo : IRepository<Admin>
    {
        Task<Admin> GetAdminByEmail(string email);
    }
}