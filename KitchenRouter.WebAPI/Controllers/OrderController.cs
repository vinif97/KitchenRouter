using KitchenRouter.Application.DTOs;
using App = KitchenRouter.Application.Result;
using KitchenRouter.Application.Services;
using KitchenRouter.Application.Services.Interfaces;
using KitchenRouter.Domain.Models;
using KitchenRouter.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using KitchenRouter.Application.Result;

namespace KitchenRouter.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest orderRequest) 
        {
            App.IResult result = await _orderService.CreateKitchenOrder(orderRequest);

            return result switch
            {
                SuccessResult => Ok(),
                ErrorResult errorResult => BadRequest(errorResult.Errors),
                _ => throw new Exception("Unhandled type")
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}