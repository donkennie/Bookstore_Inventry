using Bookstore_Inventry.DTOs;

namespace Bookstore_Inventry.Extensions
{
    public static class SearchEngineExtensions
    {
        public static IQueryable<BookDTO> Search(this IQueryable<BookDTO> advocates, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return advocates;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return advocates.Where(w => w.Title.ToLower().Contains(lowerCaseTerm));

        }
    }
}
