namespace Bookstore_Inventry.DTOs
{
    public record FilterData(
            string? author,
            decimal? minPrice,
            decimal? maxPrice
    );
}
