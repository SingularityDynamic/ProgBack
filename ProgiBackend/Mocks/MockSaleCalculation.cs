using ProgiBackend.Entities;
using ProgiBackend.Resources.Interfaces;

namespace ProgiBackend.Mocks
{
    public class MockSaleCalculation : ISaleCalculation
    {
        public async Task<Sale> Calculate(string vehicleType, decimal price)
        {
            return new Sale(vehicleType, price);
        }
    }
}
