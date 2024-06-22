using Microsoft.Extensions.DependencyInjection;
using Product.Application.Interface;
using Product.Application.Interface.Repository;
using Product.Persistence.Context;
using Product.Persistence.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Http;

namespace Product.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDbProductContext, DbProductContext>(options => options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DbProduct")));
            services.AddScoped<IProductHeaderRepository, ProductHeaderRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
            services.AddScoped<IProductAllRepository, ProductAllRepository>();
            services.AddHttpClient<IAuthUser, AuthUser>();
            return services;
        }
    }
}
