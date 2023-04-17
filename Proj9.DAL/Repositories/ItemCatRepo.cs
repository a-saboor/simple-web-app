using Proj9.DAL.BaseInfrastructure;
using Proj9.DAL.Entities;

namespace Proj9.DAL.Base
{
    public class ItemCatRepo : RepositoryBase<ItemCategory>, IItemCatRepo
    {
        public ItemCatRepo(IDbFactory dbFactory) : base(dbFactory) { }



        //public async Task<ItemMaster> GetAdminByEmail(string email)
        //{
        //    return await Task.Run(() => DbContext.ItemMasters.Where(x => x.Email == email).FirstOrDefault());
        //}
    }
    public interface IItemCatRepo : IRepository<ItemCategory>
    {
        //Task<ItemMaster> GetAdminByEmail(string email);
    }
}