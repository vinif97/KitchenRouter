using AutoMapper;
using KitchenRouter.Application.DTOs;
using KitchenRouter.Application.RabbitMQSender;
using KitchenRouter.Application.Result;
using KitchenRouter.Application.Services.Interfaces;
using KitchenRouter.Application.Utils;
using KitchenRouter.Domain.Models;
using KitchenRouter.Domain.Repositories.Interfaces;
using KitchenRouter.Domain.Validations;
using KitchenRouter.Infrastructure.Context;
using KitchenRouter.Infrastructure.Repositories;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace KitchenRouter.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly IRabbitMQMessageSender _messageSender;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper,
            IRabbitMQMessageSender messageSender)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _messageSender = messageSender;
        }

        public async Task<IResult> CreateKitchenOrder(OrderRequest orderRequest)
        {
            var order = _mapper.Map<Order>(orderRequest);

            ErrorResult errorResult;
            if (order.Invalid)
            {
                List<Error> errorList = new();

                foreach (var error in order.ValidationResult!.Errors)
                {
                    errorList.Add(new Error(error.ErrorMessage));
                }

                errorResult = new(errorList);
                return errorResult;
            }

            await _orderRepository.Create(order);

            var message = JsonConvertor.GetMessageAsByteArray(order);
            _messageSender.SendMessage(message, order.KitchenArea.ToString().ToLower() + "queue");

            return new SuccessResult();
        }
    }
}
