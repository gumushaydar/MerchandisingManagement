using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchandising.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(t => t.Title)
                .MaximumLength(200)
                .NotNull()
                .NotEmpty();
        }
    }
}
