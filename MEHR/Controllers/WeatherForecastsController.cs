using MEHR.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [ApiController]
    [Route("Testerheld")]
    public class WeatherForecastsController : Controller
    {
        private readonly TestContext _context;

        public WeatherForecastsController(TestContext context)
        {
            _context = context;
        }

        // GET: WeatherForecasts
        [HttpGet]
        public IEnumerable<WeatherForecast> GetStuff()
        {
              return _context.WeatherForecasts.Where(x => x.TemperatureC > 20);
        }

        [HttpPost]
        public void GenerateTestData()
        {
            _context.WeatherForecasts.AddRange(Enumerable.Range(0, 10).Select(_ => new WeatherForecast() { Date = DateTime.Now, Summary = "Wenn nicht jetzt wann dann , wenn nicht wir wer sonst ?", TemperatureC = Random.Shared.Next(0, 100) }));
            _context.SaveChanges();
        }
    }
}
