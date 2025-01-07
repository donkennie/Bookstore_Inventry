using Bookstore_Inventry.Data;
using Bookstore_Inventry.Repositories.Abstractions;

namespace Bookstore_Inventry.Repositories.Implemetations
{
    public class BookRepository(ApplicationDbContext _context) : IBookRepository
    {
       
    }
}
