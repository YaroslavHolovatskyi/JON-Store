using AutoMapper;
using JON_Store.DataAccess.Repositories;
using JON_Store.DataAccess.Repositories.Abstract;
using JON_Store.DataAccess.UnitOfWork;
using JON_Store.Mappings;
using JON_Store.Services.Implamentations;
using JON_Store.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JON_Store.Infrastructure
{
    internal static class ServicesConfiguration
    {
        public static void AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainMappingProfile).Assembly);
        }
        public static void AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductService, ProductService>();
        }
        public static void AddMySqlRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
