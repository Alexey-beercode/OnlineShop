using FluentValidation;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.DAL.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Login)
            .NotEmpty().WithMessage("Login is empty.")
            .Length(3, 50).WithMessage("Login must be between 3 and 50 characters.")
            .Matches(@"^[a-zA-Z0-9]+$").WithMessage("Login must contain only alphanumeric characters.");

        RuleFor(user => user.PasswordHash)
            .NotEmpty().WithMessage("Password is empty.");

        RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("First name is empty.")
            .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

        RuleFor(user => user.LastName)
            .NotEmpty().WithMessage("Last name is empty.")
            .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.");
    }
}