using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Models;
using Bookstore_Inventry.Repositories.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_Inventry.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController(IBookRepository _bookRepository) : ControllerBase
    {

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null)
                return NotFound();

            return Ok(book);
        }


        [HttpPost]
        [Route("/create-book")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBook([FromBody] BookDTO request)
        {
            var book = new Book(request);
            var result = await _bookRepository.AddAsync(book);
            return CreatedAtAction(nameof(GetBook), new { id = result.Id }, result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooks([FromQuery]FilterData request)
        {
            var book = await _bookRepository.GetAllAsync(request);

            return Ok(book);
        }

        [HttpPut]
        [Route("/update-stock")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook(Guid id, int quantity)
        {
            var validator = new StockUpdateValidator();
            validator.ValidateAndThrow(quantity);
            var result = await _bookRepository.UpdateStockAsync(id, quantity);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
