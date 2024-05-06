using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ProgiBackend.Controllers.Interfaces;
using ProgiBackend.Entities;
using ProgiBackend.Resources.Interfaces;

namespace ProgiBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingController : ControllerBase, IPricingController
    {
        private readonly IProcessReturn _processReturn;
        private readonly ISaleCalculation _saleCalculation;
        private readonly ILogger _logger;

        public PricingController(ILogger<PricingController> logger, IProcessReturn processReturn, ISaleCalculation saleCalculation) : base()
        {
            _logger = logger;
            _processReturn = processReturn;
            _saleCalculation = saleCalculation;
        }

        [HttpGet]
        [EnableCors("localhost")]
        public async Task<IActionResult> GetPrice(string vehicle, decimal price)
        {
            if (vehicle != Resources.Constants.COMMON && vehicle != Resources.Constants.LUXURY || price < 0m)
            {
                _logger.LogInformation($"Bad request received. Vehicle: {vehicle}. Price: {price}.");
                return await _processReturn.ProcessBadRequest(vehicle, price);
            }

            Sale finalSale = await _saleCalculation.Calculate(vehicle, price);

            _logger.LogInformation($"Returning sale data. Vehicle: {vehicle}. Price: {price}.");
            return await _processReturn.Process(finalSale);
        }
    }
}
