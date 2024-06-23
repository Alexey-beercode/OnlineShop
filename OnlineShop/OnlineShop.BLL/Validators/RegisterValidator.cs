using FluentValidation;
using OnlineShop.BLL.DTO.Request;

namespace OnlineShop.BLL.Validators;

public class RegisterValidator : AbstractValidator<RegisterRequestDTO>
{
    public RegisterValidator()
    {
        RuleFor(registerDTO => registerDTO.Login)
            .NotEmpty().WithMessage("Login is empty.")
            .Length(3, 50).WithMessage("Login must be between 3 and 50 characters.")
            .Matches(@"^[a-zA-Z0-9]+$").WithMessage("Login must contain only alphanumeric characters.");

        RuleFor(registerDTO => registerDTO.Password)
            .NotEmpty().WithMessage("Password is empty.");

        RuleFor(registerDTO => registerDTO.FirstName)
            .NotEmpty().WithMessage("First name is empty.")
            .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

        RuleFor(registerDTO => registerDTO.LastName)
            .NotEmpty().WithMessage("Last name is empty.")
            .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.");
    }
}