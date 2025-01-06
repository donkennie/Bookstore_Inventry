using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Bookstore_Inventry.Models;

namespace Bookstore_Inventry.Data
{
    public sealed class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Book> Books { get; set; }
    }
}
