using MEHR.Contexts;
using MEHR.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers;
[Controller]
[Route("/app")]
public class TestController : Controller
{
    private DataContext _context;
    public TestController(DataContext context) => _context = context;

    public string DoStufff()
    {
        var loolsoos = new Food() { LowerPriceRange = 5.50m, UpperPriceRange = 8m, Name = "N' Döner!" };

        var ele = new FoodLocation()
        {
            Name = "Location A",
            Description = "Essen gibts hier",
            LocationLatitude = 0.1f,
            LocationLongitude = 0.2f,
            PhoneNumber = "+491746074035",
            HasDelivery = false,
            Icon = 50
        };
        ele.Foods.Add(loolsoos);
        _context.FoodLocations.Add(ele);
        _context.SaveChanges();
        return "Woooooow!";
    }
}
