using Bookstore_Inventry.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Bookstore_Inventry.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void Configure(this IServiceCollection serviceCollection, IConfiguration _config)
        {
            Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(_config).CreateLogger();

            serviceCollection.AddDbContext<ApplicationDbContext>(Options =>
            {
                Options.UseNpgsql(_config.GetConnectionString("DefaultConnection"));

            });

            serviceCollection.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://example.com");
                });
            });
        }
    }
}
