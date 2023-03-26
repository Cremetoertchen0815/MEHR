using MEHR.Contexts;
using MEHR.Models;
using Microsoft.AspNetCore.Mvc;

namespace MEHR.Controllers
{
    [Controller]
    [Route("/UserControllerApi")]
    public class UserController : Controller
    {
        private DataContext _context;
        public UserController(DataContext context) => _context = context;

        [HttpPost]
        public ulong CreateUser()
        {
            var newId = ((long)Random.Shared.Next() << 32) + Random.Shared.Next();
            var user = new AppUser() { CookieHash = (ulong)newId };
            _context.Users.Add(user);
            _context.SaveChanges();
            return (ulong)newId;
        }
    }
}
