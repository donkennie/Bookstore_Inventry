﻿using Bookstore_Inventry.DTOs;
using Bookstore_Inventry.Models;
using Bookstore_Inventry.Repositories.Abstractions;
using FluentValidation;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookstore_Inventry.Services
{
    public class BookService(IBookRepository _bookRepository, ILogger<BookService> _logger) : IBookService
    {
        public async Task<Response<string>> CreateBook(BookDTO bookDto)
        {
            var response = new Response<string>();
            try
            {
                var book = new Book(bookDto);
                var result = await _bookRepository.AddAsync(book);

                response.StatusCode = StatusCodes.Status201Created;
                response.Message = "Book created successfully!";
                response.Data = book;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a book");
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = "request failed. Please try again...";
                throw;
            }
        }

        public async Task<Response<BookViewModel>> GetBook(Guid id)
        {
            var response = new Response<BookViewModel>();
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book is null){
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Message = "Book not found";
                    return response;
                }

                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Book fetched successfully!";
                response.Data = book;

                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a book");
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = "request failed. Please try again...";
                throw;
            }
        }

        public async Task<Response<BookViewModel>> GetBooks(FilterData filter)
        {
            var response = new Response<BookViewModel>();
            try
            {
                var books = await _bookRepository.GetAllAsync(filter);
                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Books fetched successfully!";
                response.Data = books;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a book");
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = "request failed. Please try again...";
                throw;
            }
        }

        public async Task<Response<BookViewModel>> UpdateStock(Guid id, int quantity)
        {
            var response = new Response<BookViewModel>();
            try
            {
                var validator = new StockUpdateValidator();
                validator.ValidateAndThrow(quantity);
                var book = await _bookRepository.UpdateStockAsync(id, quantity);
                if (book is null)
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    response.Message = "Book not found";
                    return response;
                }

                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Books updated successfully!";
                response.Data = book;

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a book");
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = "request failed. Please try again...";
                throw;
            }
        }
    }
}