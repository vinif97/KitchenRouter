﻿using KitchenRouter.Domain.Enums;
using System.Text.Json.Serialization;

namespace KitchenRouter.Application.DTOs
{
    public record OrderRequest
    {
        public string OrderDescription { get; init; }
        public int Quantity { get; init; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public KitchenArea KitchenArea { get; init; }

        public OrderRequest(string orderDescription, int quantity, KitchenArea kitchenArea)
        {
            OrderDescription = orderDescription;
            KitchenArea = kitchenArea;
            Quantity = quantity;
        }
    }
}
