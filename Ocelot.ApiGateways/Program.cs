
using Ocelot.Values;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Ocelot.ApiGateways
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddOcelot(builder.Configuration);
            builder.Configuration.AddJsonFile("ocelot.Development.json");
            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("Cors", opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });
            var app = builder.Build();
            app.UseRouting();
            app.UseCors("Cors");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            await app.UseOcelot();
            app.Run();
        }
    }
}
