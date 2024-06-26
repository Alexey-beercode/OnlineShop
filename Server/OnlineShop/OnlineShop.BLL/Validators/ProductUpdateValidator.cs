using FluentValidation;
using OnlineShop.BLL.DTO.Requests;

namespace OnlineShop.BLL.Validators
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateRequestDTO>
    {
        public ProductUpdateValidator()
        {
            RuleFor(product => product.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");

            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(product => product.Description)
                .MaximumLength(500).WithMessage("Description must be less than or equal to 500 characters.");

            RuleFor(product => product.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required.");
        }
    }
}