namespace Bookstore_Inventry.DTOs
{
    public class BookDTO
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
