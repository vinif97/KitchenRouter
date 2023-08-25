using KitchenRouter.Domain.Enums;
using KitchenRouter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRouter.UnitTests.Domain
{
    public class OrderValidationTests
    {
        [Theory]
        [InlineData("French Fries", 0, KitchenArea.Fries, "Quantity cannot be empty")]
        [InlineData("", 2, KitchenArea.Salad, "Order cannot be empty")]
        [InlineData("Hamburguer", 2, (KitchenArea)10, "Invalid kitchen area")]
        public void WhenInvalidOrderQuantity_ReturnError(string orderDescription, int quantity,
            KitchenArea kitchen, string expectedError)
        {
            Order order = new(orderDescription, quantity, kitchen);

            Assert.True(order.Invalid);
            Assert.NotNull(order.ValidationResult!.Errors
                 .SingleOrDefault(error => error.ErrorMessage == expectedError));
        }

        [Fact]
        public void WhenMultipleErrors_DisplayAll()
        {
            Order order = new("", 0, KitchenArea.Drink);
            var expectedErrors = new List<string>()
            {
                "Order cannot be empty",
                "Quantity cannot be empty"
            };

            Assert.True(order.Invalid);

            var actualResult = new List<string>();
            foreach (var error in order.ValidationResult!.Errors)
            {
                actualResult.Add(error.ErrorMessage);
            }

            Assert.Equal(expectedErrors, actualResult);
        }
    }
}
