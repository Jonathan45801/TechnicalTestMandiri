using Ocelot.DependencyInjection;
using Ocelot.Middleware;
namespace Ocelot.ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddOcelot(builder.Configuration);
            builder.Configuration.AddJsonFile("ocelot.json");
            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("Cors", opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });
            var app = builder.Build();
            app.UseRouting();
            app.UseCors("Cors");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseOcelot();
            app.Run();
        }
    }
}
