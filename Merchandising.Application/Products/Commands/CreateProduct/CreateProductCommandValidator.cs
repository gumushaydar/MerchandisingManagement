using FluentValidation;

namespace Merchandising.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
           RuleFor(t => t.Title)
              .MaximumLength(200)
              .NotNull()
              .NotEmpty();

            RuleFor(t => t.CategoryId)
                .NotNull()
                .NotEqual(0); 
        }
    }
}
