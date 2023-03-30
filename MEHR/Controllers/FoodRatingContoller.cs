using MEHR.Contexts;
using MEHR.Models;
using MEHR.Other;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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
        public void SetRating(int locationId, int userId, int rating, string ratingText) {
            FoodLocation location = _context.FoodLocations.First(x => x.Id == locationId);
            AppUser user = _context.Users.First(x => x.Id == userId);

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