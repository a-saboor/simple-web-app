using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proj9.DAL.Base;
using Proj9.DAL.BaseInfrastructure;
using Proj9.DAL.Entities;
using Proj9.Services;

namespace Proj9.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();

            //Services
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemCatService, ItemCatService>();


            //Repositories
            services.AddScoped<IAdminRepo, AdminRepo>();
            services.AddScoped<IItemRepo, ItemRepo>();
            services.AddScoped<IItemCatRepo, ItemCatRepo>();

            //DTOs
            services.AddDbContext<DB9Context>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                assembly => assembly.MigrationsAssembly(typeof(DB9Context).Assembly.FullName));
            });

            return services;
        }
    }
}