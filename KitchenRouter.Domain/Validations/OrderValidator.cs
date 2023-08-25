using FluentValidation;
using KitchenRouter.Domain.Errors;
using KitchenRouter.Domain.Models;
using static KitchenRouter.Domain.Errors.DomainErrors;

namespace KitchenRouter.Domain.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() 
        {
            RuleFor(order => order.OrderDescription).NotNull().NotEmpty()
                .WithMessage(string.Format(DomainErrors.Errors[DomainErrorCode.CannotBeEmpty], "Order"));
            RuleFor(order => order.Quantity).GreaterThan(0)
                .WithMessage(string.Format(DomainErrors.Errors[DomainErrorCode.CannotBeEmpty], "Quantity"));
            RuleFor(order => order.KitchenArea).IsInEnum()
                .WithMessage(string.Format(DomainErrors.Errors[DomainErrorCode.InvalidValue], "kitchen area"));
        }
    }
}
