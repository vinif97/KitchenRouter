using KitchenRouter.Application.DTOs;
using KitchenRouter.Application.Result;

namespace KitchenRouter.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IResult> CreateKitchenOrder(OrderRequest orderRequest);
    }
}
