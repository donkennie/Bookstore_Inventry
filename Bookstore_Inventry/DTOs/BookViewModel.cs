namespace Bookstore_Inventry.DTOs
{
    public record BookViewModel
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
