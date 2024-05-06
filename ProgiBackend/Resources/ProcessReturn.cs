using Microsoft.AspNetCore.Mvc;
using ProgiBackend.Entities;
using ProgiBackend.Resources.Interfaces;

namespace ProgiBackend.Resources
{
    public class ProcessReturn : IProcessReturn
    {
        /// <summary>
        /// Wrapper for a return value with HTTP code 400.
        /// </summary>
        /// <param name="vehicle">Vehicle type.</param>
        /// <param name="price">Base sale price.</param>
        /// <returns>Code 400 action result with a ReturnEntity object containing the error messages.</returns>
        public async Task<IActionResult> ProcessBadRequest(string vehicle, decimal price)
        {
            List<string> errors = new List<string>();
            if (vehicle != Constants.COMMON && vehicle != Constants.LUXURY)
                errors.Add("Invalid vehicle type. Only Common and Luxury are valid.");

            if (price < 0m)
                errors.Add("Invalid price. Price must be positive.");

            return new BadRequestObjectResult(new ReturnEntity(System.Net.HttpStatusCode.BadRequest, null, errors));
        }

        /// <summary>
        /// Wrapper for a return value with HTTP code 200.
        /// </summary>
        /// <param name="sale">Details of the sale and fees.</param>
        /// <returns>Code 200 action result with a ReturnEntity object containing the sale</returns>
        public async Task<IActionResult> Process(Sale sale)
        {
            return new OkObjectResult(new ReturnEntity(System.Net.HttpStatusCode.OK, sale, null));
        }
    }
}
