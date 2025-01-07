using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Models;

namespace Bookstore_Inventry.Services
{
    public interface IBookService
    {
        Task<Response<string>> CreateBook(BookDTO book);
        Task<Response<BookViewModel>> GetBooks(FilterData filter);
        Task<Response<BookViewModel>> GetBook(Guid id);
        Task<Response<BookViewModel>> UpdateStock(Guid id, int quantity);
    }
}
