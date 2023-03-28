using MEHR.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/InfoContollerApi")]
    public class InfoController : Controller
    {
        private DataContext _context;
        public InfoController(DataContext context) => _context = context;

        [HttpGet]
        public IActionResult GetLocationInfo(int id)
        {
            var location = _context.FoodLocations.Include(x => x.Foods!).ThenInclude(x => x.Tag).Include(x => x.Ratings).FirstOrDefault(x => x.Id == id);
            if (location == null) return BadRequest();

            return Json(LocationInfo.FromFoodLocation(location));
        }
    }
}
