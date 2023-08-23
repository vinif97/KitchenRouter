using FluentValidation;
using KitchenRouter.Domain.Models;

namespace KitchenRouter.Domain.Validations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator() 
        {
            RuleFor(order => order.KitchenArea).IsInEnum();
        }
    }
}
