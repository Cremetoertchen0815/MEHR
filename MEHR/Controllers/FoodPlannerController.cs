using Microsoft.AspNetCore.Mvc;

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
