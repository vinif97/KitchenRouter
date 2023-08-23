using KitchenRouter.Domain.Enums;

namespace KitchenRouter.Application.DTOs
{
    public record OrderRequest
    {
        public string ItemName { get; init; }
        public int Quantity { get; init; }
        public KitchenArea KitchenArea { get; init; }

        public OrderRequest(string itemName, int quantity, KitchenArea kitchenArea)
        {
            ItemName = itemName;
            KitchenArea = kitchenArea;
            Quantity = quantity;
        }
    }
}
