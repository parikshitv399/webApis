using Microsoft.AspNetCore.Mvc;
using SampleMvc.Models;

namespace SampleMvc.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("/Simple/User")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm]User pUser)
        {
            if(pUser.Username == "admin" && pUser.Password == "nimda")
            {
                return View();
            }
            return View();
        }
    }
}
