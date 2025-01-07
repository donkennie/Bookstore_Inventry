using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Models;

namespace Bookstore_Inventry.Extensions
{
    public static class SearchEngineExtension
    {
        public static IQueryable<Book> SearchAuthor(this IQueryable<Book> book, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return book;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return book.Where(w => w.Author.ToLower().Contains(lowerCaseTerm));

        }
    }
}
