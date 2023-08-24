using KitchenRouter.Domain.Enums;
using KitchenRouter.Domain.Validations;
using System.Net.Http.Headers;

namespace KitchenRouter.Domain.Models
{
    public class Order : BaseEntity
    {
        public string OrderDescription { get; init; }
        public int Quantity { get; init; }
        public KitchenArea KitchenArea  { get; init; }
        public bool IsCompleted { get; init; }

        public Order(string orderDescription, int quantity, KitchenArea kitchenArea, 
            bool isCompleted = false) 
        {
            OrderDescription = orderDescription;
            KitchenArea = kitchenArea;
            Quantity = quantity;
            IsCompleted = isCompleted;

            Validate(this, new OrderValidator());
        }
    }
}
