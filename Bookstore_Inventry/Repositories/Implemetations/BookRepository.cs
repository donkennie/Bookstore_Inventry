using Bookstore_Inventry.Data;
using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Models;
using Bookstore_Inventry.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Inventry.Repositories.Implemetations
{
    public class BookRepository(ApplicationDbContext _context) : IBookRepository
    {
        public async Task<Book> AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllAsync(FilterData filter)
        {
            var bookQuery = _context.Books
                                    .OrderBy(x => x.CreatedAt)
                                    .AsNoTracking();

            if (filter.author is not null)
                bookQuery = bookQuery.Where(x => x.Author == filter.author);
            if (filter.minPrice is not null)
                bookQuery = bookQuery.Where(x => x.Price >= filter.minPrice.Value);
            if (filter.maxPrice is not null)
                bookQuery = bookQuery.Where(x => x.Price <= filter.maxPrice.Value);

            return await bookQuery.ToListAsync();

        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            var book = await _context.Books
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task<Book?> UpdateStockAsync(Guid id, int quantity)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                book.UpdateStock(quantity);
                await _context.SaveChangesAsync();
            }
            return book;
        }
    }
}
