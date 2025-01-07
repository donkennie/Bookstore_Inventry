using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Models;
using Bookstore_Inventry.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_Inventry.Controllers
{
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
        [ProducesResponseType(typeof(BookDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBook(BookDTO request)
        {
            var book = new Book(request);
            var result = await _bookRepository.AddAsync(book);
            return CreatedAtAction(nameof(GetBook), new { id = result.Id }, result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBooks(FilterData request)
        {
            var book = await _bookRepository.GetAllAsync(request);

            return Ok(book);
        }

        [HttpPut]
        [ProducesResponseType(typeof(BookDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AppException), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook(Guid id, int quantity)
        {
            var result = await _bookRepository.UpdateStockAsync(id, quantity);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
