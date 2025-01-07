using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_Inventry.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController(IBookService _bookService) : ControllerBase
    {

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _bookService.GetBook(id);
            return Ok(book);
        }


        [HttpPost]
        [Route("/create-book")]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBook([FromBody] BookDTO request)
        {
            var result = await _bookService.CreateBook(request);
            return CreatedAtAction(nameof(GetBook), new { id = result.Data.Id }, result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooks([FromQuery]FilterData request)
        {
            var result = await _bookService.GetBooks(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("/update-stock")]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook(Guid id, int quantity)
        {
            var result = await _bookService.UpdateStock(id, quantity);
            return Ok(result);
        }
    }
}
