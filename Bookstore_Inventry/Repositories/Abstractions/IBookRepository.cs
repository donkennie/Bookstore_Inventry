using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Models;

namespace Bookstore_Inventry.Repositories.Abstractions
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(BookDTO book);
        Task<IEnumerable<Book>> GetAllAsync(FilterData filter);
        Task<Book?> GetByIdAsync(Guid id);
        Task<Book?> UpdateStockAsync(Guid id, int quantity);
    }
}
