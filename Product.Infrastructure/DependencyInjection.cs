using Microsoft.Extensions.DependencyInjection;
using Product.Application.Interface;
using Product.Infrastructure.AuthMiddleware;
namespace Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuth, Auth>();
            return services;
        }
    }
}
