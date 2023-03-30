using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/CurrencyApi")]
    [AllowCrossSiteOrigins]
    public class CurrencyChangeController : Controller
    {
        public class CurrencyResult
        {
            public Dictionary<string, float> data { get; set; } = new();

        }

        [HttpGet]
        [Route("/ChangeToEuro")]
        public decimal changeToEuro(decimal value, string currency)
        {
            var client = new RestClient("https://api.freecurrencyapi.com/v1/latest");
            var request = new RestRequest();
            request.AddParameter("apikey", "vfhrYYrcsUrh9kFEWuYXmDUmMzo0H5mvwaAvVeDz");
            var response = client.Get<CurrencyResult>(request)!;
            return Math.Round(value / (decimal)response.data[currency] * (decimal)response.data["EUR"], 2);

        }

        [HttpGet]
        [Route("/ChangeGeneral")]
        public decimal changeCurrency(decimal value, string sourceCurrency, string targetCurrency)
        {
            var client = new RestClient("https://api.freecurrencyapi.com/v1/latest");
            var request = new RestRequest();
            request.AddParameter("apikey", "vfhrYYrcsUrh9kFEWuYXmDUmMzo0H5mvwaAvVeDz");
            var response = client.Get<CurrencyResult>(request)!;
            return Math.Round(value / (decimal)response.data[sourceCurrency] * (decimal)response.data[targetCurrency], 2);
        }
    }
}
