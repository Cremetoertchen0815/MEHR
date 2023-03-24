using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/InfoContollerApi")]
    public class InfoController : Controller
    {

        [HttpGet]
        public string GetLocationInfo()
        {

            return "dummy";
        }
    }
}
