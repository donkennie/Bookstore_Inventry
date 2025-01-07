using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Models;

namespace Bookstore_Inventry.Services
{
    public interface IBookService
    {
        Task<Response<BookViewModel>> CreateBook(BookDTO book);
        Task<Response<List<BookViewModel>>> GetBooks(FilterData filter);
        Task<Response<BookViewModel>> GetBook(Guid id);
        Task<Response<BookViewModel>> UpdateStock(Guid id, int quantity);
    }
}
