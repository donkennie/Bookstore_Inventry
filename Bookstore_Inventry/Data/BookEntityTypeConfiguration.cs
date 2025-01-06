using Bookstore_Inventry.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore_Inventry.Data
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.StockQuantity).HasDefaultValue(0).IsRequired();
        }
    }
}
