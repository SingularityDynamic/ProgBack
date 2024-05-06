using ProgiBackend.Entities;

namespace ProgiBackend.Resources.Interfaces
{
    public interface ISaleCalculation
    {
        public Task<Sale> Calculate(string vehicleType, decimal price);
    }
}
