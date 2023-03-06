using Microsoft.AspNetCore.Mvc;

namespace MEHR.Contexts;

[ApiController]
[Route("loolsoos")]
public class DeineBhuddaController : Controller
{

    private readonly TestContext testContext;
    
    public DeineBhuddaController(TestContext context) => testContext = context;

    [HttpDelete]
    public void Testsdghzfui()
    {
        foreach (var element in testContext.WeatherForecasts)
        {
            testContext.WeatherForecasts.Remove(element);
        }
        testContext.SaveChanges();
    }
}
