using KitchenRouter.Application.DTOs;
using KitchenRouter.Application.RabbitMQSender;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace KitchenRouter.IntegrationTests
{
    public class OrderTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public OrderTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.Replace(ServiceDescriptor.Singleton(_ =>
                    {
                        var messageBusMock = new Mock<IRabbitMQMessageSender>();
                        messageBusMock.Setup(
                            m => m.SendMessage(It.IsAny<byte[]>(), It.IsAny<string>()))
                            .Verifiable();
                        return messageBusMock.Object;
                    }));
                });
            }).CreateClient();
        }

        [Fact]
        public async Task WhenCreateOrderSuccessfully_ReturnOk()
        {
            OrderRequest orderRequest = new("French Fries", 10, Domain.Enums.KitchenArea.Fries);
            string payload = JsonSerializer.Serialize(orderRequest);

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/Order", content);
            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal("", result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenDomainError_ReturnBadRequestWithErrors()
        {
            OrderRequest orderRequest = new("", 0, Domain.Enums.KitchenArea.Fries);
            string payload = JsonSerializer.Serialize(orderRequest);

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/Order", content);
            var result = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(result);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}