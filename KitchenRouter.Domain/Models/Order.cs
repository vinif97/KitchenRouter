using KitchenRouter.Domain.Enums;

namespace KitchenRouter.Domain.Models
{
    public class Order : BaseEntity
    {
        public string ItemName { get; init; }
        public int Quantity { get; init; }
        public KitchenArea KitchenArea  { get; init; }

        public Order(string itemName, int quantity, KitchenArea kitchenArea) 
        {
            ItemName = itemName;
            KitchenArea = kitchenArea;
            Quantity = quantity;
        }
    }
}
