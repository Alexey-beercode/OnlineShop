using FluentValidation;
using OnlineShop.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Entities.Validators
{
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(oi => oi.Id).NotNull().WithMessage("Id is empty");
            RuleFor(oi => oi.OrderId).NotNull().WithMessage("OrderId is empty");
            RuleFor(oi => oi.ProductId).NotNull().WithMessage("ProductId is empty");
            RuleFor(oi => oi.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity can't be less than zero");
        }
    }
}
