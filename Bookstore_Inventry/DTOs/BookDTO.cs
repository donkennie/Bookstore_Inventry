namespace Bookstore_Inventry.DTOs
{
    public class BookDTO
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
    }
}
