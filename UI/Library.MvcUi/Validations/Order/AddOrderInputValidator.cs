using FluentValidation;
using Library.MvcUi.Models.Order;

namespace Library.MvcUi.Validations.Order
{
    public class AddOrderInputValidator : AbstractValidator<AddOrderInput>
    {
        public AddOrderInputValidator()
        {
            RuleFor(x => x.ReceivedDate)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Received Date cannot be less than today.");

            RuleFor(x => x.ReturnDate)
           .GreaterThan(x => x.ReceivedDate)
           .WithMessage("Return Date cannot be less than the received date");
        }
    }
}
