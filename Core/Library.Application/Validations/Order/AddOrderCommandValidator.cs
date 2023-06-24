using FluentValidation;
using Library.Application.Features.Command.Order.AddOrder;

namespace Library.Application.Validations.Order;

public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
{
    public AddOrderCommandValidator()
    {
        RuleFor(x => x.ReceivedDate)
        .NotEmpty().WithMessage("Received Date Field must not be empty.")
        .GreaterThanOrEqualTo(DateTime.Now)
        .WithMessage("Received Date cannot be less than today.");

        RuleFor(x => x.ReturnDate)
       .NotEmpty().WithMessage("Received Date Field must not be empty.")
       .GreaterThan(x => x.ReceivedDate)
       .WithMessage("Return Date cannot be less than the received date");
    } 
}