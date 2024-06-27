using FluentValidation;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequestDTO>
    {
        private readonly IProductRepository _productRepository;

        public CreateOrderValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(order => order.UserId)
                .NotEmpty().WithMessage("User is not specified.");

            RuleForEach(order => order.OrderItems)
            .SetValidator(new OrderItemRequestValidator());
        }

        public async Task ValidateAndThrowAsync(CreateOrderRequestDTO createOrderRequestDTO, CancellationToken cancellationToken = default)
        {
            var result = await ValidateAsync(createOrderRequestDTO, cancellationToken);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        
    }

}
