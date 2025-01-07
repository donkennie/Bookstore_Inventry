using Bookstore_Inventry.Data;
using Bookstore_Inventry.Repositories.Abstractions;
using Bookstore_Inventry.Repositories.Implemetations;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FluentValidation.AspNetCore;
using Bookstore_Inventry.DTOs;
using FluentValidation;
using Bookstore_Inventry.Services;

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

            serviceCollection.AddAutoMapper(typeof(MappingProfile));

            serviceCollection.AddValidatorsFromAssemblyContaining<BookValidator>();
            serviceCollection.AddFluentValidationAutoValidation();

            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IBookService, BookService>();

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
