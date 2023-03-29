using MEHR.Contexts;
using MEHR.Other;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/FoodPlannerApi")]
    public class FoodPlannerController : Controller
    {

        private DataContext _context;
        public FoodPlannerController(DataContext context) => _context = context;

        [HttpGet]
        public SimpleLocationInfo[]? GetFoodPlan(double MaxDistanceInKM, decimal MaxPriceInEuro, float Diversity, float ExternalInfluence, ulong userID, double locLat, double locLong)
        {
            var query = GenerationAlgorithms.QueryFoodPlanner(new FoodPlannerQuery(Diversity, ExternalInfluence,
                                                                                 MaxDistanceInKM <= 0 ? null : MaxDistanceInKM,
                                                                                 MaxPriceInEuro <= 0 ? null : MaxPriceInEuro),
                                                                                 userID, locLat, locLong, _context);
            _context.SaveChanges();
            return query?.Select(SimpleLocationInfo.FromFoodLocation).ToArray();
        }
    }
}
