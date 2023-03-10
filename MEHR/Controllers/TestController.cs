using MEHR.Contexts;
using MEHR.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace MEHR.Controllers;
[Controller]
[Route("/app")]
public class TestController : Controller
{
    private DataContext _context;
    public TestController(DataContext context) => _context = context;

    public string DoStufff()
    {

        _context.FoodLocations.Add(new FoodLocation()
        {
            Name = "Location A",
            Description = "Essen gibts hier",
            LocationLatitude = 0.1f,
            LocationLongitude = 0.2f,
            PhoneNumber = "+491746074035",
            HasDelivery = false,
            Icon = 50
        });
        return "Woooooow!";
    }
}
