using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/FoodPlannerApi")]
    public class FoodPlannerController : Controller
    {
        [HttpGet]
        public string GetFoodSuggestion()
        {
            return "Suggestions";
        }
    }
}
