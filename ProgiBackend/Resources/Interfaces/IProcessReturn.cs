using Microsoft.AspNetCore.Mvc;
using ProgiBackend.Entities;

namespace ProgiBackend.Resources.Interfaces
{
    public interface IProcessReturn
    {
        public Task<IActionResult> ProcessBadRequest(string vehicle, decimal price);

        public Task<IActionResult> Process(Sale sale);
    }
}
