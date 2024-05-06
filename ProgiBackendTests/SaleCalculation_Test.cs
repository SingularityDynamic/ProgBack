using Microsoft.Extensions.Logging;
using ProgiBackend.Entities;
using ProgiBackend.Resources;
using ProgiBackend.Resources.Interfaces;

namespace ProgiBackendTests
{
    [TestFixture]
    public class SaleCalculation_Test
    {
        private ILogger<SaleCalculation> _logger;
        private ISaleCalculation _saleCalculation;

        [SetUp]
        public void Setup()
        {
            _logger = new LoggerFactory().CreateLogger<SaleCalculation>();
            _saleCalculation = new SaleCalculation(_logger);
        }

        [Test]
        public async Task CalculateFees_ValidValues_ResultReturned()
        {
            // Arrange
            decimal salePrice = 50m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated, Is.Not.Null);
        }

        [Test]
        public async Task CalculateBasicFee_CommonFeeLowPrice_Returns10()
        {
            // Arrange
            decimal expectedFee = 10m;
            decimal salePrice = 50m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.BasicFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateBasicFee_CommonFeeMidPrice_Returns25()
        {
            // Arrange
            decimal expectedFee = 25m;
            decimal salePrice = 250m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.BasicFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateBasicFee_CommonFeeHighPrice_Returns50()
        {
            // Arrange
            decimal expectedFee = 50m;
            decimal salePrice = 750m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.BasicFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateBasicFee_LuxuryFeeLowPrice_Returns25()
        {
            // Arrange
            decimal expectedFee = 25m;
            decimal salePrice = 50m;
            string vehicleType = Constants.LUXURY;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.BasicFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateBasicFee_LuxuryFeeMidPrice_Returns125()
        {
            // Arrange
            decimal expectedFee = 125m;
            decimal salePrice = 1250m;
            string vehicleType = Constants.LUXURY;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.BasicFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateBasicFee_LuxuryFeeHighPrice_Returns200()
        {
            // Arrange
            decimal expectedFee = 200m;
            decimal salePrice = 2500m;
            string vehicleType = Constants.LUXURY;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.BasicFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateSpecialFee_Common_Returns4()
        {
            // Arrange
            decimal expectedFee = 4m;
            decimal salePrice = 200m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.SpecialFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateSpecialFee_Luxury_Returns8()
        {
            // Arrange
            decimal expectedFee = 8m;
            decimal salePrice = 200m;
            string vehicleType = Constants.LUXURY;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.SpecialFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateAssociationFee_LowestRange_Returns5()
        {
            // Arrange
            decimal expectedFee = 5m;
            decimal salePrice = 450m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.AssociationFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateAssociationFee_SecondRange_Returns10()
        {
            // Arrange
            decimal expectedFee = 10m;
            decimal salePrice = 750m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.AssociationFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateAssociationFee_ThirdRange_Returns15()
        {
            // Arrange
            decimal expectedFee = 15m;
            decimal salePrice = 1150m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.AssociationFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateAssociationFee_HighestRange_Returns20()
        {
            // Arrange
            decimal expectedFee = 20m;
            decimal salePrice = 5000m;
            string vehicleType = Constants.COMMON;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.AssociationFee, Is.EqualTo(expectedFee));
        }

        [Test]
        public async Task CalculateFinalPrice_Case1of6_ReturnsProperResult()
        {
            // Arrange
            string vehicleType = Constants.COMMON;
            decimal salePrice = 398m;
            decimal expectedPrice = 550.76m;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.Total, Is.EqualTo(expectedPrice));
        }

        [Test]
        public async Task CalculateFinalPrice_Case2of6_ReturnsProperResult()
        {
            // Arrange
            string vehicleType = Constants.COMMON;
            decimal salePrice = 501m;
            decimal expectedPrice = 671.02m;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.Total, Is.EqualTo(expectedPrice));
        }

        [Test]
        public async Task CalculateFinalPrice_Case3of6_ReturnsProperResult()
        {
            // Arrange
            string vehicleType = Constants.COMMON;
            decimal salePrice = 57m;
            decimal expectedPrice = 173.14m;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.Total, Is.EqualTo(expectedPrice));
        }

        [Test]
        public async Task CalculateFinalPrice_Case4of6_ReturnsProperResult()
        {
            // Arrange
            string vehicleType = Constants.LUXURY;
            decimal salePrice = 1800m;
            decimal expectedPrice = 2167m;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.Total, Is.EqualTo(expectedPrice));
        }

        [Test]
        public async Task CalculateFinalPrice_Case5of6_ReturnsProperResult()
        {
            // Arrange
            string vehicleType = Constants.COMMON;
            decimal salePrice = 1100m;
            decimal expectedPrice = 1287m;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.Total, Is.EqualTo(expectedPrice));
        }

        [Test]
        public async Task CalculateFinalPrice_Case6of6_ReturnsProperResult()
        {
            // Arrange
            string vehicleType = Constants.LUXURY;
            decimal salePrice = 1000000m;
            decimal expectedPrice = 1040320m;

            // Act
            Sale calculated = await _saleCalculation.Calculate(vehicleType, salePrice);

            // Assert
            Assert.That(calculated.Total, Is.EqualTo(expectedPrice));
        }
    }
}
