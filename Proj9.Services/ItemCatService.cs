using Proj9.DAL.Base;
using Proj9.DAL.BaseInfrastructure;
using Proj9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj9.Services
{
    public class ItemCatService : IItemCatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemCatRepo _ItemCatRepo;

        public ItemCatService(IUnitOfWork unitOfWork, IItemCatRepo ItemCatRepo)
        {
            _unitOfWork = unitOfWork;
            _ItemCatRepo = ItemCatRepo;
        }
        public async Task<ItemCategory> GetAdminByIdAsync(long id)
        {
            return await _ItemCatRepo.GetByIdAsync(id);
        }
        public async Task<IEnumerable<ItemCategory>> GetAllItemCat()
        {
            return await _ItemCatRepo.GetAllAsync();
        }
        public async Task<bool> CreateItemCat(ItemCategory Item)
        {
            await _ItemCatRepo.AddAsync(Item); ;

            if (await SaveItemCat()) return true;
            else return false;
        }
        public async Task<bool> UpdateItemCat(ItemCategory Item)
        {
            _ItemCatRepo.Update(Item);

            if (await SaveItemCat()) return true;
            else return false;
        }
        private async Task<bool> SaveItemCat()
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
    public interface IItemCatService
    {
        Task<bool> CreateItemCat(ItemCategory Item);
        Task<bool> UpdateItemCat(ItemCategory Item);
        Task<IEnumerable<ItemCategory>> GetAllItemCat();
    }
}
