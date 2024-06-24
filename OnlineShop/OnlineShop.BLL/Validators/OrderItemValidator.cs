using FluentValidation;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Entities.Validators
{
    public class OrderItemValidator : AbstractValidator<OrderItemRequestDTO>
    {
        public OrderItemValidator()
        {
            RuleFor(oi => oi.Id).NotEmpty().WithMessage("Id is empty");
            RuleFor(oi => oi.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity can't be less than zero");
        }
    }
}
