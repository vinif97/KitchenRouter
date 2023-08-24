using AutoMapper;
using KitchenRouter.Application.DTOs;
using KitchenRouter.Domain.Models;

namespace KitchenRouter.Application.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<OrderRequest, Order>();
            CreateMap<Order, OrderResponse>();
        }
    }
}
