using Proj9.DAL.Base;
using Proj9.DAL.BaseInfrastructure;
using Proj9.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Proj9.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemRepo _ItemRepo;

        public ItemService(IUnitOfWork unitOfWork, IItemRepo ItemRepo)
        {
            _unitOfWork = unitOfWork;
            _ItemRepo = ItemRepo;
        }
        public async Task<ItemMaster> GetAdminByIdAsync(long id)
        {
            return await _ItemRepo.GetByIdAsync(id);
        }
        public async Task<bool> CreateItem(ItemMaster Item)
        {
            await _ItemRepo.AddAsync(Item);

            if (await SaveItem()) return true;
            else return false;
        }
        public async Task<bool> UpdateItem(ItemMaster Item)
        {
            _ItemRepo.Update(Item);

            if (await SaveItem()) return true;
            else return false;
        }
        private async Task<bool> SaveItem()
        {
            try
            {
                if (await _unitOfWork.CommitAsync()) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public interface IItemService
    {
        Task<bool> CreateItem(ItemMaster Item);
        Task<bool> UpdateItem(ItemMaster Item);
    }
}
