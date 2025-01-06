using Bookstore_Inventry.DTOs;

namespace Bookstore_Inventry.Models
{
    public class Book
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public Book(){}
        public Book(BookDTO bookDTO)
        {
            Name = bookDTO.Name;
            Author = bookDTO.Author;
            Title = bookDTO.Title;
            Price = bookDTO.Price;
            StockQuantity = bookDTO.StockQuantity;
        }

        public void UpdateStock(int stockQuantity)
        {
            this.StockQuantity = stockQuantity;
        }
    }
}
