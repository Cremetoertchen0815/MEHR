using MEHR.Contexts;
using MEHR.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/FoodFinderApi")]
    public class FoodFinderController:Controller
    {
        private DataContext _context;
        public FoodFinderController(DataContext context) => _context = context;

        [HttpGet]
        public List<FoodLocation> GetFoodLocations(double? MaxDistanceInKM, decimal? MaxPriceInEuro, List<string> AssociatedTags, bool CurrentlyOpen, bool IsDeleviring, double locLat, double locLong)
        {

            return GenerationAlgorithms.QueryFoodFinder(new FoodFinderQuery(MaxDistanceInKM, MaxPriceInEuro, AssociatedTags, CurrentlyOpen, IsDeleviring), locLat, locLong, _context);
        }
    }
}
