using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Interface;
using User.Application.Interface.Repository;
using User.Persistence.Context;
using User.Persistence.Repository;

namespace User.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IDbUserContext, DbUserContext>(options => options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DbUser")));
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserLoginTokenRepository, UserLoginTokenRepository>();
            return services;
        }
    }
}
