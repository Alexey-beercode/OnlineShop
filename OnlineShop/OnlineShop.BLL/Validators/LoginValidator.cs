using FluentValidation;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Validators;

public class LoginValidator : AbstractValidator<LoginRequestDTO>
{
    public LoginValidator()
    {
        RuleFor(loginDTO => loginDTO.Login)
            .NotEmpty().WithMessage("Login is empty.")
            .Length(3, 50).WithMessage("Login must be between 3 and 50 characters.")
            .Matches(@"^[a-zA-Z0-9]+$").WithMessage("Login must contain only alphanumeric characters.");

        RuleFor(loginDTO => loginDTO.Password)
            .NotEmpty().WithMessage("Password is empty.");
    }
}