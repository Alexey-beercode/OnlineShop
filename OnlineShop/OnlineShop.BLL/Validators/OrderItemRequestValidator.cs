using FluentValidation;
using OnlineShop.BLL.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Validators
{
    public class OrderItemRequestValidator : AbstractValidator<OrderItemRequestDTO>
    {
        public OrderItemRequestValidator()
        {
            RuleFor(oi => oi.ProductId).NotNull().WithMessage("ProductId is empty");
            RuleFor(oi => oi.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity can't be less than zero");
        }
    }
}
