namespace Bookstore_Inventry.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void Configure(this IServiceCollection serviceCollection, IConfiguration _config)
        {
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
