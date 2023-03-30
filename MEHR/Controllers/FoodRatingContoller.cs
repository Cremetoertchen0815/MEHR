using MEHR.Contexts;
using MEHR.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/FoodRatingApi")]
    [AllowCrossSiteOrigins]
    public class FoodRatingController : Controller
    {

        private DataContext _context;
        public FoodRatingController(DataContext context) => _context = context;

        [HttpPost]
        public void SetRating(int locationId, ulong userId, int rating, string ratingText)
        {
            FoodLocation location = _context.FoodLocations.First(x => x.Id == locationId);
            AppUser user = _context.Users.First(x => x.CookieHash == userId);

            LocationRating ratingObj = new LocationRating();
            ratingObj.Location = location;
            ratingObj.Author = user;
            ratingObj.Rating = rating;
            ratingObj.Text = ratingText;
            _context.Ratings.Add(ratingObj);
            _context.SaveChanges();

        }
    }
}