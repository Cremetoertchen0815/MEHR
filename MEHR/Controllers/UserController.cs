using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/UserControllerApi")]
    public class UserController : Controller
    {

        [HttpPost]
        public int CreateUser() {
            return 0;
        }
    }
}
