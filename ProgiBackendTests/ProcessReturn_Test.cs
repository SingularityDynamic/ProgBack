using Microsoft.AspNetCore.Mvc;
using ProgiBackend.Entities;
using ProgiBackend.Resources;
using ProgiBackend.Resources.Interfaces;

namespace ProgiBackendTests
{
    [TestFixture]
    public class ProcessReturn_Test
    {
        private IProcessReturn _processReturn;

        [SetUp]
        public void Setup()
        {
            _processReturn = new ProcessReturn();
        }

        [Test]
        public async Task GetPrice_EmptyVehicle_ReturnsBadRequest()
        {
            // Arrange
            string vehicle = "";
            decimal price = 100;

            // Act
            var action = await _processReturn.ProcessBadRequest(vehicle, price);

            // Assert
            Assert.That(action, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task GetPrice_EmptyVehicle_OneErrorMessage()
        {
            // Arrange
            string vehicle = "";
            decimal price = 100;

            // Act
            var returnValue = await _processReturn.ProcessBadRequest(vehicle, price);
            ReturnEntity contents = (ReturnEntity)(returnValue as BadRequestObjectResult).Value;

            // Assert
            Assert.That(contents.ErrorMessages, Is.Not.Null);
            Assert.That(contents.ErrorMessages, Is.Not.Empty);
            Assert.That(contents.ErrorMessages, Has.Count.EqualTo(1));
        }

        [Test]
        public async Task GetPrice_NegativePrice_OneErrorMessage()
        {
            // Arrange
            string vehicle = "Common";
            decimal price = -1;

            // Act
            var returnValue = await _processReturn.ProcessBadRequest(vehicle, price);
            ReturnEntity contents = (ReturnEntity)(returnValue as BadRequestObjectResult).Value;

            // Assert
            Assert.That(contents.ErrorMessages, Is.Not.Null);
            Assert.That(contents.ErrorMessages, Is.Not.Empty);
            Assert.That(contents.ErrorMessages, Has.Count.EqualTo(1));
        }

        [Test]
        public async Task GetPrice_InvalidVehicleBadPrice_TwoErrorMessages()
        {
            // Arrange
            string vehicle = "lux";
            decimal price = -1;

            // Act
            var returnValue = await _processReturn.ProcessBadRequest(vehicle, price);
            ReturnEntity contents = (ReturnEntity)(returnValue as BadRequestObjectResult).Value;

            // Assert
            Assert.That(contents.ErrorMessages, Is.Not.Null);
            Assert.That(contents.ErrorMessages, Is.Not.Empty);
            Assert.That(contents.ErrorMessages, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task GetPrice_CleanInput_ReturnsOK()
        {
            // Arrange
            Sale sale = new Sale(Constants.COMMON, 100);

            // Act
            var result = await _processReturn.Process(sale);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}
