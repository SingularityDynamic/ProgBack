using Microsoft.AspNetCore.Mvc;

namespace ProgiBackend.Controllers.Interfaces
{
    public interface IPricingController
    {
        public Task<IActionResult> GetPrice(string vehicleType, decimal price);
    }
}
