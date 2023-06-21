using FluentValidation;
using Library.Application.Features.Command.User.LoginUser;

namespace Library.Application.Validations.User;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email Field must not be empty.")
            .MaximumLength(75).WithMessage("Email must be a maximum of 75 characters.")
            .EmailAddress().WithMessage("The entered value must be in Email format..");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password Field must not be empty.")
            .MinimumLength(6).WithMessage("Password must be a minimum of 6 characters.")
            .MaximumLength(20).WithMessage("Password must be a maximum of 20 characters.");
    }
}