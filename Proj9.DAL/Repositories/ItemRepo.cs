using Proj9.DAL.BaseInfrastructure;
using Proj9.DAL.Entities;

namespace Proj9.DAL.Base
{
    public class ItemRepo : RepositoryBase<ItemMaster>, IItemRepo
    {
        public ItemRepo(IDbFactory dbFactory) : base(dbFactory) { }

        //public async Task<ItemMaster> GetAdminByEmail(string email)
        //{
        //    return await Task.Run(() => DbContext.ItemMasters.Where(x => x.Email == email).FirstOrDefault());
        //}
    }
    public interface IItemRepo : IRepository<ItemMaster>
    {
        //Task<ItemMaster> GetAdminByEmail(string email);
    }
}