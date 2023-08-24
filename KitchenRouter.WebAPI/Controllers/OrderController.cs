using KitchenRouter.Application.DTOs;
using KitchenRouter.Domain.Models;
using KitchenRouter.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KitchenRouter.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _repository;
        public OrderController(IRepository<Order> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderRequest orderRequest) 
        {
            Order order = new(orderRequest.ItemName, orderRequest.Quantity, orderRequest.KitchenArea);
            _repository.Create(order);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = _repository.GetAll();
            
            List<OrderResponse> orderResponses = new();

            foreach (var order in orders)
            {
                orderResponses.Add(new OrderResponse(order.ItemName,
                    order.Quantity, order.KitchenArea));
            }
            return Ok(orderResponses);
        }
    }
}