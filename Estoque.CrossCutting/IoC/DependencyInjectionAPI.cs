
using Estoque.Domain.Interfaces;
using Estoque.Infrastructure.Context;
using Estoque.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Estoque.Application.Mappings;
using Estoque.Application.Interfaces;
using Estoque.Application.Services;


namespace Estoque.CrossCutting.IoC
{
    public static class DependencyInjectionAPI
    {

        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddAutoMapper(cfg => { }, typeof(DomainToDTOMappingProfile));

            return services;
        }

    }
}
