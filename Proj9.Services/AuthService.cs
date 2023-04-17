using Proj9.DAL.Entities;
using Proj9.DTOs;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Proj9.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAdminService _adminService;

        public AuthService(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<(bool, string)> AdminRegister(RegisterDto registerDto)
        {
            var data = await _adminService.GetAdminByEmailAsync(registerDto.Email);
            if (data != null) return (false, "Email already exists..!");
            using var hmac = new HMACSHA512();
            var user = new Admin
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                Salt = hmac.Key
            };

            if (await _adminService.CreateAdminAsync(user))
            {
                return (true, "Register Successfull");
            }
            else
            {
                return (false, "Oops..! something went wrong");
            }
        }

        public async Task<(bool, string)> AdminLogin(LoginDto loginDto)
        {
            try
            {
                var user = await _adminService.GetAdminByEmailAsync(loginDto.Email);
                if (user != null)
                {
                    using var hmac = new HMACSHA512(user.Salt);
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != user.Password[i]) return (false, "Wrong password..!");
                    }
                    return (true, "Login Successfull");
                }
                else return (false, "Email not found..!");
            }
            catch (System.Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
    public interface IAuthService
    {
        Task<(bool, string)> AdminRegister(RegisterDto registerDto);
        Task<(bool, string)> AdminLogin(LoginDto loginDto);
    }
}
