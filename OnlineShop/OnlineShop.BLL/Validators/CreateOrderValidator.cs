using FluentValidation;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.DAL.Entities.Validators;
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

            RuleFor(order => order.User)
                .NotEmpty().WithMessage("User is not specified.");

            RuleForEach(order => order.OrderItems)
            .SetValidator(new OrderItemRequestValidator());

            RuleFor(order => order.OrderItems)
                .Must(HaveValidQuantities).WithMessage("Invalid quantities in order items.");
        }

        public async Task ValidateAndThrowAsync(CreateOrderRequestDTO createOrderRequestDTO, CancellationToken cancellationToken = default)
        {
            var result = await ValidateAsync(createOrderRequestDTO, cancellationToken);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        private bool HaveValidQuantities(IEnumerable<OrderItemRequestDTO> orderItems)
        {
            var productIds = orderItems.Select(oi => oi.ProductId).Distinct();
            var products = _productRepository.GetByIdsAsync(productIds).Result;

            foreach (var orderItem in orderItems)
            {
                var product = products.FirstOrDefault(p => p.Id == orderItem.ProductId);
                if (product is null )
                {
                    return false;
                }
            }

            return true;
        }
    }

}
