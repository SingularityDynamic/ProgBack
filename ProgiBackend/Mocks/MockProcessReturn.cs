using Microsoft.AspNetCore.Mvc;
using ProgiBackend.Entities;
using ProgiBackend.Resources.Interfaces;

namespace ProgiBackend.Mocks
{
    public class MockProcessReturn : IProcessReturn
    {
        public async Task<IActionResult> Process(Sale sale)
        {
            return new OkObjectResult(sale);
        }

        public async Task<IActionResult> ProcessBadRequest(string vehicle, decimal price)
        {
            return new BadRequestObjectResult(new ReturnEntity(System.Net.HttpStatusCode.BadRequest, null, new List<string>()));
        }
    }
}
