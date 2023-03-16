using MEHR.Contexts;
using MEHR.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers;
[Controller]
[Route("/TestApi")]
public class TestController : Controller
{
    private DataContext _context;
    public TestController(DataContext context) => _context = context;

    public string? WorkingText = "Big boner down the lane";

    [HttpGet]
    public string GetStuff() => $"This GET call is working! Your current working text is: {WorkingText ?? "nothing at all"}";

    [HttpPost]
    public string PostStuff(string text)
    {
        WorkingText = text;
        return $"Thanks for posting stuff! {text ?? "nothing at all"} all day long!";
    }

    [HttpPut]
    public string PutStuff(string text)
    {
        WorkingText = text;
        return $"Thanks for put put put putting stuff! Does the exact same thing as posting rn tho lol lmao big L \n {text ?? "nothing at all"} all day long!";
    }

    [HttpDelete]
    public string DeleteStuff()
    {
        WorkingText = null;
        return "Now our text is gone. Great job, idiot!";
    }
}
