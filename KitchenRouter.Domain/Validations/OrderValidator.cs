using FluentValidation;
using KitchenRouter.Domain.Models;

namespace KitchenRouter.Domain.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() 
        {
            RuleFor(order => order.OrderDescription).NotNull().NotEmpty().WithMessage("Order cannot be empty");
            //RuleFor(order => order.Quantity).GreaterThan(0).WithMessage("Quantity cannot be empty");
            RuleFor(order => order.KitchenArea).IsInEnum().WithMessage("Invalid kitchen area");
        }
    }
}
