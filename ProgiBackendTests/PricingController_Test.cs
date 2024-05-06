using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgiBackend.Controllers;
using ProgiBackend.Controllers.Interfaces;
using ProgiBackend.Mocks;
using ProgiBackend.Resources.Interfaces;

namespace ProgiBackendTests
{
    [TestFixture]
    public class PricingController_Test
    {
        private IPricingController _controller;
        private IProcessReturn _processReturn;
        private ISaleCalculation _saleCalculation;
        private ILogger<PricingController> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new LoggerFactory().CreateLogger<PricingController>();
            _processReturn = new MockProcessReturn();
            _saleCalculation = new MockSaleCalculation();
            _controller = new PricingController(_logger, _processReturn, _saleCalculation);
        }

        [Test]
        public async Task GetPrice_EmptyVehicle_ReturnsBadRequest()
        {
            // Arrange
            string vehicle = "";
            decimal price = 100;

            // Act
            var action = await _controller.GetPrice(vehicle, price);

            // Assert
            Assert.That(action, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task GetPrice_CleanInput_ReturnsOK()
        {
            // Arrange
            string vehicle = "Common";
            decimal price = 100;

            // Act
            var result = await _controller.GetPrice(vehicle, price);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}