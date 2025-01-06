namespace Bookstore_Inventry.Extensions
{
    public class SearchEngineExtensions
    {
        public static IQueryable<AdvocateDTO> Search(this IQueryable<AdvocateDTO> advocates, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return advocates;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return advocates.Where(w => w.Name.ToLower().Contains(lowerCaseTerm));

        }
    }
}
