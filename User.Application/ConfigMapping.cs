using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Mapster;
namespace User.Application
{
    public static class ConfigMapping
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(MapsterBase<,>).Assembly);

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}
