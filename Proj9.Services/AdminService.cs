using Proj9.DAL.Base;
using Proj9.DAL.BaseInfrastructure;
using Proj9.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Proj9.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdminRepo _AdminRepo;
        public AdminService(IUnitOfWork unitOfWork, IAdminRepo AdminRepository)
        {
            _unitOfWork = unitOfWork;
            _AdminRepo = AdminRepository;
        }
        public async Task<Admin> GetAdminByIdAsync(long id)
        {
            return await _AdminRepo.GetByIdAsync(id);
        }
        public async Task<Admin> GetAdminByEmailAsync(string Email)
        {
            return await _AdminRepo.GetAdminByEmail(Email);
        }
        public async Task<bool> CreateAdminAsync(Admin Admin)
        {
            await _AdminRepo.AddAsync(Admin);

            if (await SaveAdminAsync()) return true;
            else return false;
        }
        public async Task<bool> UpdateAdminAsync(Admin Admin)
        {
            _AdminRepo.Update(Admin);

            if (await SaveAdminAsync()) return true;
            else return false;
        }
        private async Task<bool> SaveAdminAsync()
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
    public interface IAdminService
    {
        Task<Admin> GetAdminByIdAsync(long id);
        Task<Admin> GetAdminByEmailAsync(string Email);
        Task<bool> CreateAdminAsync(Admin Admin);
        Task<bool> UpdateAdminAsync(Admin Admin);
    }
}