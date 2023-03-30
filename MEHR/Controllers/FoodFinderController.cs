using MEHR.Contexts;
using MEHR.Other;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/FoodFinderApi")]
    [AllowCrossSiteOrigins]
    public class FoodFinderController : Controller
    {
        private DataContext _context;
        public FoodFinderController(DataContext context) => _context = context;

        [HttpGet]
        public SimpleLocationInfo[] GetFoodLocations(double MaxDistanceInKM, decimal MaxPriceInEuro, string AssociatedTags, bool CurrentlyOpen, bool IsDeleviring, double locLat, double locLong)
        {
            var query = GenerationAlgorithms.QueryFoodFinder(new FoodFinderQuery(MaxDistanceInKM <= 0 ? null : MaxDistanceInKM,
                                                                                 MaxPriceInEuro <= 0 ? null : MaxPriceInEuro,
                                                                                 (AssociatedTags ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList(),
                                                                                 CurrentlyOpen, IsDeleviring), locLat, locLong, _context);
            return query.Select(SimpleLocationInfo.FromFoodLocation).ToArray();
        }
    }
}
