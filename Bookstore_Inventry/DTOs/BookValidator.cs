﻿using FluentValidation;

namespace Bookstore_Inventry.DTOs
{
    public class BookValidator : AbstractValidator<BookDTO>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0);
        }
    }

    public class StockUpdateValidator : AbstractValidator<int>
    {
        public StockUpdateValidator()
        {
            RuleFor(x => x)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock quantity cannot be negative");
        }
    }
}
