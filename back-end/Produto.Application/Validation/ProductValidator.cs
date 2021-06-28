using FluentValidation;
using Produto.Application.Dtos;

namespace Produto.Application.Validation
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ImageURL).NotNull().WithMessage("Invalid ImageURL");
            RuleFor(x => x.Name).NotNull().WithMessage("Invalid Product Name");
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("Invalid Value");
        }
    }
}
