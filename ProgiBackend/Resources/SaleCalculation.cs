using ProgiBackend.Entities;
using ProgiBackend.Resources.Interfaces;

namespace ProgiBackend.Resources
{
    public class SaleCalculation : ISaleCalculation
    {
        private ILogger _logger;

        public SaleCalculation(ILogger<SaleCalculation> logger)
        {
            _logger = logger;
        }

        public async Task<Sale> Calculate(string vehicleType, decimal price)
        {
            Sale sale = new(vehicleType, price);

            _logger.LogInformation($"Calculating price for {vehicleType} at ${price}.");

            sale.BasicFee = await GetBasicFee(vehicleType, price);
            sale.AssociationFee = await GetAssociationFee(price);
            sale.SpecialFee = Math.Round(price * (vehicleType == Constants.COMMON ? 0.02m : 0.04m), 2);
            sale.StorageFee = 100.00m;

            return sale;
        }

        private async Task<decimal> GetBasicFee(string vehicleType, decimal price)
        {
            decimal fee = price * 0.10m;
            if (vehicleType == Constants.COMMON)
            {
                if (fee < 10m)
                    fee = 10.00m;
                else if (fee > 50m)
                    fee = 50.00m;
            }
            else
            {
                if (fee < 25m)
                    fee = 25.00m;
                else if (fee > 200m)
                    fee = 200.00m;
            }
            return fee;
        }

        private async Task<decimal> GetAssociationFee(decimal price)
        {
            decimal fee = 0m;
            if (price >= 1m && price <= 500m)
                fee = 5.00m;
            else if (price <= 1000m)
                fee = 10.00m;
            else if (price <= 3000m)
                fee = 15.00m;
            else if (price > 3000m)
                fee = 20.00m;
            return fee;
        }
    }
}
