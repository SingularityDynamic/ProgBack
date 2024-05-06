using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProgiBackend.Entities
{
    public class ReturnEntity
    {
        public HttpStatusCode StatusCode { get; set; }

        public Sale? SaleDetails { get; set; }

        public List<string>? ErrorMessages { get; set; }

        public ReturnEntity(HttpStatusCode code, Sale? sale, List<string>? errors)
        {
            StatusCode = code;
            SaleDetails = sale;
            if (errors?.Count > 0)
            {
                ErrorMessages = errors;
            }
        }
    }
}
