using KitchenRouter.Domain.Enums;
using System.Text.Json.Serialization;

namespace KitchenRouter.Application.DTOs
{
    public record OrderResponse
    {
        public string ItemName { get; init; }
        public int Quantity { get; init; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public KitchenArea KitchenArea { get; init; }

        public OrderResponse(string itemName, int quantity, KitchenArea kitchenArea)
        {
            ItemName = itemName;
            Quantity = quantity;
            KitchenArea = kitchenArea;
        }
    }
}
