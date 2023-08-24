﻿using KitchenRouter.Domain.Enums;
using System.Text.Json.Serialization;

namespace KitchenRouter.Application.DTOs
{
    public record OrderRequest
    {
        public string ItemName { get; init; }
        public int Quantity { get; init; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public KitchenArea KitchenArea { get; init; }

        public OrderRequest(string itemName, int quantity, KitchenArea kitchenArea)
        {
            ItemName = itemName;
            KitchenArea = kitchenArea;
            Quantity = quantity;
        }
    }
}
