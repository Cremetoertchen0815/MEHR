using MEHR.Contexts;
using MEHR.Other;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/InfoContollerApi")]
    public class InfoController : Controller
    {
        private DataContext _context;
        public InfoController(DataContext context) => _context = context;

        [HttpGet]
        public LocationInfo GetLocationInfo(int id)
        {
            var location = _context.FoodLocations.First(x => x.Id == id);

            return LocationInfo.FromFoodLocation(location);
        }
    }
}
